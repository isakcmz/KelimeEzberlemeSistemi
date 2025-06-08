namespace KelimeEzberlemeSistemi
{
    partial class FormGiris
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
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnKayitFormu = new System.Windows.Forms.Button();
            this.pictureBoxGizleGoster = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabelSifremiUnuttum = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGizleGoster)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(155, 154);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(82, 16);
            this.lblKullaniciAdi.TabIndex = 0;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new System.Drawing.Point(155, 203);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(37, 16);
            this.lblSifre.TabIndex = 1;
            this.lblSifre.Text = "Şifre:";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.AccessibleName = "";
            this.txtKullaniciAdi.Location = new System.Drawing.Point(253, 148);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(226, 22);
            this.txtKullaniciAdi.TabIndex = 2;
            this.txtKullaniciAdi.Tag = "";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(253, 197);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(226, 22);
            this.txtSifre.TabIndex = 3;
            this.txtSifre.Tag = "";
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // btnGiris
            // 
            this.btnGiris.BackColor = System.Drawing.Color.SeaGreen;
            this.btnGiris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiris.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGiris.Location = new System.Drawing.Point(286, 253);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(143, 48);
            this.btnGiris.TabIndex = 4;
            this.btnGiris.Text = "Giriş Yap";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btnKayitFormu
            // 
            this.btnKayitFormu.BackColor = System.Drawing.Color.OrangeRed;
            this.btnKayitFormu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKayitFormu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKayitFormu.Location = new System.Drawing.Point(312, 307);
            this.btnKayitFormu.Name = "btnKayitFormu";
            this.btnKayitFormu.Size = new System.Drawing.Size(85, 35);
            this.btnKayitFormu.TabIndex = 5;
            this.btnKayitFormu.Text = "Kayıt Ol";
            this.btnKayitFormu.UseVisualStyleBackColor = false;
            this.btnKayitFormu.Click += new System.EventHandler(this.btnKayitFormu_Click);
            // 
            // pictureBoxGizleGoster
            // 
            this.pictureBoxGizleGoster.AccessibleName = "";
            this.pictureBoxGizleGoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGizleGoster.Image = global::KelimeEzberlemeSistemi.Properties.Resources.hide;
            this.pictureBoxGizleGoster.Location = new System.Drawing.Point(485, 197);
            this.pictureBoxGizleGoster.Name = "pictureBoxGizleGoster";
            this.pictureBoxGizleGoster.Size = new System.Drawing.Size(32, 27);
            this.pictureBoxGizleGoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGizleGoster.TabIndex = 6;
            this.pictureBoxGizleGoster.TabStop = false;
            this.pictureBoxGizleGoster.Tag = "Göster";
            this.pictureBoxGizleGoster.Click += new System.EventHandler(this.pictureBoxGizleGoster_Click);
            // 
            // linkLabelSifremiUnuttum
            // 
            this.linkLabelSifremiUnuttum.AutoSize = true;
            this.linkLabelSifremiUnuttum.Location = new System.Drawing.Point(305, 222);
            this.linkLabelSifremiUnuttum.Name = "linkLabelSifremiUnuttum";
            this.linkLabelSifremiUnuttum.Size = new System.Drawing.Size(99, 16);
            this.linkLabelSifremiUnuttum.TabIndex = 7;
            this.linkLabelSifremiUnuttum.TabStop = true;
            this.linkLabelSifremiUnuttum.Text = "Şifremi Unuttum";
            this.linkLabelSifremiUnuttum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSifremiUnuttum_LinkClicked);
            // 
            // FormGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(187)))), ((int)(((byte)(175)))));
            this.ClientSize = new System.Drawing.Size(673, 421);
            this.Controls.Add(this.linkLabelSifremiUnuttum);
            this.Controls.Add(this.pictureBoxGizleGoster);
            this.Controls.Add(this.btnKayitFormu);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblKullaniciAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.FormGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGizleGoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnKayitFormu;
        private System.Windows.Forms.PictureBox pictureBoxGizleGoster;
        public System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabelSifremiUnuttum;
    }
}