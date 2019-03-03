using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace girisekrani
{
  public abstract class SinifBilgiler
    {

        string _isim, _soyisim, _sifre;
        int bolumid;

        public string İsim
        {
            get { return _isim; }
            set { _isim = value; }
        }
       
        public string Soyisim
        {
            get { return _soyisim; }
            set { _soyisim = value; }
        }
        
        public string Sifre
        {
            get { return _sifre; }
            set { _sifre = value; }
        }

        public int BolumID
        {
            get { return bolumid; }
            set { bolumid = value; }
        }

    }
}
