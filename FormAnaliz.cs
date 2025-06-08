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
    public partial class FormAnaliz : Form
    {
        public FormAnaliz()
        {
            InitializeComponent();
        }

        private void FormAnaliz_Load(object sender, EventArgs e)
        {
            AnalizVerileriniYukle();
            OgrenilenKelimeleriGetir();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            AnalizVerileriniYukle();
        }



        private void AnalizVerileriniYukle()
        {
            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                baglanti.Open();

                // Toplam doğru
                string dogruSorgu = "SELECT COUNT(*) FROM KullaniciCevaplari WHERE KullaniciID = @kID AND DogruMu = 1";
                SqlCommand cmdDogru = new SqlCommand(dogruSorgu, baglanti);
                cmdDogru.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                lblToplamDogru.Text = "Toplam Doğru: " + cmdDogru.ExecuteScalar().ToString();

                // Toplam yanlış
                string yanlisSorgu = "SELECT COUNT(*) FROM KullaniciCevaplari WHERE KullaniciID = @kID AND DogruMu = 0";
                SqlCommand cmdYanlis = new SqlCommand(yanlisSorgu, baglanti);
                cmdYanlis.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                lblToplamYanlis.Text = "Toplam Yanlış: " + cmdYanlis.ExecuteScalar().ToString();

                // Öğrenilen kelimeler (6 doğru)
                string ogrSorgu = "SELECT COUNT(*) FROM OgrenilenKelimeler WHERE KullaniciID = @kID";
                SqlCommand cmdOgrenilen = new SqlCommand(ogrSorgu, baglanti);
                cmdOgrenilen.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                lblOgrenilenKelime.Text = "Öğrenilen Kelime Sayısı: " + cmdOgrenilen.ExecuteScalar().ToString();

                // En çok yanlış yapılan kelimeler
                string yanlisKelimeSorgu = @"
            SELECT TOP 10 k.IngilizceKelime, COUNT(*) AS YanlisSayisi
            FROM KullaniciCevaplari c
            INNER JOIN Kelimeler k ON c.KelimeID = k.KelimeID
            WHERE c.KullaniciID = @kID AND DogruMu = 0
            GROUP BY k.IngilizceKelime
            ORDER BY YanlisSayisi DESC";
                SqlCommand cmdYanlisKelimeler = new SqlCommand(yanlisKelimeSorgu, baglanti);
                cmdYanlisKelimeler.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmdYanlisKelimeler);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvEnCokYanlislar.DataSource = dt;
            }
        }





        private void OgrenilenKelimeleriGetir()
        {
            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                string sorgu = @"
            SELECT IngilizceKelime AS [İngilizce], 
                   TurkceKelime AS [Türkçe], 
                   OgrenmeTarihi AS [Öğrenme Tarihi]
            FROM OgrenilenKelimeler
            WHERE KullaniciID = @kID
            ORDER BY OgrenmeTarihi DESC";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvOgrenilenKelimeler.DataSource = dt;
            }
        }


        private void btnRapor_Click(object sender, EventArgs e)
        {
            FormRapor raporForm = new FormRapor();
            raporForm.ShowDialog();
        }
    }
}
