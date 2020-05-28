using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14Sınıflar
{
    class hasan
    {
        double kenar1;
        double kenar2;

        public double Kenar1
        {
            get
            {
                return kenar1;
            }
            set
            {
                kenar1 = value;
            }
        }
        public double Kenar2
        {
            get
            {
                return kenar2;
            }

            set
            {
                kenar2 = value;
            }
        }

        public double alan()
        {
            return (kenar1 * kenar2) / 2;
        }
        public double cevre()
        {
            double hipotenus = Math.Sqrt(Math.Pow(kenar1, 2) + (Math.Pow(kenar2, 2)));
            return (kenar1 + kenar2 + hipotenus);
        }
    }
}
