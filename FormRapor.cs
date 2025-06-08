using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace KelimeEzberlemeSistemi
{
    public partial class FormRapor : Form
    {
        private DataTable dtKonuAnaliz;

        public FormRapor()
        {
            InitializeComponent();
        }

        

        private void FormRapor_Load(object sender, EventArgs e)
        {
            VerileriYukle();
            GrafiğiHazirla();

            chart1.BackColor = Color.White;
        }


        private void VerileriYukle()
        {
            using (SqlConnection baglanti = VeriTabani.Baglanti)
            {
                string sorgu = @"
                    SELECT 
                        ISNULL(k.Konu, 'Bilinmeyen') AS Konu,
                        ROUND(CAST(SUM(CASE WHEN c.DogruMu = 1 THEN 1 ELSE 0 END) AS FLOAT) / COUNT(*) * 100, 2) AS BasariYuzdesi
                    FROM Kelimeler k
                    LEFT JOIN KullaniciCevaplari c ON k.KelimeID = c.KelimeID AND c.KullaniciID = @kID
                    GROUP BY k.Konu
                    ORDER BY BasariYuzdesi DESC";

                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@kID", Oturum.KullaniciID);
                SqlDataAdapter adapter = new SqlDataAdapter(komut);
                dtKonuAnaliz = new DataTable();
                adapter.Fill(dtKonuAnaliz);
            }
        }



        private void GrafiğiHazirla()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            ChartArea area = new ChartArea("MainArea");
            chart1.ChartAreas.Add(area);

            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            chart1.Legends.Add(legend);

            Series series = new Series("Başarı Yüzdesi");
            series.ChartType = SeriesChartType.Pie;
            series.ChartArea = "MainArea";
            series.Legend = legend.Name;

            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0:0.00}%";
            series.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Renk paletini buradan değiştirebilirsin:
            Color[] renkler = {
                Color.FromArgb(255, 99, 132),   // Pembe kırmızı
                Color.FromArgb(54, 162, 235),   // Açık mavi
                Color.FromArgb(255, 206, 86),   // Sarı
                Color.FromArgb(75, 192, 192),   // Turkuaz
                Color.FromArgb(153, 102, 255),  // Mor
                Color.FromArgb(255, 159, 64),   // Turuncu - Doğa
                Color.FromArgb(199, 199, 199)
            };

            int renkIndex = 0;

            foreach (DataRow row in dtKonuAnaliz.Rows)
            {
                string konu = row["Konu"].ToString();
                double yuzde = Convert.ToDouble(row["BasariYuzdesi"]);

                DataPoint dp = new DataPoint();
                dp.YValues = new double[] { yuzde };
                dp.Label = $"{yuzde:0.00}%";           // Dilimde sadece yüzde göster
                dp.LegendText = konu;                   // Legend’da sadece konu ismi göster
                dp.Color = renkler[renkIndex % renkler.Length];

                series.Points.Add(dp);
                renkIndex++;
            }

            chart1.Series.Add(series);
        }








        private void btnYazdir_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;

            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }


        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Bitmap bmp = new Bitmap(chart1.Width, chart1.Height))
            {
                chart1.DrawToBitmap(bmp, new Rectangle(0, 0, chart1.Width, chart1.Height));

                // Grafik büyütmek için sayfa genişliğine göre ölçekle
                float scale = Math.Min((float)e.MarginBounds.Width / bmp.Width, (float)e.MarginBounds.Height / bmp.Height);
                int scaledWidth = (int)(bmp.Width * scale);
                int scaledHeight = (int)(bmp.Height * scale);

                e.Graphics.DrawImage(bmp, e.MarginBounds.Left, e.MarginBounds.Top, scaledWidth, scaledHeight);
            }
        }


    }
}
