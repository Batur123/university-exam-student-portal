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
    public partial class OgretmenOgrenciEkleme : Form
    {
        public OgretmenOgrenciEkleme()
        {
            InitializeComponent();
        }

        public SinifOgrenci user2;
        public SinifOgrenciGiris islem2;
        public SqlConnection baglanti;
       

        private void kaydetbuton_Click(object sender, EventArgs e)
        {

         
               
                if (isimbox.Text == "" || soyisimbox.Text == "" || ogrsifrebox.Text == "" || nobox.Text == "")
                {
                    MessageBox.Show("Lütfen eksik kutu bırakmayınız. Alanları doldurunuz. Eğer öğrenci silme işlemi yapmak istiyorsanız butona tıklamayı unutmayınız.");
                }
                else
                {
                    islem2 = new SinifOgrenciGiris();
                    user2 = new SinifOgrenci();
                    user2.İsim = isimbox.Text;
                    user2.Soyisim = soyisimbox.Text;
                    user2.OgrenciNo = Convert.ToInt64(nobox.Text);
                    user2.Sifre = ogrsifrebox.Text;


                    if (islem2.InsertUser(user2))
                    {
                        MessageBox.Show("Öğrenci Ekleme işleminiz başarıyla gerçekleşti.");
                    }
                    else
                    {
                        MessageBox.Show("Bu okul numarası ile kayıtlı öğrenci sistemde zaten mevcuttur. Lütfen tekrar deneyiniz.");
                    }

                }
            
           

            KayitSonrasiTemizleme(this);

        }

        private void KayitSonrasiTemizleme(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    KayitSonrasiTemizleme(c);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgretmenAnaMenu a = new OgretmenAnaMenu();
            a.Show();
            this.Hide();
        }

        private void OgretmenOgrenciEkleme_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;

            checkBox1.ForeColor = Color.White;
            checkBox1.BackColor = Color.Transparent;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                isimbox.ReadOnly = true;
                soyisimbox.ReadOnly = true;
                ogrsifrebox.ReadOnly = true;
                isimbox.Clear();
                soyisimbox.Clear();
                ogrsifrebox.Clear();

            }
            else
            {
                isimbox.ReadOnly = false;
                soyisimbox.ReadOnly = false;
                ogrsifrebox.ReadOnly = false;
                isimbox.Clear();
                soyisimbox.Clear();
                ogrsifrebox.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if(nobox.Text == "")
                {
                    MessageBox.Show("Öğrenci numarası kısmı boş bırakılamaz!!!");
                }
                else
                {
                    try
                    {
                        baglanti = new SqlConnection("Data Source=BATUR; Initial Catalog=OBSVeritabani; Integrated Security=true");
                        SqlCommand cmd = new SqlCommand("DELETE FROM ogrenci WHERE ogrenci_no=@ogno", baglanti);
                        cmd.Parameters.AddWithValue("@ogno", Convert.ToInt64(nobox.Text));
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                        }
                        cmd.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Silindi.");
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Hata olustu:   " + hata);
                    }
                }
             
            }
            else
            {
                MessageBox.Show("Öğrenci silme işlemi için lütfen kontrol tikine tıklayınız!!!");
            }
            
        }

        private void nobox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void isimbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void soyisimbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgretmenAnaMenu a = new OgretmenAnaMenu();
            a.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}