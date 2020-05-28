using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Delegate_Temsiciler_Form
{
    class donustur
    {
        string yenifade = "";
        public string buyuk(string ifade)
        {
            return ifade.ToUpper();
        }
        public string kucuk(string ifade)
        {
            return ifade.ToLower();
        }
        public string karisik(string ifade)
        {
            for (int i = 0; i < ifade.Length; i++)
            {
                if (i%2==0)
                {
                    yenifade = yenifade + (ifade[i].ToString()).ToUpper();
                }
                else
                {
                    yenifade = yenifade + (ifade[i].ToString()).ToLower();
                }
            }
            return yenifade;
        }
    }
}
