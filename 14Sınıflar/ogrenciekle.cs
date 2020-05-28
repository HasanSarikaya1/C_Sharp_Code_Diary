using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14Sınıflar
{
    class ogrenciekle
    {
        public string adi;
        public string soyadi;
        public string sinif;
        public string ekle;
        public void duzenle()
        {
            ekle = "Öğrencinin Adı: " + adi + " Soyadı: " + soyadi + " Sınıfı: " + sinif;
        }
    }
}
