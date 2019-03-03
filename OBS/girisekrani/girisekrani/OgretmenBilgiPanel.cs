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
    public partial class OgretmenBilgiPanel : Form
    {
        public OgretmenBilgiPanel()
        {
            InitializeComponent();
        }

        private void geridonbuton_Click(object sender, EventArgs e)
        {
            OgretmenAnaMenu a = new OgretmenAnaMenu();
            a.Show();
            this.Hide();
        }

    

        static string conString = "Data Source=BATUR;Initial Catalog=OBSVeritabani;Integrated Security=TRUE";
        SqlConnection baglanti = new SqlConnection(conString);

        private void guncellebuton_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "update ogretim_gorevlisi set ogretim_kullanici=@kullaniciadi,ad=@isim,soyad=@soyisim,ogretim_sifre=@sifreniz,unvan=@unvaniniz where ogretim_kullanici=@kullaniciadi";
            // ogretmenn tablomuzun ilgili alanlarını değiştirecek olan güncelleme sorgusu.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            komut.Parameters.AddWithValue("@kullaniciadi", kullaniciadiniztext.Text);
            komut.Parameters.AddWithValue("@isim", adiniztext.Text);
            komut.Parameters.AddWithValue("@soyisim", soyadiniztext.Text);
            komut.Parameters.AddWithValue("@sifreniz", sifreniztext.Text);
            komut.Parameters.AddWithValue("@unvaniniz", unvaniniztext.Text);
            //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
            komut.ExecuteNonQuery();
            //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
            baglanti.Close();
            MessageBox.Show("Kullanıcı bilgileriniz düzenlendi.");
        }

        //public SinifOgretmen user;
        //public SinifOgretmenGiris islem;
        public static string kullaniciadiogr;

        private void arabuton_Click(object sender, EventArgs e)
        {

            //arakullaniciadi.Text = user.KullaniciAdi;
            baglanti.Open();
            string kayit = "SELECT * from ogretim_gorevlisi where ogretim_kullanici=@kullaniciadi";
            //kullaniciadi parametresine bağlı olarak müşteri bilgilerini çeken sql kodu
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@kullaniciadi", arakullaniciadi.Text);
            //kullaniciadi parametremize textbox'dan girilen değeri aktarıyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) //bunu millet normalde while ile kullanıyomuş ne işe yaradığını bilmiyorum
            {
                arakullaniciadi.Text = dr["ogretim_kullanici"].ToString();
                adiniztext.Text = dr["ad"].ToString();
                soyadiniztext.Text = dr["soyad"].ToString();
                kullaniciadiniztext.Text = dr["ogretim_kullanici"].ToString();
                sifreniztext.Text = dr["ogretim_sifre"].ToString();
                unvaniniztext.Text = dr["unvan"].ToString();
                //Datareader ile okunan verileri form kontrollerine aktardık.
            }
            else
                MessageBox.Show("Böyle bir Öğretim Üyesi bulunmamaktadır.");
            baglanti.Close();
        }

        public SinifOgretmen user;
        public static string kadi2;

        private void OgretmenBilgiPanel_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;

            kadi2 = SinifOgretmenGiris.KullaniciAdi1;
            arakullaniciadi.Text = kadi2;
           // SinifOgretmenGiris a = new SinifOgretmenGiris();
           // arakullaniciadi.Text = user.
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
