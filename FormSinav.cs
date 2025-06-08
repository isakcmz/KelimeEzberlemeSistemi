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
    public partial class FormSinav : Form
    {

        private DataTable kelimeListesi; // Sınavda sorulacak kelimeler
        private int soruIndex = 0;        // Hangi soruda olduğumuzu takip eder



        public FormSinav()
        {
            InitializeComponent();
        }






        private void FormSinav_Load(object sender, EventArgs e)
        {
            kelimeListesi = GetOgrenilmemisKelimeler(Oturum.KullaniciID);
            soruIndex = 0;

            if (kelimeListesi.Rows.Count == 0)
            {
                MessageBox.Show("🎉 Tüm kelimeleri öğrendiniz!");
                this.Close();
                return;
            }

            YeniSoruYukle();    
        }


        


        private DataTable GetOgrenilmemisKelimeler(int kullaniciID)
        {
            DataTable dt = new DataTable();
            int limit = KullaniciAyariniGetir();

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                string sorgu = $@"
                    SELECT k.KelimeID, k.IngilizceKelime, k.TurkceKelime
                    FROM Kelimeler k
                    WHERE k.KelimeID NOT IN (
                        SELECT KelimeID
                        FROM OgrenilenKelimeler
                        WHERE KullaniciID = @kullaniciID
                     )
                     ORDER BY NEWID()
                        OFFSET 0 ROWS FETCH NEXT {limit} ROWS ONLY";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    SqlDataAdapter adapter = new SqlDataAdapter(komut);
                    adapter.Fill(dt);
                }
            }

            return dt;
        }


        private int KullaniciAyariniGetir()
        {
            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                string sorgu = "SELECT GunlukKelimeSayisi FROM Ayarlar WHERE KullaniciID = @kID";
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kID", Oturum.KullaniciID);

                    baglanti.Open();
                    object sonuc = komut.ExecuteScalar();

                    return sonuc != null ? Convert.ToInt32(sonuc) : 10; // default 10
                }
            }
        }




        private void YeniSoruYukle()
        {
            // Şıkları temizle
            foreach (var rb in new[] { rbSecenek1, rbSecenek2, rbSecenek3, rbSecenek4 })
            {
                rb.Checked = false;
            }

            if (soruIndex >= kelimeListesi.Rows.Count)
            {
                MessageBox.Show("Bugünkü kelime sınavını tamamladınız!");
                this.Close();
                return;
            }

            DataRow secilen = kelimeListesi.Rows[soruIndex];
            lblKelime.Text = secilen["IngilizceKelime"].ToString();
            lblKelime.Tag = secilen["KelimeID"];
            lblDogruCevap.Tag = secilen["TurkceKelime"];

            TestSecenekleriniGoster(Convert.ToInt32(secilen["KelimeID"]));

            soruIndex++;
        }



        private void btnKontrolEt_Click(object sender, EventArgs e)
        {
            RadioButton[] rbArray = { rbSecenek1, rbSecenek2, rbSecenek3, rbSecenek4 };
            RadioButton secilenRB = rbArray.FirstOrDefault(rb => rb.Checked);

            if (secilenRB == null)
            {
                MessageBox.Show("Lütfen bir seçenek işaretleyin!");
                return;
            }

            bool dogruMu = Convert.ToBoolean(secilenRB.Tag);
            int kelimeID = Convert.ToInt32(lblKelime.Tag);
            string ingKelime = lblKelime.Text;
            string trKelime = lblDogruCevap.Tag.ToString();

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                string sorgu = @"
            INSERT INTO KullaniciCevaplari (KullaniciID, KelimeID, DogruMu, CevapTarihi)
            VALUES (@kullaniciID, @kelimeID, @dogruMu, GETDATE())";

                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kullaniciID", Oturum.KullaniciID);
                    komut.Parameters.AddWithValue("@kelimeID", kelimeID);
                    komut.Parameters.AddWithValue("@dogruMu", dogruMu);

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                }
            }

            if (dogruMu)
            {
                lblSonuc1.Visible = true;
                lblSonuc2.Visible = false;
                lblSonuc1.Text = "✅ Doğru!";
                lblSonuc1.ForeColor = Color.Green;

                OgrenmeKontrolEtVeKaydet(Oturum.KullaniciID, kelimeID, ingKelime, trKelime);
            }
            else
            {
                lblSonuc2.Visible = true;
                lblSonuc1.Visible=false;
                lblSonuc2.Text = $"❌ Yanlış! Doğru cevap: {trKelime}";
                lblSonuc2.ForeColor = Color.Red;
            }

            YeniSoruYukle();
        }





        private void OgrenmeKontrolEtVeKaydet(int kullaniciID, int kelimeID, string ingilizceKelime, string turkceKelime)
        {
            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                baglanti.Open();

                string kontrolSorgu = @"
            SELECT COUNT(*) 
            FROM KullaniciCevaplari 
            WHERE KullaniciID = @kID AND KelimeID = @kelimeID AND DogruMu = 1";

                using (SqlCommand kontrolCmd = new SqlCommand(kontrolSorgu, baglanti))
                {
                    kontrolCmd.Parameters.AddWithValue("@kID", kullaniciID);
                    kontrolCmd.Parameters.AddWithValue("@kelimeID", kelimeID);

                    int dogruSayisi = (int)kontrolCmd.ExecuteScalar();

                    if (dogruSayisi >= 6)
                    {
                        string ekleSorgu = @"
                    IF NOT EXISTS (
                        SELECT * FROM OgrenilenKelimeler 
                        WHERE KullaniciID = @kID AND KelimeID = @kelimeID
                    )
                    INSERT INTO OgrenilenKelimeler 
                    (KullaniciID, KelimeID, IngilizceKelime, TurkceKelime)
                    VALUES (@kID, @kelimeID, @ing, @tr)";

                        using (SqlCommand ekleCmd = new SqlCommand(ekleSorgu, baglanti))
                        {
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







        private void TestSecenekleriniGoster(int kelimeID)
        {
            var (dogruCevap, yanlisCevaplar) = KelimeVeYanlisSecenekleriGetir(kelimeID);

            List<string> tumSecenekler = new List<string>(yanlisCevaplar) { dogruCevap };

            Random rnd = new Random();
            tumSecenekler = tumSecenekler.OrderBy(x => rnd.Next()).ToList();

            RadioButton[] rbArray = { rbSecenek1, rbSecenek2, rbSecenek3, rbSecenek4 };

            for (int i = 0; i < rbArray.Length; i++)
            {
                rbArray[i].Text = tumSecenekler[i];
                rbArray[i].Tag = tumSecenekler[i] == dogruCevap; // doğru mu kontrol için
                rbArray[i].Checked = false;
                rbArray[i].Visible = true;
            }
        }




        private (string dogruCevap, List<string> yanlisCevaplar) KelimeVeYanlisSecenekleriGetir(int kelimeID)
        {
            string dogruCevap = "";
            List<string> yanlisCevaplar = new List<string>();

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                baglanti.Open();

                // Doğru cevabı al
                string dogruSorgu = "SELECT TurkceKelime FROM Kelimeler WHERE KelimeID = @kelimeID";
                using (SqlCommand cmd = new SqlCommand(dogruSorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@kelimeID", kelimeID);
                    dogruCevap = cmd.ExecuteScalar()?.ToString() ?? "";
                }

                // 3 farklı yanlış cevabı al
                string yanlisSorgu = @"
            SELECT TOP 3 TurkceKelime FROM Kelimeler
            WHERE KelimeID != @kelimeID
            ORDER BY NEWID()";

                using (SqlCommand cmd = new SqlCommand(yanlisSorgu, baglanti))
                {
                    cmd.Parameters.AddWithValue("@kelimeID", kelimeID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yanlisCevaplar.Add(reader["TurkceKelime"].ToString());
                        }
                    }
                }
            }

            return (dogruCevap, yanlisCevaplar);
        }




    }
}
