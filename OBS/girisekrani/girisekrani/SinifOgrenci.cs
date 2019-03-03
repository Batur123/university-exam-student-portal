using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace girisekrani
{
    public class SinifOgrenci : SinifBilgiler
    {

        long _ogrencino;

        public long OgrenciNo
        {
            get {return _ogrencino; }
            set {_ogrencino = value; }
        }
    }
}
