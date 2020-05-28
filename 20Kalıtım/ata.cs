using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20Kalıtım
{
    class ata
    {
        int enkucuk;
        public ata(params int[] liste1)
        {
            enkucuk = liste1[0];
            for (int i = 0; i < 100; i++)
            {
                if (liste1[i] == 0)
                {
                    continue;
                }
                if (liste1[i] < enkucuk)
                {
                    enkucuk = liste1[i];
                }
            }MessageBox.Show(enkucuk.ToString());
        }
    }
    class yavru:ata
    {
        int enbuyuk;
        public yavru(params int[] liste2)
            : base(liste2)
        {
            enbuyuk = liste2[0];
            for (int i = 0; i < 100; i++)
            {
                if (liste2[i]==0)
                {
                    continue;
                }
                if (liste2[i]>enbuyuk)
                {
                    enbuyuk = liste2[i];
                }
            }MessageBox.Show(enbuyuk.ToString());
        }
    }
}
