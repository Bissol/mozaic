using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mozaic
{
    [ProtoContract]
    class CollectionData
    {
        [ProtoMember(10)]
        public string tilesPath = "";

        [ProtoMember(20)]
        public List<string> tiles = new List<string>();

        [ProtoMember(25)]
        public Dictionary<int, List<string>> fastIndex = new Dictionary<int, List<string>>();

        [ProtoMember(30)]
        public Dictionary<string, List<int>> colorData = new Dictionary<string, List<int>>();

        [ProtoMember(40)]
        public int matchSize = 3; // Tiles will be divided i*i for comparison
    }

    class Mozaic
    {
        CollectionData data = new CollectionData();

        public Mozaic(string tilesPath)
        {
            data.tilesPath = tilesPath;
        }

        public void prepareData()
        {
            // Load tiles paths (TODO: load data from file if already computed)
            if (Directory.Exists(data.tilesPath))
            {
                data.tiles.AddRange(Directory.GetFiles(data.tilesPath));
            }

            // Compute tiles stats
            foreach(string tpath in data.tiles)
            {
                using (Bitmap bm = new Bitmap(tpath))
                {
                    List<int> c = ImageProcessing.CalculateAverageColor(bm, data.matchSize);
                    data.colorData[tpath] = c;

                    // Index for faster retrieval
                    int index = this.colorToIndex(c[0]);
                    if (!data.fastIndex.ContainsKey(index)) data.fastIndex[index] = new List<string>();
                    data.fastIndex[index].Add(tpath);
                }
            }

            // Save
            saveData();
        }

        private int colorToIndex(int color)
        {
            int res = 0;
            int colorIdxQuantization = Properties.Settings.Default.colorIndexQuant;
            Color rgbc = Color.FromArgb(color);
            res = rgbc.R / (256 / colorIdxQuantization);
            res += (rgbc.G / (256 / colorIdxQuantization));
            res += (rgbc.B / (256 / colorIdxQuantization));

            return res;
        }

        public void saveData()
        {
            using (var file = File.Create(Properties.Settings.Default.LastPath + "/" + "data.bin"))
            {
                Serializer.Serialize(file, data);
            }
        }

        public void loadData()
        {
            using (var file = File.OpenRead(Properties.Settings.Default.LastPath + "/" + "data.bin"))
            {
                data = Serializer.Deserialize<CollectionData>(file);
            }
        }

        public void make()
        {
            int sourceNumColRow = 30;
            int destinationSquareSize = 80;
            Bitmap target = new Bitmap(Properties.Settings.Default.ImgTargetPath);
            int sourceSquareSize = target.Width / sourceNumColRow;
            int numCol = target.Width / sourceSquareSize;
            int numRow = target.Height / sourceSquareSize;


            Bitmap outputImg = new Bitmap(numCol * destinationSquareSize, numRow * destinationSquareSize);
            Graphics outputGraphic = Graphics.FromImage(outputImg);

            Bitmap tmptile = new Bitmap(sourceSquareSize, sourceSquareSize);
            Graphics grafics = Graphics.FromImage(tmptile);

            List<int> tmpColorList;

            for (int i = 0; i< numCol; i++)
            {
                for (int j=0; j< numRow; j++)
                {
                    //using (Bitmap croppedImage = target.Clone(new Rectangle(i * sourceSquareSize, j * sourceSquareSize, sourceSquareSize, sourceSquareSize), target.PixelFormat))
                    Rectangle rec = new Rectangle(i * sourceSquareSize, j * sourceSquareSize, sourceSquareSize, sourceSquareSize);
                    grafics.DrawImage(target, 0, 0, rec, GraphicsUnit.Pixel);
                    //grafics.DrawImage(target, new Rectangle(i * sourceSquareSize, j * sourceSquareSize, sourceSquareSize, sourceSquareSize));
                    {
                        tmpColorList = ImageProcessing.CalculateAverageColor(tmptile, data.matchSize);
                        Color c = Color.FromArgb(tmpColorList[0]);
                        string matchPath = this.findBestMatchSimple(c);

                        // Copy match img to relevant location in output img
                        using (Bitmap tile = new Bitmap(matchPath))
                        {
                            outputGraphic.DrawImage(tile, new Rectangle(i * destinationSquareSize, j * destinationSquareSize, destinationSquareSize, destinationSquareSize));
                        }
                    }
                }
            }

            //outputImg = new Bitmap(numCol* destinationSquareSize, numRow* destinationSquareSize, outputGraphic);
            outputImg.Save(Properties.Settings.Default.LastPath + '/' + "result.png", ImageFormat.Png);
        }

        private string findBestMatchSimple(Color color)
        {
            string bestMatchPath = "";
            float minError = 0;
            Color c;

            int index = this.colorToIndex(color.ToArgb());
            List<string> searchList = data.fastIndex.ContainsKey(index) ? data.fastIndex[index] : data.tiles;

            //foreach (KeyValuePair<string, List<int>> entry in data.colorData)
            foreach(string path in searchList)
            {
                List<int> values = data.colorData[path];
                c = Color.FromArgb(values[0]);
                float error = (float)Math.Pow(Math.Abs(color.R - c.R), 2);
                error += (float)Math.Pow(Math.Abs(color.G - c.G), 2);
                error += (float)Math.Pow(Math.Abs(color.B - c.B), 2);

                if (minError == 0 || error < minError)
                {
                    minError = error;
                    bestMatchPath = path;
                }
            }

            return bestMatchPath;
        }
    }
}
