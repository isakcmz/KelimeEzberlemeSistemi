using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KelimeEzberlemeSistemi
{
    public partial class FormKayit : Form
    {
        public FormKayit()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {

            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                try
                {
                    baglanti.Open();

                    // Kullanıcı daha önce kayıt olmuş mu kontrol
                    string kontrolSorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kadi";
                    using (SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti))
                    {
                        kontrolKomut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                        int varMi = (int)kontrolKomut.ExecuteScalar();
                        if (varMi > 0)
                        {
                            MessageBox.Show("Bu kullanıcı adı zaten kayıtlı.");
                            return;
                        }
                    }

                    // Kayıt işlemi
                    string ekleSorgu = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre) VALUES (@kadi, @sifre)";
                    using (SqlCommand komut = new SqlCommand(ekleSorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        int sonuc = komut.ExecuteNonQuery();
                        if (sonuc > 0)
                        {
                            MessageBox.Show("✅ Kayıt başarılı. Artık giriş yapabilirsiniz.");
                            this.Close(); // formu kapat
                        }
                        else
                        {
                            MessageBox.Show("❌ Kayıt başarısız.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("⚠ Hata: " + ex.Message);
                }
            }

        }
    }
}
