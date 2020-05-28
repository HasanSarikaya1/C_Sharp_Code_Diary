using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21Delegate_Temsilciler_Console
{
    class Program
    {
        public delegate void TestHandler(); //Temsilci Tanımlama yaptık
        public static void metod1()
        {
            Console.WriteLine("Temsilci ile çağrıldın..");
        }
        static void Main(string[] args)
        {
            TestHandler test = new TestHandler(metod1); //Örnekleme
            test(); //Çağırma
            Console.ReadKey();
        }
    }
}
