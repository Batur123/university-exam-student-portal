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
    public partial class OgretmenGirisEkrani : Form
    {
        public OgretmenGirisEkrani()
        {
            InitializeComponent();
        }

        public SinifOgretmen user;
        public SinifOgretmenGiris islem;

        private void OgretmenGirisEkrani_Load(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
        }

        private void ogretmenkayit2_Click(object sender, EventArgs e)
        {
            OgretmenKayit a = new OgretmenKayit();
            a.Show();
            this.Hide();
        }

        private void girisyapbuton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ogrencino.Text == "" || ogrencisifre.Text == "")
                {
                    MessageBox.Show("Lütfen boş alan bırakmayınız!!!");
                }
                else
                {
                    
                        islem = new SinifOgretmenGiris();
                        user = islem.getUser(ogrencino.Text, ogrencisifre.Text);
                        if (user != null)
                        {

                            OgretmenAnaMenu a = new OgretmenAnaMenu();
                            OgretmenBilgiPanel b = new OgretmenBilgiPanel();
                            // a.textBox2.Text = "Sayın " + user.Unvan.ToString();
                            a.label9.Text = user.İsim.ToString() + " " + user.Soyisim.ToString();
                            a.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Öğretmen Kullanıcı adı veya şifreyi yanlış girdiniz. Lütfen tekrar deneyiniz.");
                        }

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. \n");
                MessageBox.Show(hata.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SecimEkrani a = new SecimEkrani();
            a.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ProgramHakkinda a = new ProgramHakkinda();
            a.Show();
            this.Hide();
        }
    }
}
