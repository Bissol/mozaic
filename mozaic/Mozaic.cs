﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mozaic
{
    class Mozaic
    {
        private string tilesPath = "";
        private List<string> tiles = new List<string>();

        public Mozaic(string tilesPath)
        {
            this.tilesPath = tilesPath;
        }

        public void build()
        {
            // Load tiles paths
            if (Directory.Exists(this.tilesPath))
            {
                this.tiles.AddRange(Directory.GetFiles(this.tilesPath));
            }

            // Compute tiles stats
            foreach(string tpath in this.tiles)
            {
                using (Bitmap bm = new Bitmap(tpath))
                {
                    Color c = ImageProcessing.CalculateAverageColor(bm);
                }
                    
            }
        }
    }
}
