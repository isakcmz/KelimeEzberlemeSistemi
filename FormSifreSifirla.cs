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
    public partial class FormSifreSifirla : Form
    {
        public FormSifreSifirla()
        {
            InitializeComponent();
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string yeniSifre = txtYeniSifre.Text;
            string yeniSifreTekrar = txtYeniSifreTekrar.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(yeniSifreTekrar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (yeniSifre != yeniSifreTekrar)
            {
                MessageBox.Show("Şifreler aynı olmalıdır.");
                return;
            }

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                try
                {
                    baglanti.Open();

                    // Kullanıcı var mı kontrolü
                    string kontrolSorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kadi";
                    using (SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti))
                    {
                        kontrolKomut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                        int varMi = (int)kontrolKomut.ExecuteScalar();
                        if (varMi == 0)
                        {
                            MessageBox.Show("Böyle bir kullanıcı bulunamadı.");
                            return;
                        }
                    }

                    // Şifre güncelle
                    string guncelleSorgu = "UPDATE Kullanicilar SET Sifre = @sifre WHERE KullaniciAdi = @kadi";
                    using (SqlCommand guncelleKomut = new SqlCommand(guncelleSorgu, baglanti))
                    {
                        guncelleKomut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                        guncelleKomut.Parameters.AddWithValue("@sifre", yeniSifre);

                        int sonuc = guncelleKomut.ExecuteNonQuery();
                        if (sonuc > 0)
                        {
                            MessageBox.Show("✅ Şifre başarıyla güncellendi.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("❌ Şifre güncellenemedi.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
