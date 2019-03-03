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
    public partial class OgretmenDersEkleme : Form
    {
        public OgretmenDersEkleme()
        {
            InitializeComponent();
        }

        static string connectionString = @"Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void OgretmenDersEkleme_Load(object sender, EventArgs e)
        {    

            SqlCommand komut2 = new SqlCommand();
            SqlDataReader dr2;
            baglanti.Open();
            comboBox1.DataSource = null;
            komut2.CommandText = "SELECT *FROM ders";
            komut2.Connection = baglanti;
            komut2.CommandType = CommandType.Text;
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2["ders_ad"]);
            }
            baglanti.Close();

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Lütfen Bölüm kısmını boş bırakmayınız.");
            }
            else
            {
                baglanti.Open();
                string kayit = "SELECT * from ders where ders_ad=@dersadi";
                //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@dersadi", comboBox1.SelectedItem);
                //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
                SqlDataAdapter da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
                {

                    textBox1.Text = dr["ders_id"].ToString();


                    //Datareader ile okunan verileri form kontrollerine aktardık.
                }
                else
                    MessageBox.Show("Böyle bir ders ismi bulunmamaktadır. Bir hata oluştu");
                baglanti.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text is null)
            {
                MessageBox.Show("Lütfen ders seçim kısmını boş bırakmayınız.");
            }
            else
            {
                baglanti.Open();
                string kayit = "SELECT * from ogretim_gorevlisi where ogretim_kullanici=@ogretimno";
                //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@ogretimno",textBox3.Text);
               


                //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
                SqlDataAdapter da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
                {

                    textBox2.Text = dr["ogretim_id"].ToString();


                    //Datareader ile okunan verileri form kontrollerine aktardık.
                }
                else
                    MessageBox.Show("Bu kullanıcı adına kayıtlı bir öğretim üyesi bulunmamaktadır. Lütfen doğru yazdığınıza emin olun.");
                baglanti.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş alan bırakmayınız!!!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string kayit = "update ders set ogretim_id=@ogretimid2 where ders_id=@dersno";
                    // ogretmenn tablomuzun ilgili alanlarını değiştirecek olan güncelleme sorgusu.
                    SqlCommand komut = new SqlCommand(kayit, baglanti);
                    //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                    komut.Parameters.AddWithValue("@dersno", Convert.ToInt32(textBox1.Text));
                    komut.Parameters.AddWithValue("@ogretimid2", Convert.ToInt32(textBox2.Text));
                    //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                    komut.ExecuteNonQuery();
                    //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                    baglanti.Close();
                    MessageBox.Show("Ekleme işlemi başarıyla tamamlandı.");
                }
                catch (Exception Hata)
                {
                    MessageBox.Show("Bir hata oluştu? \n " + Hata);
                }
            }
          
             
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgretmenAnaMenu a = new OgretmenAnaMenu();
            a.Show();
            this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            OgretmenDersListele a = new OgretmenDersListele();
            a.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
