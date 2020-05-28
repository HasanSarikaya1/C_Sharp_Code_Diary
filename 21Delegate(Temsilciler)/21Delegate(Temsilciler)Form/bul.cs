using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Delegate_Temsilciler_Form
{
    class bul
    {
        
        string kelime;
        int rakamsayisi = 0;
        public int besadet = 0;
        public int ucadet = 0;
        public string uc(params string[] ifade)
        {
            for (int i = 0; i < 100; i++)
            {
                rakamsayisi = 0;
                kelime = ifade[i];
                if (kelime==null)
                {
                    continue;
                }
                for (int j = 0; j < kelime.Length ; j++)
                {
                    rakamsayisi = rakamsayisi + int.Parse(kelime[j].ToString());
                }
                if (rakamsayisi%3==0)
                {
                    ucadet++;
                }
            }
            return ucadet.ToString();
        }
        public string bes(params string []ifade)
        {
            for (int i = 0; i < 100; i++)
            {
                kelime = ifade[i];
                if (kelime==null)
                {
                    continue;
                }
                if (kelime[kelime.Length-1]=='0'||kelime[kelime.Length-1]=='5')
                {
                    besadet++;
                }
            }
            return besadet.ToString();
        }
    }
}
