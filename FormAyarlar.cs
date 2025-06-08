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
    public partial class FormAyarlar : Form
    {
        public FormAyarlar()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int kelimeSayisi = (int)numKelimeSayisi.Value;

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                baglanti.Open();

                // Kullanıcının ayarı zaten var mı?
                string kontrol = "SELECT COUNT(*) FROM Ayarlar WHERE KullaniciID = @kID";
                SqlCommand komutKontrol = new SqlCommand(kontrol, baglanti);
                komutKontrol.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                int varMi = (int)komutKontrol.ExecuteScalar();

                if (varMi > 0)
                {
                    // varsa güncelle
                    string guncelle = "UPDATE Ayarlar SET GunlukKelimeSayisi = @sayi WHERE KullaniciID = @kID";
                    SqlCommand guncelleKomut = new SqlCommand(guncelle, baglanti);
                    guncelleKomut.Parameters.AddWithValue("@sayi", kelimeSayisi);
                    guncelleKomut.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                    guncelleKomut.ExecuteNonQuery();
                }
                else
                {
                    // yoksa yeni ekle
                    string ekle = "INSERT INTO Ayarlar (KullaniciID, GunlukKelimeSayisi) VALUES (@kID, @sayi)";
                    SqlCommand ekleKomut = new SqlCommand(ekle, baglanti);
                    ekleKomut.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                    ekleKomut.Parameters.AddWithValue("@sayi", kelimeSayisi);
                    ekleKomut.ExecuteNonQuery();
                }

                MessageBox.Show("Ayar başarıyla kaydedildi!");
            }
        }

        private void FormAyarlar_Load(object sender, EventArgs e)
        {
            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                string sorgu = "SELECT GunlukKelimeSayisi FROM Ayarlar WHERE KullaniciID = @kID";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kID", Oturum.KullaniciID);

                baglanti.Open();
                object sonuc = komut.ExecuteScalar();

                if (sonuc != null)
                {
                    numKelimeSayisi.Value = Convert.ToInt32(sonuc);
                }
            }
        }
    }
}
