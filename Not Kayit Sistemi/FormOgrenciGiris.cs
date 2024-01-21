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
    public partial class FormOgrenciGiris : Form
    {
        public FormOgrenciGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOgrenciNot form = new FormOgrenciNot();
            form.numara = maskedTextBox1.Text;
            form.Show();
            
        }

    }
}
