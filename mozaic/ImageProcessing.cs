using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mozaic
{
    public class ImageProcessing
    {
        public static List<int> CalculateAverageColor(Bitmap bm, int nbColRow)
        {
            List<int> result = new List<int>();
            int[] reds = new int[nbColRow * nbColRow];
            int[] greens = new int[nbColRow * nbColRow];
            int[] blues = new int[nbColRow * nbColRow];

            int nbColOrRow = nbColRow;
            int width = bm.Width;
            int height = bm.Height;
            double tileSize = (double)width / (double)nbColRow;
            int red = 0;
            int green = 0;
            int blue = 0;
            int minDiversion = 0; // drop pixels that do not differ by at least minDiversion between color values (white, gray or black)
            int dropped = 0; // keep track of dropped pixels
            long[] totals = new long[] { 0, 0, 0 };
            int bppModifier = bm.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb ? 3 : 4; // cutting corners, will fail on anything else but 32 and 24 bit images

            BitmapData srcData = bm.LockBits(new System.Drawing.Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, bm.PixelFormat);
            int stride = srcData.Stride;
            IntPtr Scan0 = srcData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        // Global average
                        int idx = (y * stride) + x * bppModifier;
                        red = p[idx + 2];
                        green = p[idx + 1];
                        blue = p[idx];
                        if (Math.Abs(red - green) > minDiversion || Math.Abs(red - blue) > minDiversion || Math.Abs(green - blue) > minDiversion)
                        {
                            totals[2] += red;
                            totals[1] += green;
                            totals[0] += blue;
                        }
                        else
                        {
                            dropped++;
                        }

                        // Local average
                        int bx = (int)Math.Floor((double)x / tileSize);
                        if (bx == nbColOrRow) bx--;
                        int by = (int)Math.Floor((double)y / tileSize);
                        if (by == nbColOrRow) by--;
                        reds[by * nbColRow + bx] += red;
                        greens[by * nbColRow + bx] += green;
                        blues[by * nbColRow + bx] += blue;
                    }
                }
            }

            int count = width * height - dropped + 1;
            int avgR = (int)(totals[2] / count);
            int avgG = (int)(totals[1] / count);
            int avgB = (int)(totals[0] / count);

            result.Add(Color.FromArgb(avgR, avgG, avgB).ToArgb());

            // Local colors
            int nbpts = (int)(tileSize * tileSize);
            for (int i=0; i<nbColRow; i++)
            {
                for (int j = 0; j<nbColRow; j++)
                {
                    reds[j * nbColRow + i] = reds[j * nbColRow + i] / nbpts;
                    if (reds[j * nbColRow + i] > 255) reds[j * nbColRow + i] = 255;
                    greens[j * nbColRow + i] = greens[j * nbColRow + i] / nbpts;
                    if (greens[j * nbColRow + i] > 255) greens[j * nbColRow + i] = 255;
                    blues[j * nbColRow + i] = blues[j * nbColRow + i] / nbpts;
                    if (blues[j * nbColRow + i] > 255) blues[j * nbColRow + i] = 255;
                    result.Add(Color.FromArgb(reds[j * nbColRow + i], greens[j * nbColRow + i], blues[j * nbColRow + i]).ToArgb());
                }
            }
            bm.UnlockBits(srcData);
            return result;
        }

        public static Bitmap AdjustImage(Bitmap bmp, float p_brightness, float p_contrast, float p_gamma)
        {
            Bitmap originalImage;
            Bitmap adjustedImage;
            float brightness = p_brightness;// 1.0f; // no change in brightness
            float contrast = p_contrast; // 2.0f; // twice the contrast
            float gamma = p_gamma; // 1.0f; // no change in gamma

            float adjustedBrightness = brightness - 1.0f;
            float[][] ptsArray ={
                new float[] {contrast, 0, 0, 0, 0}, // scale red
                new float[] {0, contrast, 0, 0, 0}, // scale green
                new float[] {0, 0, contrast, 0, 0}, // scale blue
                new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
                new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}
            };

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, imageAttributes);

            return bmp;
        }

        public static void SetAdjustmentParams(ref ImageAttributes imageAttributes, float p_brightness, float p_contrast, float p_gamma)
        {
            float brightness = p_brightness;// 1.0f; // no change in brightness
            float contrast = p_contrast; // 2.0f; // twice the contrast
            float gamma = p_gamma; // 1.0f; // no change in gamma

            float adjustedBrightness = brightness - 1.0f;
            float[][] ptsArray ={
                new float[] {contrast, 0, 0, 0, 0}, // scale red
                new float[] {0, contrast, 0, 0, 0}, // scale green
                new float[] {0, 0, contrast, 0, 0}, // scale blue
                new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
                new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}
            };

            
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
        }

        // Smart edges (tm) ;-)
        public static void SmartMergeVertical(ref Bitmap bmp, int xpos, int mergeSize, int smoothness, int avgMapSize, float stopThreshold)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int stride = data.Stride;
            int bppModifier = bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb ? 3 : 4;
            int red, green, blue = 0;
            int red2, green2, blue2 = 0;
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;

                // Make a copy
                int length = Math.Abs(data.Stride) * data.Height;
                byte[] copy = new byte[length];
                Marshal.Copy(data.Scan0, copy, 0, copy.Length);

                // Compute average
                float[] averageMap = new float[length];
                ImageProcessing.computeAvgMap(ref averageMap, stride, bppModifier, bmp.Width, bmp.Height, copy, avgMapSize);

                // Get image smoothness
                float[] smoothnessMap = new float[length];
                ImageProcessing.computeSmoothnessMap(ref smoothnessMap, averageMap, stride, bppModifier, bmp.Width, bmp.Height, copy, smoothness);

                for (int y = 0; y < bmp.Height; y++)
                {
                    // Decide on a direction (left or right)
                    bool dirIsRight = false;
                    float smoothleft = smoothnessMap[y * bmp.Width + (xpos - smoothness)];
                    float smoothright = smoothnessMap[y * bmp.Width + (xpos + smoothness)];
                    dirIsRight = smoothleft < smoothright;

                    // Determine a 'stop'
                   // use avg?
                   //     do it both ways
                    int stopx = xpos;
                    for (int sx = xpos + smoothness; sx < xpos + mergeSize; sx++)
                    {
                        if (smoothnessMap[y * bmp.Width + sx] > stopThreshold)
                        {
                            stopx = sx;
                            break;
                        }
                    }

                    // How many smoothing pixels?
                    int nbPixels = Math.Abs(stopx - xpos);

                    // Make border
                    for (int x = xpos; x != stopx; x += (dirIsRight ? 1 : -1))
                    {
                        // Get x,y color
                        int idx = (y * stride) + x * bppModifier;
                        red = ptr[idx + 2];
                        green = ptr[idx + 1];
                        blue = ptr[idx];

                        // Get merge color (symetry)
                        int symidx = (y * stride) + (x > xpos ? (xpos - (x - xpos)) : xpos + (xpos - x)) * bppModifier;
                        red2 = ptr[symidx + 2];
                        green2 = ptr[symidx + 1];
                        blue2 = ptr[symidx];

                        // Get merge factor f(x)
                        float localPixWeight = (float)Math.Abs((float)x - (float)xpos) / (float)nbPixels;
                        //if (x > xpos) localPixWeight = 1;// 1.0f / localPixWeight;
                        float symPixWeight = 1.0F - localPixWeight;

                        // Merge
                        red = (int)(localPixWeight * (float)red + symPixWeight * (float)red2);
                        green = (int)(localPixWeight * (float)green + symPixWeight * (float)green2);
                        blue = (int)(localPixWeight * (float)blue + symPixWeight * (float)blue2);

                        // Write result
                        ptr[(x * bppModifier) + y * stride] = (byte)blue;
                        ptr[(x * bppModifier) + y * stride + 1] = (byte)green;
                        ptr[(x * bppModifier) + y * stride + 2] = (byte)red;
                    }
                }
            }
        }

        public static void MergeEdgesVertical(ref Bitmap bmp, int xpos, int mergeSize)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int stride = data.Stride;
            int bppModifier = bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb ? 3 : 4;
            int red, green, blue = 0;
            int red2, green2, blue2 = 0;
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = xpos - mergeSize; x < xpos + mergeSize; x++)
                    {
                        // Get x,y color
                        int idx = (y * stride) + x * bppModifier;
                        red = ptr[idx + 2];
                        green = ptr[idx + 1];
                        blue = ptr[idx];

                        // Get merge color (symetry)
                        int symidx = (y * stride) + (x>xpos ? (xpos - (x - xpos)) : xpos+(xpos-x)) * bppModifier;
                        red2 = ptr[symidx + 2];
                        green2 = ptr[symidx + 1];
                        blue2 = ptr[symidx];

                        // Get merge factor f(x)
                        float localPixWeight =  Math.Abs((float)x - (float)xpos) / (float)mergeSize;
                        if (x > xpos) localPixWeight = 1;// 1.0f / localPixWeight;
                        float symPixWeight = 1.0F - localPixWeight;

                        // Merge
                        red = (int)(localPixWeight * (float)red + symPixWeight * (float)red2);
                        green = (int)(localPixWeight * (float)green + symPixWeight * (float)green2);
                        blue = (int)(localPixWeight * (float)blue + symPixWeight * (float)blue2);

                        // Write result
                        ptr[(x * bppModifier) + y * stride] = (byte)blue;
                        ptr[(x * bppModifier) + y * stride + 1] = (byte)green;
                        ptr[(x * bppModifier) + y * stride + 2] = (byte)red;
                    }
                }
            }
        }

        private static void computeAvgMap(ref float[] map, int stride, int bppModifier, int width, int height, byte[] src, int matrixHalfSize)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Get average for pixel x,y
                    float intensity = ImageProcessing.getAvgForPixel(x, y, stride, bppModifier, width, height, src, matrixHalfSize);
                    map[y * width + x] = intensity;
                }
            }
        }

        private static float getAvgForPixel(int x0, int y0, int stride, int bppModifier, int width, int height, byte[] src, int matrixHalfSize)
        {
            float intensity = 0f;
            int count = 0;
            for (int y = y0 - matrixHalfSize; y < y0 + matrixHalfSize; y++)
            {
                for (int x = x0 - matrixHalfSize; x < x0 + matrixHalfSize; x++)
                {
                    if (x < 0 || x >= width || y < 0 || y >= height) continue;
                    count++;

                    // Get x,y color
                    int idx = (y * stride) + x * bppModifier;
                    intensity += (src[idx + 2] + src[idx + 1] + src[idx] )/ 3;
                }
            }

            return intensity / count;
        }

        private static void computeSmoothnessMap(ref float[] map, float[] avgs, int stride, int bppModifier, int width, int height, byte[] src, int matrixHalfSize)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Get smoothness for pixel x,y
                    float avg = avgs[y * width + x];
                    float smt = getSmoothnessForPixel(x, y, avg, stride, bppModifier, width, height, src, matrixHalfSize);
                    map[y * width + x] = smt;
                }
            }
        }

        private static float getSmoothnessForPixel(int x0, int y0, float avg, int stride, int bppModifier, int width, int height, byte[] src, int matrixHalfSize)
        {
            float smoothness = 0f;
            int count = 0;
            for (int y = y0 - matrixHalfSize; y < y0 + matrixHalfSize; y++)
            {
                for (int x = x0 - matrixHalfSize; x < x0 + matrixHalfSize; x++)
                {
                    if (x < 0 || x >= width || y < 0 || y >= height) continue;
                    count++;

                    // Get x,y color
                    int idx = (y * stride) + x * bppModifier;
                    float localIntensity = (src[idx + 2] + src[idx + 1] + src[idx]) / 3;
                    smoothness += Math.Abs(localIntensity - avg);
                }
            }

            return smoothness / count;
        }

        public static void test(ref Bitmap bmp, int avgMapSize, int smoothness, bool showSmoothness)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int stride = data.Stride;
            int bppModifier = bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb ? 3 : 4;
            int red, green, blue = 0;

            // Make a copy
            int length = Math.Abs(data.Stride) * data.Height;
            byte[] copy = new byte[length];
            Marshal.Copy(data.Scan0, copy, 0, copy.Length);

            // Compute average
            float[] averageMap = new float[length];
            ImageProcessing.computeAvgMap(ref averageMap, stride, bppModifier, bmp.Width, bmp.Height, copy, avgMapSize);

            // Get image smoothness
            float[] smoothnessMap = new float[length];
            ImageProcessing.computeSmoothnessMap(ref smoothnessMap, averageMap, stride, bppModifier, bmp.Width, bmp.Height, copy, smoothness);

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int val = showSmoothness ? (int)smoothnessMap[y * bmp.Width + x] :(int)averageMap[y * bmp.Width + x];

                        // Write result
                        ptr[(x * bppModifier) + y * stride] = (byte)val;
                        ptr[(x * bppModifier) + y * stride + 1] = (byte)val;
                        ptr[(x * bppModifier) + y * stride + 2] = (byte)val;
                    }
                }
            }
        }

    }
}
