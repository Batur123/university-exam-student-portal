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
    public partial class OgrenciDevamsizlik : Form
    {
        public OgrenciDevamsizlik()
        {
            InitializeComponent();
        }

        static string conString = "Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=TRUE;MultipleActiveResultSets=True";
        SqlConnection baglanti = new SqlConnection(conString);

        private void arabuton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT * from ogrenci where ogrenci_no=@ogrencino";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@ogrencino", Convert.ToInt64(ogrencino.Text));
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                ogrenciad.Text = dr["ad"].ToString();
                ogrencisoyad.Text = dr["soyad"].ToString();
                //  progdevamsizlik.Text = dr["ProgDevamsizlik"].ToString();
                // matdevamsizlik.Text = dr["MatDevamsizlik"].ToString();
                //  ndpdevamsizlik.Text = dr["NdpDevamsizlik"].ToString();
                //  fizikdevamsizlik.Text = dr["FizikDevamsizlik"].ToString();
            }
            else
            {
                MessageBox.Show("Böyle bir öğrenci bulunmamaktadır.");

            }
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void OgrenciDevamsizlikGoruntule_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            SqlDataReader dr;
            baglanti.Open();
            comboBox1.DataSource = null;
            komut.CommandText = "SELECT *FROM ders";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["ders_ad"]);
            }
            baglanti.Close();

            label1.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label8.ForeColor = Color.White;

            label1.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;

            ogrencino.Text = SinifOgrenciGiris.OgrenciNo1.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Ders seçmediniz veya olmayan bir ders yazmaya çalıştınız. Lütfen tekrar deneyiniz.");
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
                {
                    MessageBox.Show("Böyle bir ders ismi bulunmamaktadır. Bir hata oluştu");
                }
                baglanti.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrenciAnaMenu a = new OgrenciAnaMenu();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT * from Devamsizlik where ogrenci_no=@ogno and ders_id=@dersid1";
            //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@dersid1", textBox1.Text);
            komut.Parameters.AddWithValue("@ogno", Convert.ToInt64(ogrencino.Text));
            //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
            {

                textBox2.Text = dr["devamsizlik"].ToString();


            }
            baglanti.Close();
        }
    }
}
