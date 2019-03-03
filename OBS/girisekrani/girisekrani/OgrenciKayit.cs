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
    public partial class OgrenciKayit : Form
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }

        static string connectionString = @"Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void OgrenciKayit_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = null;
            
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT *FROM bolumm";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["bolum_ad"]);
              
            }
            baglanti.Close();

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (boxİsim.Text == "" || boxSoyisim.Text == "" || boxSifre.Text == "" || boxNO.Text == "" || boxBolumID.Text =="")
            {
                MessageBox.Show("Lütfen eksik kutu bırakmayınız. Alanları doldurunuz. Bölümünüzü seçmeyi unutmayınız.");
            }
            else
            {
                SinifOgrenciGiris islem2 = new SinifOgrenciGiris();
                SinifOgrenci user2 = new SinifOgrenci();
                //islem2 = new SinifOgrenciGiris();
                //user2 = new SinifOgrenci();
                user2.İsim = boxİsim.Text;
                user2.Soyisim = boxSoyisim.Text;
                user2.OgrenciNo = Convert.ToInt64(boxNO.Text);
                user2.Sifre = boxSifre.Text;
                user2.BolumID = Convert.ToInt32(boxBolumID.Text);


                if (islem2.InsertUser(user2))
                {
                    MessageBox.Show("Öğrenci Ekleme işleminiz başarıyla gerçekleşti.");
                }
                else
                {
                    MessageBox.Show("Bu okul numarası ile kayıtlı öğrenci sistemde zaten mevcuttur. Lütfen tekrar deneyiniz.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
