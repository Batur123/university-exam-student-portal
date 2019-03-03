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
    public partial class OgretmenDersListele : Form
    {
        public OgretmenDersListele()
        {
            InitializeComponent();
        }

        static string connectionString = @"Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(connectionString);

        private void OgretmenDersListele_Load(object sender, EventArgs e)
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

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgretmenAnaMenu a = new OgretmenAnaMenu();
            a.Show();
            this.Hide();
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
                string kayit = "SELECT * from bolumm where bolum_ad=@bolumismi";
                //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@bolumismi", comboBox1.SelectedItem);
                //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
                SqlDataAdapter da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
                {

                    textBox2.Text = dr["bolum_id"].ToString();


                    //Datareader ile okunan verileri form kontrollerine aktardık.
                }
                else
                    MessageBox.Show("Böyle bir bölüm ismi bulunmamaktadır. Bir hata oluştu");
                baglanti.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Lütfen eksik kısım bırakmayınız. Ders adını yazmayı unutmayınız. ");
            }
            else
            {
                baglanti.Open();
                var command = new SqlCommand("INSERT INTO ders(ders_ad,bolum_id) VALUES('" + textBox1.Text + "','" + Convert.ToInt32(textBox2.Text) + "')");
                command.Connection = baglanti;

                if (command.ExecuteNonQuery() != -1)
                {

                }
                MessageBox.Show("Ders başarıyla eklendi.");
                baglanti.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OgretmenDersEkleme a = new OgretmenDersEkleme();
            a.Show();
            this.Hide();
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
