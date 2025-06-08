namespace KelimeEzberlemeSistemi
{
    partial class FormAnaliz
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
            this.lblToplamDogru = new System.Windows.Forms.Label();
            this.lblToplamYanlis = new System.Windows.Forms.Label();
            this.lblOgrenilenKelime = new System.Windows.Forms.Label();
            this.dgvEnCokYanlislar = new System.Windows.Forms.DataGridView();
            this.btnYenile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOgrenilenKelimeler = new System.Windows.Forms.DataGridView();
            this.btnRapor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnCokYanlislar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOgrenilenKelimeler)).BeginInit();
            this.SuspendLayout();
            // 
            // lblToplamDogru
            // 
            this.lblToplamDogru.AutoSize = true;
            this.lblToplamDogru.Location = new System.Drawing.Point(128, 71);
            this.lblToplamDogru.Name = "lblToplamDogru";
            this.lblToplamDogru.Size = new System.Drawing.Size(105, 16);
            this.lblToplamDogru.TabIndex = 0;
            this.lblToplamDogru.Text = "lblToplamDogru";
            // 
            // lblToplamYanlis
            // 
            this.lblToplamYanlis.AutoSize = true;
            this.lblToplamYanlis.Location = new System.Drawing.Point(128, 103);
            this.lblToplamYanlis.Name = "lblToplamYanlis";
            this.lblToplamYanlis.Size = new System.Drawing.Size(105, 16);
            this.lblToplamYanlis.TabIndex = 1;
            this.lblToplamYanlis.Text = "lblToplamYanlis";
            // 
            // lblOgrenilenKelime
            // 
            this.lblOgrenilenKelime.AutoSize = true;
            this.lblOgrenilenKelime.Location = new System.Drawing.Point(128, 174);
            this.lblOgrenilenKelime.Name = "lblOgrenilenKelime";
            this.lblOgrenilenKelime.Size = new System.Drawing.Size(120, 16);
            this.lblOgrenilenKelime.TabIndex = 2;
            this.lblOgrenilenKelime.Text = "lblOgrenilenKelime";
            // 
            // dgvEnCokYanlislar
            // 
            this.dgvEnCokYanlislar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEnCokYanlislar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnCokYanlislar.Location = new System.Drawing.Point(131, 412);
            this.dgvEnCokYanlislar.Name = "dgvEnCokYanlislar";
            this.dgvEnCokYanlislar.ReadOnly = true;
            this.dgvEnCokYanlislar.RowHeadersWidth = 51;
            this.dgvEnCokYanlislar.RowTemplate.Height = 24;
            this.dgvEnCokYanlislar.Size = new System.Drawing.Size(588, 167);
            this.dgvEnCokYanlislar.TabIndex = 3;
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(12, 12);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(90, 33);
            this.btnYenile.TabIndex = 4;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Yanlış Öğrenilen Kelimeler:";
            // 
            // dgvOgrenilenKelimeler
            // 
            this.dgvOgrenilenKelimeler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOgrenilenKelimeler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOgrenilenKelimeler.Location = new System.Drawing.Point(131, 193);
            this.dgvOgrenilenKelimeler.Name = "dgvOgrenilenKelimeler";
            this.dgvOgrenilenKelimeler.ReadOnly = true;
            this.dgvOgrenilenKelimeler.RowHeadersWidth = 51;
            this.dgvOgrenilenKelimeler.RowTemplate.Height = 24;
            this.dgvOgrenilenKelimeler.Size = new System.Drawing.Size(588, 150);
            this.dgvOgrenilenKelimeler.TabIndex = 6;
            // 
            // btnRapor
            // 
            this.btnRapor.Location = new System.Drawing.Point(705, 12);
            this.btnRapor.Name = "btnRapor";
            this.btnRapor.Size = new System.Drawing.Size(90, 33);
            this.btnRapor.TabIndex = 7;
            this.btnRapor.Text = "Rapor";
            this.btnRapor.UseVisualStyleBackColor = true;
            this.btnRapor.Click += new System.EventHandler(this.btnRapor_Click);
            // 
            // FormAnaliz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(167)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(807, 651);
            this.Controls.Add(this.btnRapor);
            this.Controls.Add(this.dgvOgrenilenKelimeler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.dgvEnCokYanlislar);
            this.Controls.Add(this.lblOgrenilenKelime);
            this.Controls.Add(this.lblToplamYanlis);
            this.Controls.Add(this.lblToplamDogru);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAnaliz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analiz";
            this.Load += new System.EventHandler(this.FormAnaliz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnCokYanlislar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOgrenilenKelimeler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToplamDogru;
        private System.Windows.Forms.Label lblToplamYanlis;
        private System.Windows.Forms.Label lblOgrenilenKelime;
        private System.Windows.Forms.DataGridView dgvEnCokYanlislar;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOgrenilenKelimeler;
        private System.Windows.Forms.Button btnRapor;
    }
}