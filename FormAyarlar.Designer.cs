namespace KelimeEzberlemeSistemi
{
    partial class FormAyarlar
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
            this.lblKelimeSayisi = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.numKelimeSayisi = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numKelimeSayisi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKelimeSayisi
            // 
            this.lblKelimeSayisi.AutoSize = true;
            this.lblKelimeSayisi.Location = new System.Drawing.Point(129, 88);
            this.lblKelimeSayisi.Name = "lblKelimeSayisi";
            this.lblKelimeSayisi.Size = new System.Drawing.Size(135, 16);
            this.lblKelimeSayisi.TabIndex = 0;
            this.lblKelimeSayisi.Text = "Günlük Kelime Sayısı:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(228, 133);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(90, 34);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // numKelimeSayisi
            // 
            this.numKelimeSayisi.Location = new System.Drawing.Point(274, 86);
            this.numKelimeSayisi.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numKelimeSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKelimeSayisi.Name = "numKelimeSayisi";
            this.numKelimeSayisi.Size = new System.Drawing.Size(120, 22);
            this.numKelimeSayisi.TabIndex = 2;
            this.numKelimeSayisi.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // FormAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(506, 249);
            this.Controls.Add(this.numKelimeSayisi);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblKelimeSayisi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAyarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.FormAyarlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numKelimeSayisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKelimeSayisi;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.NumericUpDown numKelimeSayisi;
    }
}