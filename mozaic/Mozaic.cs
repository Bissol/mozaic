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

        [ProtoMember(15)]
        public string appPath = "";

        [ProtoMember(20)]
        public List<string> tiles = new List<string>();

        [ProtoMember(25)]
        public Dictionary<int, List<string>> fastIndex = new Dictionary<int, List<string>>();

        [ProtoMember(30)]
        public Dictionary<string, List<int>> colorData = new Dictionary<string, List<int>>();

        [ProtoMember(40)]
        public int matchSize = 4; // Tiles will be divided i*i for comparison
    }

    class Mozaic
    {
        CollectionData data = new CollectionData();
        int weightRGBError;
        int weightIntensityError;
        int weightRelativeIntensityError;

        public Mozaic(string tilesPath, string appPath, int wRgbErr, int wIntensityErr, int wRelIntErr)
        {
            data.tilesPath = tilesPath;
            data.appPath = appPath;

            this.weightIntensityError = weightIntensityError;
            this.weightRelativeIntensityError = wRelIntErr;
            this.weightRGBError = weightRGBError;
        }

        public void setWeight(int wRgbErr, int wIntensityErr, int wRelIntErr)
        {
            this.weightIntensityError = weightIntensityError;
            this.weightRelativeIntensityError = wRelIntErr;
            this.weightRGBError = weightRGBError;
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
            using (var file = File.Create(data.appPath + "/" + "data.bin"))
            {
                Serializer.Serialize(file, data);
            }
        }

        public void loadData()
        {
            using (var file = File.OpenRead(data.appPath + "/" + "data.bin"))
            {
                data = Serializer.Deserialize<CollectionData>(file);
            }
        }

        public string make()
        {
            bool fastSearch = true;
            int sourceNumColRow = Properties.Settings.Default.nbColRows;
            int destinationSquareSize = Properties.Settings.Default.tileSizeResult;
            Bitmap target = new Bitmap(Properties.Settings.Default.ImgTargetPath);
            int sourceSquareSize = Math.Max(target.Width, target.Height) / sourceNumColRow;
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
                    Rectangle rec = new Rectangle(i * sourceSquareSize, j * sourceSquareSize, sourceSquareSize, sourceSquareSize);
                    grafics.DrawImage(target, 0, 0, rec, GraphicsUnit.Pixel);
                    {
                        tmpColorList = ImageProcessing.CalculateAverageColor(tmptile, data.matchSize);
                        Color c = Color.FromArgb(tmpColorList[0]);
                        //string matchPath = this.findBestMatchSimple(c);
                        string matchPath = this.findBestMatch(tmpColorList, fastSearch);

                        // Copy match img to relevant location in output img
                        using (Bitmap tile = new Bitmap(matchPath))
                        {
                            outputGraphic.DrawImage(tile, new Rectangle(i * destinationSquareSize, j * destinationSquareSize, destinationSquareSize, destinationSquareSize));
                        }
                    }
                }
            }

            string resultImagePath = data.appPath + '/' + "result.png";
            outputImg.Save(resultImagePath, ImageFormat.Png);
            outputGraphic.Dispose();
            outputImg.Dispose();

            return resultImagePath;
        }

        private string findBestMatch(List<int> colorData, bool fastSearch)
        {
            string bestMatchPath = "";
            float minError = 0;
            float intensityError = 0;
            float relativeIntensityError = 0;
            Color avgColorSrc = Color.FromArgb(colorData[0]);
            float avgBrightessSrc = avgColorSrc.GetBrightness();
            Color c;

            // Dont search full list if fastSearch enabled
            int index = this.colorToIndex(colorData[0]);
            List<string> searchList = fastSearch ? (data.fastIndex.ContainsKey(index) ? data.fastIndex[index] : data.tiles) : data.tiles;
            
            foreach (string path in searchList)
            {
                List<int> values = data.colorData[path];

                // Error in average color
                c = Color.FromArgb(values[0]);
                float avgRGBError = Math.Abs(avgColorSrc.R - c.R);
                avgRGBError += Math.Abs(avgColorSrc.G - c.G);
                avgRGBError += Math.Abs(avgColorSrc.B - c.B);

                // Error in intensity map
                intensityError = 0;
                relativeIntensityError = 0;
                float avgBrightess = c.GetBrightness();
                for (int i = 1; i< values.Count; i++)
                {
                    Color ci = Color.FromArgb(values[i]);
                    Color ct = Color.FromArgb(colorData[i]);
                    float dif = Math.Abs(ci.GetBrightness() - ct.GetBrightness());
                    float relDif = Math.Abs((ci.GetBrightness() - avgBrightess) - (ct.GetBrightness() - avgBrightessSrc));
                    intensityError += dif;
                    relativeIntensityError += relDif;
                };
                intensityError = intensityError / (values.Count - 1);
                relativeIntensityError = relativeIntensityError / (values.Count - 1);

                // Global error
                float globalError = this.weightRelativeIntensityError * relativeIntensityError + this.weightRGBError * avgRGBError + this.weightIntensityError * intensityError;
                if (minError == 0 || globalError < minError)
                {
                    minError = globalError;
                    bestMatchPath = path;
                }
            }

            return bestMatchPath;
        }

        private string findBestMatchSimple(Color color)
        {
            string bestMatchPath = "";
            float minError = 0;
            Color c;

            int index = this.colorToIndex(color.ToArgb());
            List<string> searchList = data.fastIndex.ContainsKey(index) ? data.fastIndex[index] : data.tiles;

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
