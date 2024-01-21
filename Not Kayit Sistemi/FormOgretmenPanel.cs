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
using System.Net.NetworkInformation;

namespace Not_Kayit_Sistemi
{
    public partial class FormOgretmenPanel : Form
    {
        public FormOgretmenPanel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Burak\SQLEXPRESS;Initial Catalog=OgrenciNotSistemi;Integrated Security=True;Encrypt=False");
        private void FormOgretmenPanel_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'ogrenciNotSistemiDataSet.TBLDERS' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLDERSTableAdapter.Fill(this.ogrenciNotSistemiDataSet.TBLDERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", maskedNumara.Text);
            komut.Parameters.AddWithValue("@p2", textBoxAd.Text);
            komut.Parameters.AddWithValue("@p3", textBoxSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ögrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter.Fill(this.ogrenciNotSistemiDataSet.TBLDERS);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            maskedNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBoxAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBoxSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBoxSınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBoxSınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBoxSınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 =Convert.ToDouble(textBoxSınav1.Text);
            s2 = Convert.ToDouble(textBoxSınav2.Text);
            s3 = Convert.ToDouble(textBoxSınav3.Text);

            ortalama = (s1 + s2 + s3) / 3 ;
            LblOrt.Text=ortalama.ToString();

           
            if (ortalama >= 50)
            {
                durum = "True";

            }
            else
            {
                durum ="False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@P1,OGRS2=@P2,OGRs3=@P3,ORTALAMA=@P4,DURUM=@P5 WHERE OGRNUMARA=@P6",baglanti);
            komut.Parameters.AddWithValue("@P1", textBoxSınav1.Text);
            komut.Parameters.AddWithValue("@P2", textBoxSınav2.Text);
            komut.Parameters.AddWithValue("@P3", textBoxSınav3.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(LblOrt.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6", maskedNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi");
            baglanti.Open();
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM TBLDERS WHERE DURUM = 1", baglanti);
            int gecenSayisi = (int)countCommand.ExecuteScalar();

            countCommand.CommandText = "SELECT COUNT(*) FROM TBLDERS WHERE DURUM = 0";
            int kalanSayisi = (int)countCommand.ExecuteScalar();

            // Etiketlere (Labels) sayıları yazdırma
            LblGecen.Text = gecenSayisi.ToString();
            LblKalan.Text = kalanSayisi.ToString();

            baglanti.Close();

            
            this.tBLDERSTableAdapter.Fill(this.ogrenciNotSistemiDataSet.TBLDERS);

           

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
