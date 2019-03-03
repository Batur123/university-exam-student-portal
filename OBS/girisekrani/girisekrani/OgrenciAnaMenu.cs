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
    public partial class OgrenciAnaMenu : Form
    {
        public OgrenciAnaMenu()
        {
            InitializeComponent();
        }

        private void notbuton_Click(object sender, EventArgs e)
        {
            OgrenciNotGoruntule a = new OgrenciNotGoruntule();
            a.Show();
            this.Hide();
        }

        private void dersbuton_Click(object sender, EventArgs e)
        {
            OgrenciBilgiPanel a = new OgrenciBilgiPanel();
            a.Show();
            this.Hide();
        }

 
        private void devambuton_Click(object sender, EventArgs e)
        {
            OgrenciDevamsizlik a = new OgrenciDevamsizlik();
            a.Show();
            this.Hide();
        }

        private void ogrlistebuton_Click(object sender, EventArgs e)
        {
            OgrenciOgretmenListesi a = new OgrenciOgretmenListesi();
            a.Show();
            this.Hide();
        }

        private void OgrenciAnaMenu_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("https://bozok.edu.tr/duyurular.aspx");
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label2.Text = SinifOgrenciGiris.İsim1 + " " + SinifOgrenciGiris.Soyisim1;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrenciGirisEkrani a = new OgrenciGirisEkrani();
            a.Show();
            this.Hide();
        }
    }
}
