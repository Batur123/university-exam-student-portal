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
    public partial class OgrenciGirisEkrani : Form
    {
        public OgrenciGirisEkrani()
        {
            InitializeComponent();
        }

        public SinifOgrenci user2;
        public SinifOgrenciGiris islem2;

        private void girisyapbuton_Click(object sender, EventArgs e)
        {
            try
            {
                islem2 = new SinifOgrenciGiris();
                user2 = islem2.getUser(Convert.ToInt64(ogrencino.Text), ogrencisifre.Text);
                if (user2 != null)
                {
                    OgrenciAnaMenu a = new OgrenciAnaMenu();
                    //a.label2.Text = user.İsim.ToString();
                    a.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Öğrenci no veya şifreniz yanlıştır. Lütfen tekrar deneyiniz.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. \n");
                MessageBox.Show(hata.Message);
            }
            
        }

        private void ogrencikayit2_Click(object sender, EventArgs e)
        {
            OgrenciKayit a = new OgrenciKayit();
            a.Show();
            this.Hide();
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SecimEkrani a = new SecimEkrani();
            a.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ProgramHakkinda a = new ProgramHakkinda();
            a.Show();
            this.Hide();
        }

        private void OgrenciGirisEkrani_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
        }

        private void ogrencino_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
