using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace girisekrani
{
   public class SinifOgretmen : SinifBilgiler
    {
        string _unvan;
        string kullaniciadi;
        int dersidd,bolumidd;
        

        public string Unvan
        {
            get { return _unvan; }
            set { _unvan = value; }
        }

        public string KullaniciAdi
        {
            get { return kullaniciadi;}
            set { kullaniciadi = value;}
        }
        
        public int DERSID
        {
            get { return dersidd; }
            set { dersidd = value; }
        }

        public int BOLUMID
        {
            get { return bolumidd; }
            set { bolumidd = value; }
        }



    }
    
}
