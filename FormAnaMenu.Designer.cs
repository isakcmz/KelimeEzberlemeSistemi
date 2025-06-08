namespace KelimeEzberlemeSistemi
{
    partial class FormAnaMenu
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
            this.components = new System.ComponentModel.Container();
            this.lblHosgeldin = new System.Windows.Forms.Label();
            this.btnKelimeEkle = new System.Windows.Forms.Button();
            this.btnSinav = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.btnAnaliz = new System.Windows.Forms.Button();
            this.pictureBoxCikisYap = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnKelimeListesi = new System.Windows.Forms.Button();
            this.btnWordle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCikisYap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.AutoSize = true;
            this.lblHosgeldin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHosgeldin.Location = new System.Drawing.Point(149, 50);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(235, 36);
            this.lblHosgeldin.TabIndex = 0;
            this.lblHosgeldin.Text = "HOŞ GELDİNİZ";
            // 
            // btnKelimeEkle
            // 
            this.btnKelimeEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKelimeEkle.Location = new System.Drawing.Point(46, 150);
            this.btnKelimeEkle.Name = "btnKelimeEkle";
            this.btnKelimeEkle.Size = new System.Drawing.Size(140, 70);
            this.btnKelimeEkle.TabIndex = 1;
            this.btnKelimeEkle.Text = "Kelime Ekle";
            this.btnKelimeEkle.UseVisualStyleBackColor = true;
            this.btnKelimeEkle.Click += new System.EventHandler(this.btnKelimeEkle_Click);
            // 
            // btnSinav
            // 
            this.btnSinav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSinav.Location = new System.Drawing.Point(235, 150);
            this.btnSinav.Name = "btnSinav";
            this.btnSinav.Size = new System.Drawing.Size(140, 70);
            this.btnSinav.TabIndex = 2;
            this.btnSinav.Text = "Sınav";
            this.btnSinav.UseVisualStyleBackColor = true;
            this.btnSinav.Click += new System.EventHandler(this.btnSinav_Click);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAyarlar.Location = new System.Drawing.Point(424, 150);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(140, 70);
            this.btnAyarlar.TabIndex = 3;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.UseVisualStyleBackColor = true;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // btnAnaliz
            // 
            this.btnAnaliz.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnaliz.Location = new System.Drawing.Point(424, 246);
            this.btnAnaliz.Name = "btnAnaliz";
            this.btnAnaliz.Size = new System.Drawing.Size(140, 70);
            this.btnAnaliz.TabIndex = 4;
            this.btnAnaliz.Text = "Analiz";
            this.btnAnaliz.UseVisualStyleBackColor = true;
            this.btnAnaliz.Click += new System.EventHandler(this.btnAnaliz_Click);
            // 
            // pictureBoxCikisYap
            // 
            this.pictureBoxCikisYap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCikisYap.Image = global::KelimeEzberlemeSistemi.Properties.Resources.logout_512;
            this.pictureBoxCikisYap.Location = new System.Drawing.Point(546, 12);
            this.pictureBoxCikisYap.Name = "pictureBoxCikisYap";
            this.pictureBoxCikisYap.Size = new System.Drawing.Size(44, 44);
            this.pictureBoxCikisYap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCikisYap.TabIndex = 5;
            this.pictureBoxCikisYap.TabStop = false;
            this.pictureBoxCikisYap.Click += new System.EventHandler(this.pictureBoxCikisYap_Click);
            // 
            // btnKelimeListesi
            // 
            this.btnKelimeListesi.Location = new System.Drawing.Point(46, 246);
            this.btnKelimeListesi.Name = "btnKelimeListesi";
            this.btnKelimeListesi.Size = new System.Drawing.Size(140, 70);
            this.btnKelimeListesi.TabIndex = 6;
            this.btnKelimeListesi.Text = "📋 Kelimeleri Görüntüle";
            this.btnKelimeListesi.UseVisualStyleBackColor = true;
            this.btnKelimeListesi.Click += new System.EventHandler(this.btnKelimeListesi_Click);
            // 
            // btnWordle
            // 
            this.btnWordle.Location = new System.Drawing.Point(235, 246);
            this.btnWordle.Name = "btnWordle";
            this.btnWordle.Size = new System.Drawing.Size(140, 70);
            this.btnWordle.TabIndex = 7;
            this.btnWordle.Text = "🧩 Wordle Oyna";
            this.btnWordle.UseVisualStyleBackColor = true;
            this.btnWordle.Click += new System.EventHandler(this.btnWordle_Click);
            // 
            // FormAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(602, 403);
            this.Controls.Add(this.btnWordle);
            this.Controls.Add(this.btnKelimeListesi);
            this.Controls.Add(this.pictureBoxCikisYap);
            this.Controls.Add(this.btnAnaliz);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnSinav);
            this.Controls.Add(this.btnKelimeEkle);
            this.Controls.Add(this.lblHosgeldin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAnaMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Menü";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAnaMenu_FormClosing);
            this.Load += new System.EventHandler(this.FormAnaMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCikisYap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHosgeldin;
        private System.Windows.Forms.Button btnKelimeEkle;
        private System.Windows.Forms.Button btnSinav;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Button btnAnaliz;
        private System.Windows.Forms.PictureBox pictureBoxCikisYap;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnKelimeListesi;
        private System.Windows.Forms.Button btnWordle;
    }
}