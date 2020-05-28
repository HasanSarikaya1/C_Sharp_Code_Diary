using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _18KoleksiyonSınıfları_Console_
{
    class Program
    {
        static void Main(string[] args)
        {//Queuedeki Ana mantık olan ilk giren ilk çıkar ,son giren son çıkar mantığının uygulamalı halidir.
            /* Queue ku = new Queue(6);
             ku.Enqueue("Hasan");
             ku.Enqueue("İsmail");
             ku.Enqueue("Enes");
             ku.Enqueue("Mert");
             ku.Enqueue(123);
             ku.Enqueue(false);
             Console.WriteLine("Çıkan Eleman {0}", ku.Dequeue().ToString());
             Console.WriteLine("Çıkan Eleman {0}", ku.Dequeue().ToString());
             Console.WriteLine("Çıkan Eleman {0}", ku.Dequeue().ToString());
             Console.WriteLine("----------------");
             IEnumerator dizi = ku.GetEnumerator();
             while (dizi.MoveNext())
             {
                 Console.WriteLine("Güncel eleman {0}",dizi.Current.ToString());
             }
             Console.ReadKey();
             */



            //Stackdeki Ana mantık olan son giren ilk çıkar,ilk çıkan son girer mantığının uygulamalı halidir.Yani bir eleman stack'a üstten katılır
            // ve yığını yine üstten terk eder.
            /*Stack sta = new Stack();
            sta.Push("Hasan");
            sta.Push("İsmail");
            sta.Push("Enes");
            sta.Push("Mert");
            sta.Push(43);
            sta.Push(true);
            Console.WriteLine("Çıkan Eleman {0}", sta.Pop().ToString());
            Console.WriteLine("Çıkan Eleman {0}", sta.Pop().ToString());
            Console.WriteLine("Çıkan Eleman {0}", sta.Pop().ToString());
            IEnumerator dizi = sta.GetEnumerator();
            while (dizi.MoveNext())
            {
                Console.WriteLine("Güncel Eleman {0}",dizi.Current.ToString());
            }
            Console.ReadKey();
            */





            //Hashtable koleksiyon sınıfında veriler key-value çiftleri şeklinde tutulmaktadır.Hashtable koleksiyon sınıflarında key ve value değerleri herhangi bir
            // veri türünde olabilir.Aşağıdaki örnek hashtable'ın ana mantığının uygulamalı halidir.
            /*Hashtable yas = new Hashtable();
            yas["Ali"] = 42;
            yas["Serdar"] = 34;
            yas["Utku"] = 55;
            foreach (DictionaryEntry element in yas)
            {
                string isim = element.Key.ToString();
                int has = (int)element.Value;
                Console.WriteLine("İsmi={0}  Yaşı={1}",isim,has);
            }
            Console.ReadKey();
            */



            //Hashtable ile aynıdır tek farkı ise anahtarlar dizisinin her zaman sıralanmış olmasıdır.
            /* SortedList yas = new SortedList();
            yas["Ali"] =42;
            yas["Serdar"] = 34;
            yas["Utku"] = 35;
            foreach  (DictionaryEntry element in yas)
            {
                string isim = element.Key.ToString();
                int has = (int)element.Value;
                Console.WriteLine("İsmi={0}  Yaşı={1}", isim, has);
            }
            Console.ReadKey();
            */
        }
    }
}
