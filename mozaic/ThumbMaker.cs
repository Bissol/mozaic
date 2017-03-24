using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mozaic
{
    public class ThumbMaker
    {
        private string[] images;
        private string tilesDir = "";
        public int thumbSize = 150;
        public string _pathToImages;

        public ThumbMaker(string pathToImages, string pathToTiles)
        {
            // Load all image path
            _pathToImages = pathToImages;
            if (Directory.Exists(_pathToImages))
            {
                this.images = Directory.GetFiles(_pathToImages, "*.jpg", SearchOption.AllDirectories);
                this.tilesDir = pathToTiles;

                // Create tile dir
                if (!Directory.Exists(this.tilesDir))
                {
                    Directory.CreateDirectory(this.tilesDir);
                }
            }
        }

        public void Process(IProgress<int> progress)
        {
            //for (int i = 0; i < this.images.Length; i++)
            int count = 0;
            var lockTarget = new object();
            float total = this.images.Length;
            Parallel.ForEach(this.images, new ParallelOptions { MaxDegreeOfParallelism = 4 }, imagePath =>
            {
                lock (lockTarget)
                {
                    count++;
                }
                
                int percent = (int)((count / total) * 100f);
                progress.Report(percent);
                string dir = Path.GetDirectoryName(imagePath);// this.images[i]);
                dir = dir.Replace(this._pathToImages, this.tilesDir);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                string fname = Path.Combine(dir, count.ToString());// Path.GetFileNameWithoutExtension(imagePath));//this.images[i]));
                if (File.Exists(fname + ".jpg")) return;// continue;

                Bitmap tmpbmp = new Bitmap(this.thumbSize, this.thumbSize);

                using (Image im = Image.FromFile(imagePath))//this.images[i]))
                {
                    // First resize
                    Bitmap imS = new Bitmap(3 * this.thumbSize, 3*this.thumbSize);
                    ThumbMaker.ResizeImage(ref imS, im, 3 * this.thumbSize);
                    Bitmap tmpfull = new Bitmap(imS.Width, imS.Height);

                    //using (Bitmap res = ThumbMaker.ResizeImage(ref tmpbmp, im, this.thumbSize))
                    ThumbMaker.ResizeImage(ref tmpbmp, imS, this.thumbSize);
                    string p = fname + ".jpg";
                    tmpbmp.Save(p, ImageFormat.Jpeg);

                    // 45 degrees
                    ThumbMaker.RotateImage(ref tmpfull, imS, 45, 1.4f);
                    ThumbMaker.ResizeImage(ref tmpbmp, tmpfull, this.thumbSize);
                    tmpbmp.Save(fname + "1" + ".jpg", ImageFormat.Jpeg);

                    // -45
                    ThumbMaker.RotateImage(ref tmpfull, imS, -45, 1.4f);
                    ThumbMaker.ResizeImage(ref tmpbmp, tmpfull, this.thumbSize);
                    tmpbmp.Save(fname + "2" + ".jpg", ImageFormat.Jpeg);

                    // +22
                    ThumbMaker.RotateImage(ref tmpfull, imS, 22, 1.3f);
                    ThumbMaker.ResizeImage(ref tmpbmp, tmpfull, this.thumbSize);
                    tmpbmp.Save(fname + "3" + ".jpg", ImageFormat.Jpeg);

                    //-22
                    ThumbMaker.RotateImage(ref tmpfull, imS, -22, 1.3f);
                    ThumbMaker.ResizeImage(ref tmpbmp, tmpfull, this.thumbSize);
                    tmpbmp.Save(fname + "4" + ".jpg", ImageFormat.Jpeg);

                    /*Image minus45 = ThumbMaker.RotateImage(res, -45, 1.4f);
                    minus45.Save(fname + "_-45" + ".jpg", ImageFormat.Jpeg);
                    minus45.Dispose();

                    Image plus22 = ThumbMaker.RotateImage(res, 22, 1.3f);
                    plus22.Save(fname + "_22" + ".jpg", ImageFormat.Jpeg);
                    plus22.Dispose();

                    Image minus22 = ThumbMaker.RotateImage(res, -22, 1.3f);
                    minus22.Save(fname + "_-22" + ".jpg", ImageFormat.Jpeg);
                    minus22.Dispose();*/

                    //res.Dispose();

                    im.Dispose();
                    tmpfull.Dispose();
                }
                tmpbmp.Dispose();
            });
        }

        private static void ResizeImage(ref Bitmap destImage, Image image, int thumbsize)
        {
            // Crop info
            int x0 = 0;
            int y0 = 0;
            int w = 0;
            int h = 0;
            if (image.Width >= image.Height)
            {
                int d = (image.Width - image.Height) / 2;
                x0 = d;
                y0 = 0;
                w = image.Height;
                h = image.Height;
            }
            else
            {
                int d = (image.Height - image.Width) / 2;
                x0 = 0;
                y0 = d;
                w = image.Width;
                h = image.Width;
            }

            var destRect = new Rectangle(0, 0, thumbsize, thumbsize);
            //var destImage = new Bitmap(thumbsize, thumbsize);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, x0, y0, w, h, GraphicsUnit.Pixel, wrapMode);
                    graphics.Dispose();
                    wrapMode.Dispose();
                }
            }

        }

        public static void RotateImage(ref Bitmap bmp, Image img, float rotationAngle, float zoom)
        {
            //create an empty Bitmap image
            //Bitmap bmp = new Bitmap(img.Width, img.Height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2f, (float)bmp.Height / 2f);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2f, -(float)bmp.Height / 2f);
      
            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            int d = (int)(img.Width * zoom) - img.Width;
            var destRect = new Rectangle(-d/2, -d/2, (int)(img.Width*zoom), (int)(img.Height*zoom));
            
            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                gfx.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                wrapMode.Dispose();
            }
            //gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            //return bmp;
        }
    }
}
