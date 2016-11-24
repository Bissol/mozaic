﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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

        public static void MergeEdgesVertical(ref Bitmap bmp, int xpos, int mergeSize)
        {
            BitmapData data = bmp.LockBits(new Rectangle(xpos - mergeSize, 0, 2 * mergeSize, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int stride = data.Stride;
            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < 2 * mergeSize; x++)
                    {
                        // Get current color
                        // Get merge color (symetry)
                        // Get merge factor f(x)
                        // Merge
                        // Write result
                        ptr[(x * 3) + y * stride] = 0;
                        ptr[(x * 3) + y * stride + 1] =0;
                        ptr[(x * 3) + y * stride + 2] = 0;
                    }
                }
            }
        }
    }
}
