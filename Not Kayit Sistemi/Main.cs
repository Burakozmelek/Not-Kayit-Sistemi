using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Kayit_Sistemi
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOgrenciGiris formOgrenciGiris = new FormOgrenciGiris();
            formOgrenciGiris.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormOgretmetGiris form = new FormOgretmetGiris();
            form.Show();
            this.Hide();
        }
    }
}
