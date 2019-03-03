namespace girisekrani
{
    partial class SecimEkrani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecimEkrani));
            this.ogretmenimbuton = new System.Windows.Forms.Button();
            this.ogrenciyimbuton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ogretmenimbuton
            // 
            this.ogretmenimbuton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ogretmenimbuton.Location = new System.Drawing.Point(213, 238);
            this.ogretmenimbuton.Name = "ogretmenimbuton";
            this.ogretmenimbuton.Size = new System.Drawing.Size(239, 39);
            this.ogretmenimbuton.TabIndex = 0;
            this.ogretmenimbuton.Text = "Öğretim Görevlisiyim";
            this.ogretmenimbuton.UseVisualStyleBackColor = true;
            this.ogretmenimbuton.Click += new System.EventHandler(this.ogretmenimbuton_Click);
            // 
            // ogrenciyimbuton
            // 
            this.ogrenciyimbuton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ogrenciyimbuton.Location = new System.Drawing.Point(213, 283);
            this.ogrenciyimbuton.Name = "ogrenciyimbuton";
            this.ogrenciyimbuton.Size = new System.Drawing.Size(239, 39);
            this.ogrenciyimbuton.TabIndex = 1;
            this.ogrenciyimbuton.Text = "Öğrenciyim";
            this.ogrenciyimbuton.UseVisualStyleBackColor = true;
            this.ogrenciyimbuton.Click += new System.EventHandler(this.ogrenciyimbuton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(244, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // SecimEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::girisekrani.Properties.Resources._2ujl5cl;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(657, 342);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ogrenciyimbuton);
            this.Controls.Add(this.ogretmenimbuton);
            this.MaximizeBox = false;
            this.Name = "SecimEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SecimEkrani";
            this.Load += new System.EventHandler(this.SecimEkrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ogretmenimbuton;
        private System.Windows.Forms.Button ogrenciyimbuton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}