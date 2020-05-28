using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20Kalıtım
{
    public class yeniata
    {
        public yeniata(string harf,params object[] yeniliste)
        {
            int adet = 0;
            foreach (string eleman in yeniliste)
            {
                if (eleman==null)
                {
                    continue;
                }
                if (eleman[0].ToString()==harf)
                {
                    adet++;
                }
            }
            MessageBox.Show(adet.ToString());
        }
    }
    public class yeniyavru : yeniata
    {
        public yeniyavru(string harf1,params object[] liste1)
            :base(harf1,liste1)
        {
            int adet1 = 0;
            foreach (string eleman1 in liste1)
            {
                if (eleman1==null)
                {
                    continue;
                }
                if (eleman1[eleman1.Length-1].ToString()==harf1)
                {
                    adet1++;
                }
            }
            MessageBox.Show(adet1.ToString());
        }
    }
}
