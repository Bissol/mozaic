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
        public Dictionary<string, List<Color>> colorData = new Dictionary<string, List<Color>>();
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
                    List<Color> c = ImageProcessing.CalculateAverageColor(bm, 3);
                    data.colorData[tpath] = c;
                }
            }

            // Load target image
            Bitmap target = new Bitmap(Properties.Settings.Default.ImgTargetPath);

            // Save
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

        
    }
}
