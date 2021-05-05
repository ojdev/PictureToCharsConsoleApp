
namespace PictureToCharsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openImageButton = new System.Windows.Forms.Button();
            this.oPicture = new System.Windows.Forms.PictureBox();
            this.dPicture = new System.Windows.Forms.PictureBox();
            this.tranButton = new System.Windows.Forms.Button();
            this.txtChars = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fontSizeNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.oPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png|BMP|*.bmp|TIFF|*.tif;*.tiff";
            this.openFileDialog.Title = "选择图片";
            // 
            // openImageButton
            // 
            this.openImageButton.Location = new System.Drawing.Point(12, 16);
            this.openImageButton.Name = "openImageButton";
            this.openImageButton.Size = new System.Drawing.Size(184, 43);
            this.openImageButton.TabIndex = 0;
            this.openImageButton.Text = "第一步：选择图片";
            this.openImageButton.UseVisualStyleBackColor = true;
            this.openImageButton.Click += new System.EventHandler(this.openImageButton_Click);
            // 
            // oPicture
            // 
            this.oPicture.Location = new System.Drawing.Point(202, 16);
            this.oPicture.Name = "oPicture";
            this.oPicture.Size = new System.Drawing.Size(720, 720);
            this.oPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.oPicture.TabIndex = 1;
            this.oPicture.TabStop = false;
            // 
            // dPicture
            // 
            this.dPicture.Location = new System.Drawing.Point(928, 16);
            this.dPicture.Name = "dPicture";
            this.dPicture.Size = new System.Drawing.Size(720, 720);
            this.dPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dPicture.TabIndex = 2;
            this.dPicture.TabStop = false;
            // 
            // tranButton
            // 
            this.tranButton.Location = new System.Drawing.Point(12, 197);
            this.tranButton.Name = "tranButton";
            this.tranButton.Size = new System.Drawing.Size(184, 42);
            this.tranButton.TabIndex = 3;
            this.tranButton.Text = "开始生成";
            this.tranButton.UseVisualStyleBackColor = true;
            this.tranButton.Click += new System.EventHandler(this.tranButton_Click);
            // 
            // txtChars
            // 
            this.txtChars.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChars.Location = new System.Drawing.Point(48, 110);
            this.txtChars.Name = "txtChars";
            this.txtChars.Size = new System.Drawing.Size(148, 23);
            this.txtChars.TabIndex = 4;
            this.txtChars.Text = "MNHQ$OC?7>!:-;. ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 245);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(184, 22);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "第二步：输入生成画的字符";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "第三步：输入生成画的字号";
            // 
            // fontSizeNumber
            // 
            this.fontSizeNumber.Location = new System.Drawing.Point(125, 168);
            this.fontSizeNumber.Name = "fontSizeNumber";
            this.fontSizeNumber.Size = new System.Drawing.Size(71, 23);
            this.fontSizeNumber.TabIndex = 9;
            this.fontSizeNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fontSizeNumber.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1655, 743);
            this.Controls.Add(this.fontSizeNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtChars);
            this.Controls.Add(this.tranButton);
            this.Controls.Add(this.dPicture);
            this.Controls.Add(this.oPicture);
            this.Controls.Add(this.openImageButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择图片";
            ((System.ComponentModel.ISupportInitialize)(this.oPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button openImageButton;
        private System.Windows.Forms.PictureBox oPicture;
        private System.Windows.Forms.PictureBox dPicture;
        private System.Windows.Forms.Button tranButton;
        private System.Windows.Forms.TextBox txtChars;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown fontSizeNumber;
    }
}

