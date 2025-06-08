namespace KelimeEzberlemeSistemi
{
    partial class FormKelimeListesi
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
            this.flpKelimeler = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpKelimeler
            // 
            this.flpKelimeler.AutoScroll = true;
            this.flpKelimeler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpKelimeler.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpKelimeler.Location = new System.Drawing.Point(0, 0);
            this.flpKelimeler.Name = "flpKelimeler";
            this.flpKelimeler.Size = new System.Drawing.Size(506, 356);
            this.flpKelimeler.TabIndex = 0;
            // 
            // FormKelimeListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(150)))));
            this.ClientSize = new System.Drawing.Size(506, 356);
            this.Controls.Add(this.flpKelimeler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormKelimeListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kelime Listesi";
            this.Load += new System.EventHandler(this.FormKelimeListesi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpKelimeler;
    }
}