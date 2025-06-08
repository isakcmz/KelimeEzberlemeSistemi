using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KelimeEzberlemeSistemi
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text;

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAdi = @kadi AND Sifre = @sifre";
                    using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                    {
                        komut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                        komut.Parameters.AddWithValue("@sifre", sifre);

                        int sonuc = (int)komut.ExecuteScalar();

                        if (sonuc > 0)
                        {
                            // Kullanıcı ID'sini al
                            string idSorgu = "SELECT KullaniciID FROM Kullanicilar WHERE KullaniciAdi = @kadi";
                            using (SqlCommand idKomut = new SqlCommand(idSorgu, baglanti))
                            {
                                idKomut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                                Oturum.KullaniciID = (int)idKomut.ExecuteScalar();
                                Oturum.KullaniciAdi = kullaniciAdi;
                            }

                            MessageBox.Show("✅ Giriş başarılı!");

                            FormAnaMenu anaMenu = new FormAnaMenu();
                            anaMenu.Show();
                            this.Hide(); // Giriş ekranını gizle
                        }
                        else
                        {
                            MessageBox.Show("❌ Kullanıcı adı veya şifre hatalı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("⚠ Veritabanı hatası: " + ex.Message);
                }
            }

        }

        private void btnKayitFormu_Click(object sender, EventArgs e)
        {
            FormKayit kayitForm = new FormKayit();
            kayitForm.ShowDialog();
        }

        private void pictureBoxGizleGoster_Click(object sender, EventArgs e)
        {
            if(txtSifre.UseSystemPasswordChar == true)
            {
                
                txtSifre.UseSystemPasswordChar = false;
                toolTip1.SetToolTip(pictureBoxGizleGoster, "Gizle");
            }
            else if (txtSifre.UseSystemPasswordChar == false)
            {
                
                txtSifre.UseSystemPasswordChar = true;
                toolTip1.SetToolTip(pictureBoxGizleGoster, "Göster");
            }
        }

        private void FormGiris_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxGizleGoster, "Göster");
        }

        private void linkLabelSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSifreSifirla sifreForm = new FormSifreSifirla();
            sifreForm.ShowDialog();
        }
    }
}
