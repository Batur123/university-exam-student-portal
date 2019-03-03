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
    public partial class OgretmenNotGir : Form
    {
        public OgretmenNotGir()
        {
            InitializeComponent();
        }

        static string conString = "Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=TRUE;MultipleActiveResultSets=True";
        SqlConnection baglanti = new SqlConnection(conString);
        

        private void OgretmenNotGir_Load(object sender, EventArgs e)
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
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;

            checkBox1.ForeColor = Color.White;
            checkBox1.BackColor = Color.Transparent;

            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
        }

        

        private void arabuton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Lütfen öğrenci not kısmını boş bırakmayınız.");
            }
            else
            {
                baglanti.Open();
                string kayit = "SELECT * from ogrenci where ogrenci_no=@ogretimno";
                //okulno parametresine bağlı olarak örenci bilgilerini çeken sql kodu
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@ogretimno", ogrencino.Text);



                //okulno parametremize textbox'dan girilen değeri aktarıyoruz.
                SqlDataAdapter da = new SqlDataAdapter(komut);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
                {

                    textBox2.Text = dr["ogrenci_no"].ToString();


                    //Datareader ile okunan verileri form kontrollerine aktardık.
                }
                else
                    MessageBox.Show("Böyle bir öğrenci ismi bulunmamaktadır. Bir hata oluştu");
                baglanti.Close();
            }

        } 

       

        private void temizlebuton_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                    item.ResetText();
                if (item is ComboBox)
                    item.ResetText();
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

        private void checkBox1_Click(object sender, EventArgs e)
        {
             if (checkBox1.Checked)
              {
                  matfinal.ReadOnly = true; ;
                  matbut.ReadOnly = false;
                  matfinal.Clear();
                  matort.Clear();
              }
              else
              {
                  matbut.ReadOnly = true;
                  matfinal.ReadOnly = false;
                  matbut.Clear();
                  matort.Clear();
              } 
        }


        private void geridonbuton_Click(object sender, EventArgs e)
        {
            OgretmenAnaMenu a = new OgretmenAnaMenu();
            a.Show();
            this.Hide();
        }

      

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static double ortalama1;
        public static int but;
        public static int final;

        private void notverbuton_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                if (matbut.Text == "" || matvize.Text == "" || ogrencino.Text == "" || textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Lütfen eksik kutu bırakmayınız. Öğrenci numarasını doğru yazdığınızdan ve bölümünüzü seçtiğinizden emin olunuz.");
                }
                else
                {
                    if (Convert.ToInt32(matvize.Text) < 0 || Convert.ToInt32(matvize.Text) > 100 && Convert.ToInt32(matbut.Text) < 0 || Convert.ToInt32(matbut.Text) > 100)
                    {
                        MessageBox.Show("Girilen not negatif veya 100 den büyük olmamalıdır!!!");

                    }
                    else
                    {
                        ortalama1 = Convert.ToInt32(matvize.Text) * 0.4 + Convert.ToInt32(matbut.Text) * 0.6;
                        matort.Text = ortalama1.ToString();
                        final = 2*0;
                        matfinal.Text = final.ToString();

                        var kayit3 = new SqlCommand("SELECT *FROM ogrenci_not WHERE ders_id='" + Convert.ToInt32(textBox1.Text) + "'and ogrenci_no='" + Convert.ToInt64(textBox2.Text) + "'");
                        kayit3.Connection = baglanti;
                        baglanti.Open();
                        using (var reader = kayit3.ExecuteReader())

                            if (reader.Read())
                            {
                                string kayit = "update ogrenci_not set ogrenci_no=@ogno,vize=@vize1,butunleme=@but1,ortalama=@ortalama1,final=@final1 where ogrenci_no=@ogrencino and ders_id=@dersid"; //,ders_id=@dersid 
                                SqlCommand komut2 = new SqlCommand(kayit, baglanti);
                                komut2.Parameters.AddWithValue("@dersid", Convert.ToInt32(textBox1.Text));
                                komut2.Parameters.AddWithValue("@vize1", Convert.ToInt32(matvize.Text));
                                komut2.Parameters.AddWithValue("@but1", Convert.ToInt32(matbut.Text));
                                
                                komut2.Parameters.AddWithValue("@final1", Convert.ToInt32(matfinal.Text));
                                komut2.Parameters.AddWithValue("@ortalama1", Convert.ToDouble(matort.Text));
                                komut2.Parameters.AddWithValue("@ogno", Convert.ToInt64(ogrencino.Text));
                                komut2.Parameters.AddWithValue("@ogrencino", Convert.ToInt64(ogrencino.Text)); //niye 2 kere kullandım bilmiyorum
                                komut2.ExecuteNonQuery();

                                MessageBox.Show(String.Format("Öğrencinin notu tekrar düzenlendi. \n Vize: {0} Büt: {1} Ortalama:{2}", matvize.Text, matbut.Text, matort.Text));

                                baglanti.Close();
                            }
                            else
                            {
                                var command = new SqlCommand("INSERT INTO ogrenci_not(ogrenci_no,ders_id,vize,butunleme,ortalama) VALUES('" + Convert.ToInt64(textBox2.Text) + "','" + Convert.ToInt32(textBox1.Text) + "','" + Convert.ToInt32(matvize.Text) + "','" + Convert.ToInt32(matbut.Text) + "','" + Convert.ToInt32(matort.Text) + "')");
                                command.Connection = baglanti;

                                if (command.ExecuteNonQuery() != -1)
                                {

                                }
                                MessageBox.Show(String.Format("Öğrencinin ilk notu girildi. \n Vize: {0} Büt: {1} Ortalama:{2}", matvize.Text, matbut.Text, matort.Text));

                                baglanti.Close();

                            }
                        matort.Clear();
                        matvize.Clear();
                        matbut.Clear();
                        matfinal.Clear();
                    }
                }
            }
            else
            {
                if (matvize.Text == "" || matfinal.Text == "" || textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Lütfen eksik kutu bırakmayınız. Öğrenci numarasını doğru yazdığınızdan ve bölümünüzü seçtiğinizden emin olunuz.");
                }
                else
                {
                    if (Convert.ToInt32(matvize.Text) < 0 || Convert.ToInt32(matvize.Text) > 100 && Convert.ToInt32(matfinal.Text) < 0 || Convert.ToInt32(matfinal.Text) > 100)
                    {
                        MessageBox.Show("Girilen not negatif veya 100 den büyük olmamalıdır!!!");

                    }
                    else
                    {
                        ortalama1 = Convert.ToInt32(matvize.Text) * 0.4 + Convert.ToInt32(matfinal.Text) * 0.6;
                        matort.Text = ortalama1.ToString();
                        but = 2 * 0;
                        matbut.Text = but.ToString();

                        var kayit3 = new SqlCommand("SELECT *FROM ogrenci_not WHERE ders_id='" + Convert.ToInt32(textBox1.Text) + "'and ogrenci_no='" + Convert.ToInt64(textBox2.Text) + "'");
                        kayit3.Connection = baglanti;
                        baglanti.Open();
                        using (var reader = kayit3.ExecuteReader())

                            if (reader.Read())
                            {
                                string kayit = "update ogrenci_not set ogrenci_no=@ogno,vize=@vize1,final=@final1,ortalama=@ortalama1,butunleme=@but1 where ogrenci_no=@ogrencino and ders_id=@dersid"; //,ders_id=@dersid 
                                SqlCommand komut2 = new SqlCommand(kayit, baglanti);
                                komut2.Parameters.AddWithValue("@dersid", Convert.ToInt32(textBox1.Text));
                                komut2.Parameters.AddWithValue("@vize1", Convert.ToInt32(matvize.Text));
                                komut2.Parameters.AddWithValue("@final1", Convert.ToInt32(matfinal.Text));
                               
                               
                                komut2.Parameters.AddWithValue("@but1", Convert.ToInt32(matbut.Text));
                                komut2.Parameters.AddWithValue("@ortalama1", Convert.ToDouble(matort.Text));
                                komut2.Parameters.AddWithValue("@ogno", Convert.ToInt64(ogrencino.Text));
                                komut2.Parameters.AddWithValue("@ogrencino", Convert.ToInt64(ogrencino.Text)); //niye 2 kere kullandım bilmiyorum
                                komut2.ExecuteNonQuery();

                                MessageBox.Show(String.Format("Öğrencinin notu tekrar düzenlendi. \n Vize: {0} Final: {1} Ortalama:{2}", matvize.Text,matfinal.Text,matort.Text));
                                
                                
                                baglanti.Close();
                            }
                            else
                            {
                                var command = new SqlCommand("INSERT INTO ogrenci_not(ogrenci_no,ders_id,vize,final,ortalama,butunleme) VALUES('" + Convert.ToInt64(textBox2.Text) + "','" + Convert.ToInt32(textBox1.Text) + "','" + Convert.ToInt32(matvize.Text) + "','" + Convert.ToInt32(matfinal.Text) + "','" + Convert.ToInt32(matort.Text) + "','" + Convert.ToInt32(matbut.Text) + "')");
                                command.Connection = baglanti;

                                if (command.ExecuteNonQuery() != -1)
                                {

                                }
                                MessageBox.Show(String.Format("Öğrencinin ilk notu girildi. \n Vize: {0} Final: {1} Ortalama:{2}", matvize.Text, matfinal.Text, matort.Text));

                                baglanti.Close();

                            }
                        matort.Clear();
                        matvize.Clear();
                        matbut.Clear();
                        matfinal.Clear();
                    }
                }
            }
            

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

        private void matvize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void matfinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void matbut_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void matort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
