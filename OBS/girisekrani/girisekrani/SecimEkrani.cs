using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace girisekrani
{
    public partial class SecimEkrani : Form
    {
        public SecimEkrani()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void ogretmenimbuton_Click(object sender, EventArgs e)
        {
            OgretmenGirisEkrani a = new OgretmenGirisEkrani();
            a.Show();
            this.Hide();
        }

        private void ogrenciyimbuton_Click(object sender, EventArgs e)
        {
            OgrenciGirisEkrani a = new OgrenciGirisEkrani();
            a.Show();
            this.Hide();
        }

        private void SecimEkrani_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
