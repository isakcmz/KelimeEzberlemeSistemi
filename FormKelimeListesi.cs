using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;
using System.IO;

namespace KelimeEzberlemeSistemi
{
    public partial class FormKelimeListesi : Form
    {
        public FormKelimeListesi()
        {
            InitializeComponent();
        }

        private void FormKelimeListesi_Load(object sender, EventArgs e)
        {
            KelimeleriYukle();
        }


        private void KelimeleriYukle()
        {
            flpKelimeler.Controls.Clear();

            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                string sorgu = @"
            SELECT k.KelimeID, k.IngilizceKelime, k.TurkceKelime, k.ResimYolu, k.SesYolu, ko.OrnekCumle
            FROM Kelimeler k
            LEFT JOIN KelimeOrnekleri ko ON k.KelimeID = ko.KelimeID";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();

                while (reader.Read())
                {
                    // Panel kartı
                    Panel kart = new Panel();
                    kart.Width = 300;
                    kart.Height = 250;
                    kart.BorderStyle = BorderStyle.FixedSingle;
                    kart.Margin = new Padding(10);
                    kart.BackColor = Color.WhiteSmoke;

                    // İngilizce kelime
                    Label lblEng = new Label();
                    lblEng.Text = "🔤 " + reader["IngilizceKelime"].ToString();
                    lblEng.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lblEng.AutoSize = true;

                    // Türkçe anlam
                    Label lblTr = new Label();
                    lblTr.Text = "🇹🇷 " + reader["TurkceKelime"].ToString();
                    lblTr.AutoSize = true;

                    // Örnek cümle
                    Label lblCumle = new Label();
                    lblCumle.Text = "💬 " + reader["OrnekCumle"]?.ToString();
                    lblCumle.AutoSize = true;
                    lblCumle.MaximumSize = new Size(280, 50);

                    // Resim
                    PictureBox pic = new PictureBox();
                    pic.Width = 80;
                    pic.Height = 80;
                    pic.SizeMode = PictureBoxSizeMode.Zoom;

                    string resimYolu = reader["ResimYolu"].ToString();
                    try
                    {
                        if (File.Exists(resimYolu))
                            pic.Image = new Bitmap(resimYolu); // daha güvenli
                    }
                    catch
                    {
                        pic.Image = null; // dosya bozuksa boş geç
                    }


                    // Ses butonu
                    Button btnSes = new Button();
                    btnSes.Text = "🔊";
                    btnSes.Tag = reader["SesYolu"].ToString();
                    btnSes.Width = 40;
                    btnSes.Height = 30;
                    btnSes.Click += (s, e) =>
                    {
                        try
                        {
                            string yol = (string)((Button)s).Tag;
                            if (File.Exists(yol))
                            {
                                SoundPlayer player = new SoundPlayer(yol);
                                player.Play();
                            }
                            else
                            {
                                MessageBox.Show("Ses dosyası bulunamadı:\n" + yol);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ses çalınırken hata oluştu:\n" + ex.Message);
                        }
                    };

                    // Konumlandır
                    lblEng.Location = new Point(10, 10);
                    lblTr.Location = new Point(10, 35);
                    lblCumle.Location = new Point(10, 60);
                    pic.Location = new Point(10, 110);
                    btnSes.Location = new Point(100, 140);

                    // Eklemeler
                    kart.Controls.Add(lblEng);
                    kart.Controls.Add(lblTr);
                    kart.Controls.Add(lblCumle);
                    kart.Controls.Add(pic);
                    kart.Controls.Add(btnSes);

                    flpKelimeler.Controls.Add(kart);
                }
            }
        }
    }
}
