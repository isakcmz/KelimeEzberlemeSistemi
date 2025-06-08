namespace KelimeEzberlemeSistemi
{
    partial class FormWordle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWordle));
            this.txtTahmin = new System.Windows.Forms.TextBox();
            this.btnKontrolEt = new System.Windows.Forms.Button();
            this.flpSonuclar = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTahmin
            // 
            this.txtTahmin.Location = new System.Drawing.Point(106, 126);
            this.txtTahmin.MaxLength = 5;
            this.txtTahmin.Name = "txtTahmin";
            this.txtTahmin.Size = new System.Drawing.Size(221, 22);
            this.txtTahmin.TabIndex = 1;
            // 
            // btnKontrolEt
            // 
            this.btnKontrolEt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKontrolEt.Location = new System.Drawing.Point(157, 159);
            this.btnKontrolEt.Name = "btnKontrolEt";
            this.btnKontrolEt.Size = new System.Drawing.Size(118, 32);
            this.btnKontrolEt.TabIndex = 2;
            this.btnKontrolEt.Text = "Kontrol Et";
            this.btnKontrolEt.UseVisualStyleBackColor = true;
            this.btnKontrolEt.Click += new System.EventHandler(this.btnKontrolEt_Click_1);
            // 
            // flpSonuclar
            // 
            this.flpSonuclar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSonuclar.Location = new System.Drawing.Point(63, 227);
            this.flpSonuclar.Name = "flpSonuclar";
            this.flpSonuclar.Size = new System.Drawing.Size(337, 422);
            this.flpSonuclar.TabIndex = 3;
            this.flpSonuclar.WrapContents = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(145, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormWordle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(447, 661);
            this.Controls.Add(this.flpSonuclar);
            this.Controls.Add(this.btnKontrolEt);
            this.Controls.Add(this.txtTahmin);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormWordle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WORDLE";
            this.Load += new System.EventHandler(this.FormWordle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTahmin;
        private System.Windows.Forms.Button btnKontrolEt;
        private System.Windows.Forms.FlowLayoutPanel flpSonuclar;
    }
}