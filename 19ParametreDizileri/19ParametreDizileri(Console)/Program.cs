using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _19ParametreDizileri_Console_
{
    class Program
    {   //params kullanarak dizideki sayılardan en küçüğünü ekrana yazdıran program
        public static int min(params int[] paramslist)
        {
            int z = paramslist[0];
            foreach (int i in paramslist)
            {
                if (i<z)
                {
                    z = 1;
                }
            }
            return z;
        }
        static void Main(string[] args)
        {
            int[] dizi = new int[3];
            dizi[0] = 5;
            dizi[1] = 9;
            dizi[2] = 6;
            int ke = min(dizi);
            Console.WriteLine("En küçük sayı : "+ke);
            Console.ReadKey();
        }
    }
}
