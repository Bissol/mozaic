using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mozaic
{
    [ProtoContract]
    class CollectionData
    {
        [ProtoMember(1)]
        public string tilesPath = "";

        [ProtoMember(2)]
        public List<string> tiles = new List<string>();

        [ProtoMember(3)]
        public Dictionary<string, List<int>> colorData = new Dictionary<string, List<int>>();
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
                    List<int> c = ImageProcessing.CalculateAverageColor(bm, 3);
                    data.colorData[tpath] = c;
                }
            }

            // Load target image
            Bitmap target = new Bitmap(Properties.Settings.Default.ImgTargetPath);

            // Save
            saveData();
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
            Bitmap target = new Bitmap(Properties.Settings.Default.ImgTargetPath);
            int squareSize = 50;
            int numCol = target.Width / squareSize;
            int numRow = target.Height / squareSize;
            List<int> tmpColorList;

            for (int i = 0; i< numCol; i++)
            {
                for (int j=0; j< numRow; j++)
                {
                    using (petit carré)
                    tmpColorList = ImageProcessing.CalculateAverageColor(petit carré)
                }
            }
        }

        private string findBestMatch(Color color)
        {
            string bestMatchPath = "";
            float minError = 0;
            Color c;

            foreach (KeyValuePair<string, List<int>> entry in data.colorData)
            {
                c = Color.FromArgb(entry.Value[0]);
                float error = (float)Math.Pow(Math.Abs(color.R - c.R), 2);
                error += (float)Math.Pow(Math.Abs(color.G - c.G), 2);
                error += (float)Math.Pow(Math.Abs(color.B - c.B), 2);

                if (minError == 0 || error < minError)
                {
                    minError = error;
                    bestMatchPath = entry.Key;
                }
            }

            return bestMatchPath;
        }
    }
}
