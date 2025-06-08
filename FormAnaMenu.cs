using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelimeEzberlemeSistemi
{
    public partial class FormAnaMenu : Form
    {
        public FormAnaMenu()
        {
            InitializeComponent();
        }

        private void FormAnaMenu_Load(object sender, EventArgs e)
        {
            lblHosgeldin.Text = "Hoş geldiniz, " + Oturum.KullaniciAdi + "!";
            toolTip1.SetToolTip(pictureBoxCikisYap, "Çıkış Yap");
        }

        private void btnKelimeEkle_Click(object sender, EventArgs e)
        {
            FormKelimeEkle form = new FormKelimeEkle();
            form.ShowDialog();
        }

        private void btnSinav_Click(object sender, EventArgs e)
        {
            FormSinav form = new FormSinav();
            form.ShowDialog();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            FormAyarlar form = new FormAyarlar();
            form.ShowDialog();
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            FormAnaliz form = new FormAnaliz();
            form.ShowDialog();
        }

        private void pictureBoxCikisYap_Click(object sender, EventArgs e)
        {
            // Oturumu temizle
            Oturum.KullaniciID = 0;
            Oturum.KullaniciAdi = null;

            // Giriş ekranına dön
            FormGiris giris = new FormGiris();
            giris.Show();
            this.Close(); // mevcut formu kapat
        }

        private void btnKelimeListesi_Click(object sender, EventArgs e)
        {
            FormKelimeListesi form = new FormKelimeListesi();
            form.ShowDialog();
        }

        private void btnWordle_Click(object sender, EventArgs e)
        {
            FormWordle form = new FormWordle();
            form.ShowDialog();
        }

        private void FormAnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
