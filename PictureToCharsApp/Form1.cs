using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PictureToCharsApp
{
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void openImageButton_Click(object sender, EventArgs e)
        {
            oPicture.Image = null;
            dPicture.Image = null;
            progressBar1.Value = 0;
            var r = openFileDialog.ShowDialog(this);
            if (DialogResult.OK == r)
            {
                path = openFileDialog.FileName;
                oPicture.Image = new Bitmap(path);
            }
        }

        private void tranButton_Click(object sender, EventArgs e)
        {
            GetCharsBitmap(txtChars.Text, fontSize: (int)fontSizeNumber.Value);
        }

        public void GetCharsBitmap(
           string chars,
           int stepHeight = 2,
           int stepWidth = 1,
           int fontSize = 7)
        {
            Bitmap bitMap = new(path);
            List<string> allLines = new();
            progressBar1.Maximum = (bitMap.Height / stepHeight) + 1;
            progressBar1.Value = 0;
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
                this.Invoke(new Action(() => { progressBar1.Value++; }));
            }
            File.WriteAllText($"{path}.txt", string.Join(Environment.NewLine, allLines));
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
            image.Save($"{path}.txt.png", System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            image.Dispose();
            dPicture.Image = new Bitmap($"{path}.txt.png");
        }
    }
}
