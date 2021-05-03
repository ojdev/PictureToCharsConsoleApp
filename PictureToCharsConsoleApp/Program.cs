using System;
using System.Drawing;
using System.IO;

namespace PictureToCharsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bitMap = new(@"E:\Pictures\avatar.jpeg");
            var chars = "#8XOHD69&$%)i=xo+;:,. ";
            //var chars = "xo. ";
            var bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars);
            //bmpstr = bitMap.ToGrayBitmap().GetCharImage(chars, 6, 12);
            File.WriteAllText(@"E:\Pictures\avatar.txt", bmpstr);
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
                    var grayScale = (int)(origalColor.R * .3 + origalColor.G * .59 + origalColor.B * .11);
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
