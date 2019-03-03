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
    public partial class OgretmenDevamsizlik : Form
    {
        public OgretmenDevamsizlik()
        {
            InitializeComponent();
        }

        static string conString = "Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=TRUE;MultipleActiveResultSets=True";
        SqlConnection baglanti = new SqlConnection(conString);



        private void OgretmenDevamsizlik_Load(object sender, EventArgs e)
        {


            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label10.ForeColor = Color.White;

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

           
        }






        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bozok.edu.tr/");
        }



        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                    item.ResetText();
                if (item is ComboBox)
                    item.ResetText();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Lütfen Ders kısmını boş bırakmayınız.");
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

                    dersidtext.Text = dr["ders_id"].ToString();


                    //Datareader ile okunan verileri form kontrollerine aktardık.
                }
                else
                    MessageBox.Show("Böyle bir ders ismi bulunmamaktadır. Bir hata oluştu");
                baglanti.Close();
            }
        }

        private void arabuton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT * from ogrenci where ogrenci_no=@ogrenci_no1";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@ogrenci_no1", ogrencino.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {

                ogrenciad.Text = dr["ad"].ToString() + " " + dr["soyad"].ToString();
                //ogrencisoyad.Text = dr["soyad"].ToString();


            }
            else
            {
                MessageBox.Show("Böyle bir öğrenci bulunmamaktadır.");

            }
            baglanti.Close();
        }





        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                if (devamsizliktext.Text == "" || dersidtext.Text == "" || ogrenciad.Text == "" || ogrencino.Text == "")
                {
                    MessageBox.Show("Lütfen eksik kutu bırakmayınız. Öğrenci numarasını doğru yazdığınızdan ve bölümünüzü seçtiğinizden emin olunuz.");
                }
                else
                {
                    if (Convert.ToInt32(devamsizliktext.Text) < 0 || Convert.ToInt32(devamsizliktext.Text) > 10)
                    {
                        MessageBox.Show("Değer negatif veya 10 dan büyük olmamalıdır!!!");
                        devamsizliktext.Text = "";
                        devamsizliktext.Focus();
                    }
                    else
                    {
                        var kayit3 = new SqlCommand("SELECT *FROM Devamsizlik WHERE ders_id='" + Convert.ToInt64(dersidtext.Text) + "'and ogrenci_no='" + Convert.ToInt64(ogrencino.Text) + "'");
                        //var command = new SqlCommand("SELECT *FROM Users WHERE Name='" + user.Name + "' and Password='" + user.Password + "'");
                        kayit3.Connection = baglanti;
                        baglanti.Open();
                        using (var reader = kayit3.ExecuteReader())

                            if (reader.Read())
                            {
                                string kayit = "update Devamsizlik set ogrenci_no=@ogno,devamsizlik=@devam1 where ogrenci_no=@ogrencino and ders_id=@dersid"; //,ders_id=@dersid 
                                SqlCommand komut2 = new SqlCommand(kayit, baglanti);
                                komut2.Parameters.AddWithValue("@ogno", Convert.ToInt64(ogrencino.Text));
                                komut2.Parameters.AddWithValue("@dersid", Convert.ToInt32(dersidtext.Text));
                                komut2.Parameters.AddWithValue("@devam1", Convert.ToInt32(devamsizliktext.Text));
                                komut2.Parameters.AddWithValue("@ogrencino", Convert.ToInt64(ogrencino.Text)); //niye 2 kere kullandım bilmiyorum
                                komut2.ExecuteNonQuery();

                                MessageBox.Show("Öğrencinin devamsızlık bilgisi başarıyla güncellendi.");
                                baglanti.Close();
                            }
                            else
                            {
                                var command = new SqlCommand("INSERT INTO Devamsizlik(ogrenci_no,ders_id,devamsizlik) VALUES('" + Convert.ToInt64(ogrencino.Text) + "','" + Convert.ToInt32(dersidtext.Text) + "','" + Convert.ToInt32(devamsizliktext.Text) + "')");
                                command.Connection = baglanti;

                                if (command.ExecuteNonQuery() != -1)
                                {

                                }
                                MessageBox.Show("Öğrencinin devamsızlık bilgisi başarıyla güncellendi.");
                                baglanti.Close();

                            }
                    }
                }





            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu!!! \n");
                MessageBox.Show("-" + hata);
            }



        }


    

 

        private void devamsizliktext_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ogrencino_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
    }
}



