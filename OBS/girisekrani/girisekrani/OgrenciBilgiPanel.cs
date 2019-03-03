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
using System.IO;

namespace girisekrani
{
    public partial class OgrenciBilgiPanel : Form
    {
        string script = File.ReadAllText(@"D:\brawlbuster_2.sql");

        public OgrenciBilgiPanel()
        {
            InitializeComponent();
        }

        public SinifOgrenci user;
        public static string kadi2;
        static string conString = "Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=TRUE";
        SqlConnection baglanti = new SqlConnection(conString);

        private void OgrenciDersProgrami_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label7.ForeColor = Color.White;

            kadi2 = SinifOgrenciGiris.OgrenciNo1.ToString();
            arakullaniciadi.Text = kadi2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OgrenciAnaMenu a = new OgrenciAnaMenu();
            a.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void arabuton_Click(object sender, EventArgs e)
        {
            //arakullaniciadi.Text = user.KullaniciAdi;
            baglanti.Open();
            string kayit = "SELECT * from ogrenci where ogrenci_no=@ogno";
            //kullaniciadi parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@ogno", Convert.ToInt64(arakullaniciadi.Text));
            //kullaniciadi parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
            {
               
                sifreniztext.Text = dr["ogrenci_sifre"].ToString();
                adiniztext.Text = dr["ad"].ToString();
                soyadiniztext.Text = dr["soyad"].ToString();

                //Datareader ile okunan verileri form kontrollerine aktardık.
            }
            else
                MessageBox.Show("Böyle bir öğrenci bulunmamaktadır.");
            baglanti.Close();
        }

        private void guncellebuton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "update ogrenci set ogrenci_sifre=@sifre where ogrenci_no=@ogno";
            // ogretmenn tablomuzun ilgili alanlarını değiştirecek olan güncelleme sorgusu.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            komut.Parameters.AddWithValue("@ogno", Convert.ToInt64(arakullaniciadi.Text));
            komut.Parameters.AddWithValue("@sifre", sifreniztext.Text);
            //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
            komut.ExecuteNonQuery();
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            baglanti.Close();
            MessageBox.Show("Kullanıcı bilgileriniz düzenlendi.");
        }
    }
}
