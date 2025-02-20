// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Drawing.Imaging;
using System.Text;

namespace ScratchProject
{
    internal static class Program
    {
        private const PixelFormat PixFormat = PixelFormat.Format32bppArgb;
        private const int DIP = 96;
        private const int ImageWidthDIP = 480;
        private const int ImageHeightDIP = 480;
        private const int CharsCount = 16;

        [STAThread]
        private static void Main()
        {
            RunBitmapComparison();
        }

        private static void RunBitmapComparison()
        {
            try
            {
                var fontNames = GetFontNames();
                var bitmap1 = RenderBitmap(96, fontNames);
                var bitmap2 = RenderBitmap(144, fontNames);
                CompareBitmaps(bitmap1, bitmap2);
            }
            catch (Exception exc)
            {
                Console.WriteLine("EXCEPTION: " + exc.Message);
            }
        }

        private static void CompareBitmaps(Bitmap bitmap1, Bitmap bitmap2)
        {
            long totalImageCompareCount = 1;
            long totalImageFailCount = 0;
            long totalPixelCompareCount = 0;
            long totalPixelFailCount = 0;

            var xPixels = bitmap1.Width;
            var yPixels = bitmap1.Height;
            var bitmapData1 = bitmap1.LockBits(new Rectangle(0, 0, xPixels, yPixels), ImageLockMode.ReadOnly, PixFormat);
            var bitmapData2 = bitmap2.LockBits(new Rectangle(0, 0, xPixels, yPixels), ImageLockMode.ReadOnly, PixFormat);
            var pixelData1 = new byte[bitmapData1.Stride];
            var pixelData2 = new byte[bitmapData2.Stride];
            bool areDifferent = false;

            for (int y = 0; y < yPixels; y++)
            {
                System.Runtime.InteropServices.Marshal.Copy(bitmapData1.Scan0 + (y * bitmapData1.Stride), pixelData1, 0, bitmapData1.Stride);
                System.Runtime.InteropServices.Marshal.Copy(bitmapData2.Scan0 + (y * bitmapData2.Stride), pixelData2, 0, bitmapData2.Stride);
                for (int x = 0; x < xPixels; x++)
                {
                    totalPixelCompareCount++;
                    if (GetPixel(pixelData1, x) != GetPixel(pixelData2, x))
                    {
                        totalPixelFailCount++;
                        if (!areDifferent)
                        {
                            totalImageFailCount++;
                            areDifferent = true;
                        }
                    }
                }
            }

            bitmap1.UnlockBits(bitmapData1);
            bitmap2.UnlockBits(bitmapData2);

            MessageBox.Show($"Images Compared: {totalImageCompareCount}\nImages Failed: {totalImageFailCount}\nPixels Compared: {totalPixelCompareCount}\nPixels Failed: {totalPixelFailCount}");
        }

        private static int GetPixel(byte[] pixelData, int pixelOffset)
        {
            const int PixelWidth = 4;
            return
                (pixelData[pixelOffset * PixelWidth + 3] << 24) +  // A
                (pixelData[pixelOffset * PixelWidth + 2] << 16) +  // R
                (pixelData[pixelOffset * PixelWidth + 1] << 8) +   // G
                pixelData[pixelOffset * PixelWidth];               // B
        }

        private static Bitmap RenderBitmap(int dpi, List<string> fontNames)
        {
            var width = ImageWidthDIP * dpi / DIP;
            var height = ImageHeightDIP * dpi / DIP;
            var bitmap = new Bitmap(width, height, PixFormat);
            var sb = new StringBuilder();
            bitmap.SetResolution(dpi, dpi);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.FillRectangle(SystemBrushes.Window, 0, 0, width, height);
                var fontName = fontNames[0];
                using (var font = new Font(fontName, 11))
                {
                    sb.Length = 0;
                    for (int i = 0; i < CharsCount; i++)
                    {
                        sb.Append('A');
                    }

                    var text = sb.ToString();
                    g.DrawString(text, font, SystemBrushes.WindowText, 10, 10, StringFormat.GenericTypographic);
                }
            }

            return bitmap;
        }

        private static List<string> GetFontNames()
        {
            return new List<string> { "Arial" };
        }
    }
}
