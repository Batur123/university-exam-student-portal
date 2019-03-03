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
    public partial class OgretmenKayit : Form
    {
        public OgretmenKayit()
        {
            InitializeComponent();
        }

        static string connectionString = @"Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void OgretmenKayit_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand();
            SqlDataReader dr2;
            baglanti.Open();
            comboBox1.DataSource = null;
            komut2.CommandText = "SELECT *FROM bolumm";
            komut2.Connection = baglanti;
            komut2.CommandType = CommandType.Text;
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2["bolum_ad"]);
            }
            baglanti.Close();


            //=====================================================
            SqlCommand komut = new SqlCommand();
            SqlDataReader dr;
            baglanti.Open();
            comboBox2.DataSource = null;
            komut.CommandText = "SELECT *FROM OgretmenUnvann";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Unvan"]);
            }
            baglanti.Close();
            //=====================================================

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if(comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen ünvanınızı seçiniz!!!");
            }
            else
            {
                baglanti.Open();
                string kayit = "SELECT * from OgretmenUnvann where Unvan=@unvan1";
                //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@unvan1", comboBox2.SelectedItem);
                //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
                SqlDataAdapter da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
                {

                    boxUnvan.Text = dr["Unvan"].ToString();


                    //Datareader ile okunan verileri form kontrollerine aktardık.
                }
                else
                    MessageBox.Show("Böyle bir bölüm ismi bulunmamaktadır. Bir hata oluştu");
                baglanti.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (boxİsim.Text == "" || boxSoyisim.Text == "" || boxSifre.Text == "" || boxNO.Text == "" || boxBolumID.Text == "" || boxUnvan.Text == "")
            {
                MessageBox.Show("Lütfen eksik kutu bırakmayınız. Alanları doldurunuz. Bölümünüzü ve Ünvanınızı seçmeyi unutmayınız.");
            }
            else
            {
                SinifOgretmenGiris islem = new SinifOgretmenGiris();
                SinifOgretmen user = new SinifOgretmen();
                //islem2 = new SinifOgrenciGiris();
                //user2 = new SinifOgrenci();
                user.İsim = boxİsim.Text;
                user.Soyisim = boxSoyisim.Text;
                user.Sifre = boxSifre.Text;
                user.BolumID = Convert.ToInt32(boxBolumID.Text);
                user.KullaniciAdi = boxNO.Text;
                user.Unvan = boxUnvan.Text;


                if (islem.InsertUser(user))
                {
                    MessageBox.Show("Kayıt işleminiz başarıyla sonuçlandı.");
                }
                else
                {
                    MessageBox.Show("Bu kullanıcı adı ile kayıtlı bir öğretim görevlisi mevcuttur. Lütfen başka kullanıcı adı seçiniz.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bölümünüzü seçiniz!!!");
            }
            else
            {
                baglanti.Open();
                string kayit = "SELECT * from bolumm where bolum_ad=@bolumismi";
                //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@bolumismi", comboBox1.SelectedItem);
                //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
                SqlDataAdapter da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
                {

                    boxBolumID.Text = dr["bolum_id"].ToString();


                    //Datareader ile okunan verileri form kontrollerine aktardık.
                }
                else
                    MessageBox.Show("Böyle bir bölüm ismi bulunmamaktadır. Bir hata oluştu");
                baglanti.Close();
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgretmenGirisEkrani a = new OgretmenGirisEkrani();
            a.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
