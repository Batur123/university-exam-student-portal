using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace girisekrani
{
    public class SinifOgrenciGiris
    {
        public static string isim, soyisim, unvan;
        public static string İsim1, Soyisim1;
        public static int BolumID1;
        public static long OgrenciNo1;
        public SinifOgrenci getUser(long ogrencino,string sifre)
        {
            SinifOgrenci user = null;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM ogrenci WHERE ogrenci_no='" + ogrencino + "'and ogrenci_sifre='" + sifre + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new SinifOgrenci();
                        user.OgrenciNo = reader.GetInt64(0);  // () parantez içindeki sayılar tablonun yerini belli ediyor.
                        user.Sifre = reader.GetString(4);
                        İsim1 = reader.GetString(1);
                        Soyisim1 = reader.GetString(2);
                        OgrenciNo1 = reader.GetInt64(0);
                        BolumID1 = reader.GetInt32(3);
                        
                        // Ogrenci tablosunda 2 sütun Ogrenci no 3-sütun Sifre olduğu için böyle yazılmıştır. 0 isim 1 soyisim
                        //user.İsim = reader.GetString(0);
                        // user.Soyisim = reader.GetString(1);
                        
                    }
                }
                connection.Close();
            }
            return user;
        }

        private bool ContainsUser(SinifOgrenci user)
        {
            bool result = false;
            using (var connection = Database.GetConnection())
            {
                var command = new SqlCommand("SELECT *FROM ogrenci WHERE ogrenci_no='" + user.OgrenciNo + "'");
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

        public bool InsertUser(SinifOgrenci user)
        {
            bool result = false;
            if (!ContainsUser(user))
            {
                using (var connection = Database.GetConnection())
                {
                    // var command = new SqlCommand("INSERT INTO ogretmenn(isim,soyisim,kullaniciadi,sifre,unvan) VALUES('" + user.İsim + "','" + user.Soyisim + "','" + user.KullaniciAdi + "','" + user.Sifre + "','" + user.Unvan + ")'");
                    // var command = new SqlCommand("INSERT INTO ogretmenn(ad,soyad,kullaniciadi,sifre,unvan) VALUES ("+ user.İsim + "," + user.Soyisim + "," + user.KullaniciAdi + "," + user.Sifre + "," + user.Unvan + ",");
                    var command = new SqlCommand("INSERT INTO ogrenci(ad,soyad,ogrenci_no,ogrenci_sifre,bolum_id) VALUES('" + user.İsim + "','" + user.Soyisim + "','" + user.OgrenciNo + "','" + user.Sifre + "','" + user.BolumID + "')");
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
