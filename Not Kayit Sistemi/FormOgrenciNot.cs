﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace Not_Kayit_Sistemi
{
    public partial class FormOgrenciNot : Form
    {
        public FormOgrenciNot()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=Burak\SQLEXPRESS;Initial Catalog=OgrenciNotSistemi;Integrated Security=True;Encrypt=False");
        private void FormOgrenciNot_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERS where OGRNUMARA=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) 
            {
                LblAdSoyad.Text = dr[2].ToString()+" " + dr[3].ToString();
                LblSınav1.Text = dr[4].ToString();
                LblSınav2.Text = dr[5].ToString();
                LblSınav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                LblDurum.Text = dr[8].ToString();

                if (LblDurum.Text == "True")
                {
                    LblDurum.ForeColor = Color.Green;
                    LblDurum.Text = "Geçti";
                }
                else
                {
                    LblDurum.ForeColor = Color.Red;
                    LblDurum.Text = "Kaldı";
                }
                
            }
            baglanti.Close();
        }
    }
}
