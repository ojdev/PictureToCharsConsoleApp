using System;
using System.Drawing;
using System.IO;

namespace PictureToCharsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"E:\Pictures\1.png";
            Bitmap bitMap = new(path);
            //var chars = "#8XOHD69&$%)i=xo+;:,. ";
            var chars = "@#*x+/\\o=~-|:. ";
            //var chars = "▄▃▂▁. ";
            //var chars = "@#$xo);:',. ";
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 1, 2);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 2, 4);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 3, 6);
            var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 4, 8);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 5, 10);
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 6, 12); 
            //var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 7, 14);
            File.WriteAllText($"{path}.txt", bmpstr);
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
                    var index = (int)((origalColor.R + origalColor.G + origalColor.B) / 768.0 * chars.Length);
                    bmpstr += chars[index];
                }
                bmpstr += Environment.NewLine;
            }
            return bmpstr;
        }
    }
}
