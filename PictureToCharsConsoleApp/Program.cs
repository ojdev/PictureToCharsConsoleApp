using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace PictureToCharsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"2.jpg";
            Bitmap bitMap = new(path);
            //var chars = "#8XOHD69&$%)i=xo+;:,. ";
            var chars = "@#*+/:. ";
            //var chars = "▄▃▂▁. ";
            //var chars = "@#$xo);:',. ";
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 1, 2);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 2, 4);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 3, 6);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 4, 8);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 5, 10);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 6, 12); 
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 7, 14);
            //File.WriteAllText($"{path}.txt", bmpstr);
            //BitmapExtensions.CharsToBitmap($"{path}.txt", $"{path}.txt.png");
            bitMap.GetCharsBitmap(chars, $"{path}.txt");
            Console.WriteLine("Done");
        }
    }
    public static class BitmapExtensions
    {
        /// <summary>
        /// 灰度
        /// </summary>
        /// <param name="bitMap"></param>
        /// <returns></returns>
        public static Bitmap ToGrayBitmap(this Bitmap bitMap)
        {
            for (int i = 0; i < bitMap.Width; i++)
            {
                for (int j = 0; j < bitMap.Height; j++)
                {
                    var origalColor = bitMap.GetPixel(i, j);
                    var grayScale = (int)(origalColor.R * .299 + origalColor.G * .587 + origalColor.B * .114);
                    var newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    bitMap.SetPixel(i, j, newColor);
                }
            }
            return bitMap;
        }
        /// <summary>
        /// 出字符画
        /// </summary>
        /// <param name="bitMap"></param>
        /// <param name="chars">生成字符画中用到的字符</param>
        /// <param name="stepWidth">影响到“分辨率”</param>
        /// <param name="stepHeight">影响到“分辨率”</param>
        /// <returns></returns>
        public static string GetCharImage(this Bitmap bitMap, string chars, int stepWidth = 1, int stepHeight = 1)
        {
            string bmpstr = string.Empty;
            for (int i = 0; i < bitMap.Height; i += stepHeight)
            {
                for (int j = 0; j < bitMap.Width; j += stepWidth)
                {
                    var origalColor = bitMap.GetPixel(j, i);
                    var index = (int)((origalColor.R + origalColor.G + origalColor.B) / 256.0 * chars.Length);
                    bmpstr += chars[index];
                }
                bmpstr += Environment.NewLine;
            }
            return bmpstr;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitMap"></param>
        /// <param name="chars"></param>
        /// <param name="txtOutPath"></param>
        /// <param name="stepHeight"></param>
        /// <param name="stepWidth"></param>
        /// <param name="fontSize"></param>
        public static void GetCharsBitmap(
            this Bitmap bitMap,
            string chars,
            string txtOutPath,
            int stepHeight = 2,
            int stepWidth = 1,
            int fontSize = 7)
        {
            List<string> allLines = new();
            for (int i = 0; i < bitMap.Height; i += stepHeight)
            {
                string newLineText = string.Empty;
                for (int j = 0; j < bitMap.Width; j += stepWidth)
                {
                    var origalColor = bitMap.GetPixel(j, i);
                    var grayScale = (int)(origalColor.R * .299 + origalColor.G * .587 + origalColor.B * .114);
                    var index = (int)(grayScale / 256.0 * chars.Length);
                    newLineText += chars[index];
                }
                allLines.Add(newLineText);
            }
            File.WriteAllText(txtOutPath, string.Join(Environment.NewLine, allLines));
            using Font drawFont = new("Cascadia Code", fontSize);
            Bitmap image = new(1, 1);
            Graphics g = Graphics.FromImage(image);
            var text = string.Join(Environment.NewLine, allLines);
            SizeF sf = g.MeasureString(text, drawFont, bitMap.Width * fontSize);
            image = new Bitmap(image, new Size(Convert.ToInt32(sf.Width), Convert.ToInt32(sf.Height)));
            g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(text, drawFont, Brushes.Black, new RectangleF(new PointF(0, 0), sf));
            image.Save($"{txtOutPath}.png", System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            image.Dispose();
        }
        public static void CharsToBitmap(string textFile, string saveBitmapPath)
        {
            var fontSize = 7;
            using Font drawFont = new("Cascadia Code", fontSize);
            Bitmap image = new(1, 1);
            Graphics g = Graphics.FromImage(image);
            var allText = File.ReadAllLines(textFile, Encoding.UTF8);
            var text = string.Join(Environment.NewLine, allText);
            SizeF sf = g.MeasureString(text, drawFont, allText[0].Length * fontSize);
            image = new Bitmap(image, new Size(Convert.ToInt32(sf.Width), Convert.ToInt32(sf.Height)));
            g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(text, drawFont, Brushes.Black, new RectangleF(new PointF(0, 0), sf));
            image.Save(saveBitmapPath, System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            image.Dispose();
        }
    }
}
