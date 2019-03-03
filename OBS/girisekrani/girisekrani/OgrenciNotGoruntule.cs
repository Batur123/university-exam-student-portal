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
    public partial class OgrenciNotGoruntule : Form
    {
        public OgrenciNotGoruntule()
        {
            InitializeComponent();
        }

        static string conString = "Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=TRUE;MultipleActiveResultSets=True";
        SqlConnection baglanti = new SqlConnection(conString);
        

        private void OgrenciNotGoruntule_Load(object sender, EventArgs e)
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

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;

            ogrencino.Text = SinifOgrenciGiris.OgrenciNo1.ToString();
        }

        private void arabuton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT * from ogrenci_not where ogrenci_no=@ogrencinoo";
            //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@ogrencinoo", ogrencino.Text);
            //komut.Parameters.AddWithValue("@dersid", textBox1.Text);
            //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
            {

                ogrenciad.Text = dr["ogrenci_no"].ToString();
               // matvize.Text = dr["vize"].ToString();
               // matfinal.Text = dr["final"].ToString();
              //  matbut.Text = dr["butunleme"].ToString();
               // matort.Text = dr["ortalama"].ToString();

                //Datareader ile okunan verileri form kontrollerine aktardık.
            }
            else
                MessageBox.Show("Böyle bir öğrenci bulunmamaktadır.");
            baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }

        private void notverbuton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null || ogrenciad.Text =="" || textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Ders seçim kısmını boş bırakmayınız. Eğer butona tıkladığınızda not gelmiyorsa notunuz daha girilmemiş demektir.");
            }
            else
            {
                baglanti.Open();
                string kayit = "SELECT * from ogrenci_not where ders_id=@dersadi and ogrenci_no=@ogrencino";
                //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@dersadi", textBox1.Text);
                komut.Parameters.AddWithValue("@ogrencino", ogrenciad.Text);
                //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
                SqlDataAdapter da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
                {

                    matvize.Text = dr["vize"].ToString();
                    matfinal.Text = dr["final"].ToString();
                    matbut.Text = dr["butunleme"].ToString();
                    matort.Text = dr["ortalama"].ToString();




                    //Datareader ile okunan verileri form kontrollerine aktardık.
                }
                else
                    MessageBox.Show("Bilinmeyen bir not görüntüleme hatası oluştu?");
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Lütfen Ders seçim kısmını boş bırakmayınız.");
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

        private void temizlebuton_Click(object sender, EventArgs e)
        {
            matbut.Clear();
            matfinal.Clear();
            matvize.Clear();
            matort.Clear();
            textBox1.Clear();

            foreach (Control item in this.Controls)
            {
               
                if (item is ComboBox)
                    item.ResetText();
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
    }
}
    

