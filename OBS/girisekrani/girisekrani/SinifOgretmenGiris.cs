using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace girisekrani
{
    public class SinifOgretmenGiris
    {
        public static string isim, soyisim, unvan;
        public static string KullaniciAdi1,İsim1,Soyisim1,Unvan1;
        public static int BolumID1;
        public SinifOgretmen getUser(string kullaniciadi,string sifre)
        {
            SinifOgretmen user = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM ogretim_gorevlisi WHERE ogretim_kullanici='" + kullaniciadi + "'and ogretim_sifre='" + sifre + "'");// "'and ad='" + isim + "'and soyad='" + soyisim + "'and unvan='" + unvan + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new SinifOgretmen();
                        user.KullaniciAdi = reader.GetString(5); // 3.tablo kullanıcı adı 
                        user.Sifre = reader.GetString(6);   // 2.tablo sifredir. 0isim 1soyisim 5 ise unvan tablosu
                        user.İsim = reader.GetString(1);
                        user.Soyisim = reader.GetString(2);

                        //Üstteki komutlar doğrulama için alttakiler ise formdan forma bilgi aktarımı
                        KullaniciAdi1 = reader.GetString(5);
                        İsim1 = reader.GetString(1);
                        Soyisim1 = reader.GetString(2);
                        Unvan1 = reader.GetString(3);
                        BolumID1 = reader.GetInt32(4);
                    }
                }
                connection.Close();
            }
            return user;
        }

        private bool ContainsUser(SinifOgretmen user)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM ogretim_gorevlisi WHERE ogretim_kullanici='" + user.KullaniciAdi + "'");
                //var command = new SqlCommand("SELECT *FROM Users WHERE Name='" + user.Name + "' and Password='" + user.Password + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
            return result;
        }

        public bool InsertUser(SinifOgretmen user)
        {
            bool result = false;
            if (!ContainsUser(user))
            {
                using (var connection = Database.GetConnection())
                {
                    // var command = new SqlCommand("INSERT INTO ogretmenn(isim,soyisim,kullaniciadi,sifre,unvan) VALUES('" + user.İsim + "','" + user.Soyisim + "','" + user.KullaniciAdi + "','" + user.Sifre + "','" + user.Unvan + ")'");
                    // var command = new SqlCommand("INSERT INTO ogretmenn(ad,soyad,kullaniciadi,sifre,unvan) VALUES ("+ user.İsim + "," + user.Soyisim + "," + user.KullaniciAdi + "," + user.Sifre + "," + user.Unvan + ",");
                    var command = new SqlCommand("INSERT INTO ogretim_gorevlisi(ad,soyad,ogretim_kullanici,ogretim_sifre,unvan,bolum_id) VALUES('" + user.İsim + "','" + user.Soyisim + "','" + user.KullaniciAdi + "','" + user.Sifre + "','" + user.Unvan + "','" + user.BolumID + "')");
                    command.Connection = connection;
                    connection.Open();
                    if (command.ExecuteNonQuery() != -1)
                    {
                        result = true;
                    }
                    connection.Close();
                }
            }
            return result;
        }

       
    }
}

