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
    public partial class FormOgretmetGiris : Form
    {
        public FormOgretmetGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "root" && textBox2.Text == "1001")
            {
               FormOgretmenPanel form = new FormOgretmenPanel();
                form.Show();
                this.Hide();
            }
        }
    }
}
