using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelimeEzberlemeSistemi
{
    public partial class FormKelimeEkle : Form
    {
        public FormKelimeEkle()
        {
            InitializeComponent();
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosyaSec = new OpenFileDialog();
            dosyaSec.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            if (dosyaSec.ShowDialog() == DialogResult.OK)
            {
                txtResimYolu.Text = dosyaSec.FileName;
            }
        }

        private void btnSesSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosyaSec = new OpenFileDialog();
            dosyaSec.Filter = "Ses Dosyaları|*.mp3;*.wav";
            if (dosyaSec.ShowDialog() == DialogResult.OK)
            {
                txtSesYolu.Text = dosyaSec.FileName;
            }
        }

        private void btnKelimeEkle_Click(object sender, EventArgs e)
        {
            string engKelime = txtIngilizceKelime.Text.Trim();
            string trKelime = txtTurkceKelime.Text.Trim();
            string ornekCumle = txtOrnekCumle.Text.Trim();
            string resimYolu = txtResimYolu.Text;
            string sesYolu = txtSesYolu.Text;

            if (string.IsNullOrEmpty(engKelime) || string.IsNullOrEmpty(trKelime))
            {
                MessageBox.Show("Lütfen zorunlu alanları doldurun.");
                return;
            }

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                try
                {
                    baglanti.Open();

                    // 1. Kelimeyi ekle
                    string kelimeEkleSorgu = @"
                INSERT INTO Kelimeler (IngilizceKelime, TurkceKelime, ResimYolu, SesYolu) 
                OUTPUT INSERTED.KelimeID 
                VALUES (@eng, @tr, @resim, @ses)";

                    SqlCommand kelimeKomut = new SqlCommand(kelimeEkleSorgu, baglanti);
                    kelimeKomut.Parameters.AddWithValue("@eng", engKelime);
                    kelimeKomut.Parameters.AddWithValue("@tr", trKelime);
                    kelimeKomut.Parameters.AddWithValue("@resim", resimYolu);
                    kelimeKomut.Parameters.AddWithValue("@ses", sesYolu);

                    int yeniKelimeID = (int)kelimeKomut.ExecuteScalar(); // eklenen kelimenin ID'si

                    // 2. Örnek cümleyi ekle
                    if (!string.IsNullOrEmpty(ornekCumle))
                    {
                        string ornekSorgu = "INSERT INTO KelimeOrnekleri (KelimeID, OrnekCumle) VALUES (@kelimeID, @cumle)";
                        SqlCommand ornekKomut = new SqlCommand(ornekSorgu, baglanti);
                        ornekKomut.Parameters.AddWithValue("@kelimeID", yeniKelimeID);
                        ornekKomut.Parameters.AddWithValue("@cumle", ornekCumle);
                        ornekKomut.ExecuteNonQuery();
                    }

                    MessageBox.Show("✅ Kelime başarıyla eklendi.");

                    // Alanları temizle
                    txtIngilizceKelime.Clear();
                    txtTurkceKelime.Clear();
                    txtOrnekCumle.Clear();
                    txtResimYolu.Clear();
                    txtSesYolu.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
