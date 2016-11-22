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

        public void Process()
        {
            for (int i = 0; i < this.images.Length; i++)
            //Parallel.ForEach(this.images, imagePath =>
            {
                string dir = Path.GetDirectoryName(this.images[i]);
                dir = dir.Replace(this._pathToImages, this.tilesDir);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                string fname = Path.Combine(dir, Path.GetFileNameWithoutExtension(this.images[i]));
                if (File.Exists(fname + "_tile" + ".png")) continue;

                using (Image im = Image.FromFile(this.images[i]))//this.images[i]))
                {
                    using (Bitmap res = ThumbMaker.ResizeImage(im, this.thumbSize))
                    {
                        string p = fname + "_tile" + ".png";
                        res.Save(p, ImageFormat.Png);

                        // 45 degrees
                        Image plus45 = ThumbMaker.RotateImage(res, 45, 1.4f);
                        plus45.Save(fname + "_45" + ".png", ImageFormat.Png);
                        plus45.Dispose();

                        Image minus45 = ThumbMaker.RotateImage(res, -45, 1.4f);
                        minus45.Save(fname + "_-45" + ".png", ImageFormat.Png);
                        minus45.Dispose();

                        Image plus22 = ThumbMaker.RotateImage(res, 22, 1.3f);
                        plus22.Save(fname + "_22" + ".png", ImageFormat.Png);
                        plus22.Dispose();

                        Image minus22 = ThumbMaker.RotateImage(res, -22, 1.3f);
                        minus22.Save(fname + "_-22" + ".png", ImageFormat.Png);
                        minus22.Dispose();
                        
                        res.Dispose();
                    }
                    im.Dispose();
                }
            }
        }

        private static Bitmap ResizeImage(Image image, int thumbsize)
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
            var destImage = new Bitmap(thumbsize, thumbsize);

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

            return destImage;
        }

        public static Image RotateImage(Image img, float rotationAngle, float zoom)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
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
            return bmp;
        }
    }
}
