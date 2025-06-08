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
using System.Media;


namespace KelimeEzberlemeSistemi
{
    public partial class FormWordle : Form
    {
        private string hedefKelime = "";
        private int tahminSayisi = 0;
        private int maxHak = 5;

        public FormWordle()
        {
            InitializeComponent();
        }

        private void FormWordle_Load(object sender, EventArgs e)
        {
            hedefKelime = RastgeleOgrenilenKelimeGetir(); // veritabanından çek
            txtTahmin.MaxLength = 5;
            txtTahmin.CharacterCasing = CharacterCasing.Lower;
            txtTahmin.Focus();
        }

        private void btnKontrolEt_Click_1(object sender, EventArgs e)
        {
            string tahmin = txtTahmin.Text.Trim().ToLower();

            if (tahmin.Length != 5)
            {
                MessageBox.Show("Lütfen 5 harfli bir kelime girin.");
                return;
            }

            if (tahminSayisi >= maxHak)
            {
                MessageBox.Show("Tahmin hakkınız kalmadı!");
                return;
            }

            char[] hedef = hedefKelime.ToCharArray();
            char[] girilen = tahmin.ToCharArray();
            Color[] kutuRenkleri = new Color[5];
            bool[] hedefKullanildi = new bool[5];

            // 1. Geçiş: doğru yer
            for (int i = 0; i < 5; i++)
            {
                if (girilen[i] == hedef[i])
                {
                    kutuRenkleri[i] = Color.Green;
                    hedefKullanildi[i] = true;
                }
            }

            // 2. Geçiş: yanlış yer ama mevcut olanlar
            for (int i = 0; i < 5; i++)
            {
                if (kutuRenkleri[i] == Color.Green)
                    continue;

                bool bulundu = false;
                for (int j = 0; j < 5; j++)
                {
                    if (!hedefKullanildi[j] && girilen[i] == hedef[j])
                    {
                        bulundu = true;
                        hedefKullanildi[j] = true;
                        break;
                    }
                }

                kutuRenkleri[i] = bulundu ? Color.Gold : Color.DimGray;
            }

            // Satırı oluştur
            FlowLayoutPanel satir = new FlowLayoutPanel();
            satir.Width = 300;
            satir.Height = 50;
            satir.Margin = new Padding(5);
            satir.FlowDirection = FlowDirection.LeftToRight;

            for (int i = 0; i < 5; i++)
            {
                Label harfKutu = new Label();
                harfKutu.Width = 45;
                harfKutu.Height = 45;
                harfKutu.Margin = new Padding(2);
                harfKutu.TextAlign = ContentAlignment.MiddleCenter;
                harfKutu.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                harfKutu.Text = girilen[i].ToString().ToUpper();
                harfKutu.BackColor = kutuRenkleri[i];
                harfKutu.ForeColor = Color.White;

                satir.Controls.Add(harfKutu);
            }

            flpSonuclar.Controls.Add(satir);
            tahminSayisi++;

            if (tahmin == hedefKelime)
            {
                MessageBox.Show("🎉 Tebrikler! Doğru tahmin ettiniz.");
                btnKontrolEt.Enabled = false;
            }
            else if (tahminSayisi >= maxHak)
            {
                MessageBox.Show($"❌ Hakkınız bitti. Doğru kelime: {hedefKelime.ToUpper()}");
                btnKontrolEt.Enabled = false;
            }

            txtTahmin.Clear();
            txtTahmin.Focus();
        }

        private string RastgeleOgrenilenKelimeGetir()
        {
            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                string sorgu = @"
                            SELECT IngilizceKelime
                            FROM OgrenilenKelimeler
                            WHERE KullaniciID = @kID AND LEN(IngilizceKelime) = 5";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();

                List<string> kelimeler = new List<string>();
                while (reader.Read())
                    kelimeler.Add(reader["IngilizceKelime"].ToString().ToLower());

                if (kelimeler.Count == 0)
                {
                    MessageBox.Show("Henüz öğrenilen 5 harfli kelimeniz yok. Varsayılan olarak 'apple' seçildi.");
                    return "apple";
                }

                Random rnd = new Random();
                return kelimeler[rnd.Next(kelimeler.Count)];
            }
        }




        private void OgrenmeKontrolEtVeKaydet(int kullaniciID, int kelimeID, string ingilizceKelime, string turkceKelime)
        {
            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                // 1. Bu kelime için doğru sayısını al
                string kontrolSorgu = @"
            SELECT COUNT(*) 
            FROM KullaniciCevaplari 
            WHERE KullaniciID = @kID AND KelimeID = @kelimeID AND DogruMu = 1";
                SqlCommand kontrolCmd = new SqlCommand(kontrolSorgu, baglanti);
                kontrolCmd.Parameters.AddWithValue("@kID", kullaniciID);
                kontrolCmd.Parameters.AddWithValue("@kelimeID", kelimeID);

                baglanti.Open();
                int dogruSayisi = (int)kontrolCmd.ExecuteScalar();

                // 2. Eğer tam 6 doğru varsa ve daha önce eklenmemişse → ekle
                if (dogruSayisi == 6)
                {
                    string ekleSorgu = @"
                IF NOT EXISTS (
                    SELECT * FROM OgrenilenKelimeler 
                    WHERE KullaniciID = @kID AND KelimeID = @kelimeID
                )
                INSERT INTO OgrenilenKelimeler 
                (KullaniciID, KelimeID, IngilizceKelime, TurkceKelime)
                VALUES (@kID, @kelimeID, @ing, @tr)";

                    SqlCommand ekleCmd = new SqlCommand(ekleSorgu, baglanti);
                    ekleCmd.Parameters.AddWithValue("@kID", kullaniciID);
                    ekleCmd.Parameters.AddWithValue("@kelimeID", kelimeID);
                    ekleCmd.Parameters.AddWithValue("@ing", ingilizceKelime);
                    ekleCmd.Parameters.AddWithValue("@tr", turkceKelime);
                    ekleCmd.ExecuteNonQuery();
                }
            }
        }


    }
}
