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

namespace girisekrani
{
    public partial class OgretmenAnaMenu : Form
    {
        public OgretmenAnaMenu()
        {
            InitializeComponent();
        }

        private void bilgileriduzenlebuton_Click(object sender, EventArgs e)
        {
            OgretmenBilgiPanel a = new OgretmenBilgiPanel();
            a.Show();
            this.Hide();
        }

        private void dersekleclick_MouseClick(object sender, MouseEventArgs e)
        {
            ProgramHakkinda a = new ProgramHakkinda();
            a.Show();
            this.Hide();
        }

        private void ogrenciekleclick_MouseClick(object sender, MouseEventArgs e)
        {
            OgretmenOgrenciEkleme a = new OgretmenOgrenciEkleme();
            a.Show();
            this.Hide();
        }

        private void notgirisiclick_MouseClick(object sender, MouseEventArgs e)
        {
            OgretmenNotGir a = new OgretmenNotGir();
            a.Show();
            this.Hide();
        }

        private void derslisteleclick_MouseClick(object sender, MouseEventArgs e)
        {
            OgretmenDersListele a = new OgretmenDersListele();
            a.Show();
            this.Hide();
        }

        private void ogrencigosterclick_MouseClick(object sender, MouseEventArgs e)
        {
            OgretmenOgrenciGoster a = new OgretmenOgrenciGoster();
            a.Show();
            this.Hide();
        }

        private void devamsizlikclick_MouseClick(object sender, MouseEventArgs e)
        {
            OgretmenDevamsizlik a = new OgretmenDevamsizlik();
            a.Show();
            this.Hide();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

       // static string conString = "Server=BATUR;Initial Catalog=obsdb;Integrated Security=true";
        //public string isim2, soyisim2;

        private void OgretmenAnaMenu_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("https://bozok.edu.tr/duyurular.aspx");
            label8.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
           // isimlabel.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            //label1.BackColor = Color.Transparent;
            //pictureBox1.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            //textBox1.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label9.Text = SinifOgretmenGiris.İsim1 +" "+ SinifOgretmenGiris.Soyisim1;

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

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
            OgretmenGirisEkrani a = new OgretmenGirisEkrani();
            a.Show();
            this.Hide();
        }

        private void derslisteleclick_Click(object sender, EventArgs e)
        {

        }
    }
}
