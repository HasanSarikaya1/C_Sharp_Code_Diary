using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14Sınıflar
{
    class sinif
    {
        public int ort = 0;
        public string sonuc = "";
        public string sayi(string a1,string b2)
        {
            if (Convert.ToInt32(a1)<50&&Convert.ToInt32(b2)>61)
            {
                sonuc = "Geçti";
            }
            else
            {
                sonuc = "kaldi";
            }
            if (Convert.ToInt32(a1)>49)
            {
                if (Convert.ToInt32(a1+b2)/2>49)
                {
                    sonuc = "Geçti";
                }
                else
                {
                    sonuc = "Kaldı";
                }
            }return sonuc;
        }
    }
}
