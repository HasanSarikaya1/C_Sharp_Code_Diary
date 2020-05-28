using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22Olaylar_Events_
{
    class ceviri
    {
        private string yazi = "";
        private string sonuc = "";
        public delegate string temsilciler(string sayi);
        public event temsilciler olay;
        public ceviri(string sayi1)
        {
            yazi = sayi1;
        }
        public string Yazi
        {
            get { return sonuc;}
            set
            {
                yazi = value;
                if ((Convert.ToInt32(yazi)<10||Convert.ToInt32(yazi)>99)&&olay !=null)
                {
                    olay(yazi);
                }
                else
                {
                    switch (yazi[0])
                    {
                        case '1':
                            {
                                sonuc = "on";
                                break;
                            }
                        case '2':
                            {
                                sonuc = "yirmi";
                                break;
                            }
                        case '3':
                            {
                                sonuc = "otuz";
                                break;
                            }
                        case '4':
                            {
                                sonuc = "kırk";
                                break;
                            }
                        case '5':
                            {
                                sonuc = "elli";
                                break;
                            }
                        case '6':
                            {
                                sonuc = "altmış";
                                break;
                            }
                        case '7':
                            {
                                sonuc = "yetmiş";
                                break;
                            }
                        case '8':
                            {
                                sonuc = "seksen";
                                break;
                            }
                        case '9':
                            {
                                sonuc = "doksan";
                                break;
                            }
                    }
                    switch(yazi[1])
                    {
                        case '1':
                            {
                                sonuc = sonuc + "bir";
                                break;
                            }
                        case '2':
                            {
                                sonuc = sonuc + "iki";
                                break;
                            }
                        case '3':
                            {
                                sonuc = sonuc + "üç";
                                break;
                            }
                        case '4':
                            {
                                sonuc = sonuc + "dört";
                                break;
                            }
                        case '5':
                            {
                                sonuc = sonuc + "beş";
                                break;
                            }
                        case '6':
                            {
                                sonuc = sonuc + "altı";
                                break;
                            }
                        case '7':
                            {
                                sonuc = sonuc + "yedi";
                                break;
                            }
                        case '8':
                            {
                                sonuc = sonuc + "sekiz";
                                break;
                            }
                        case '9':
                            {
                                sonuc = sonuc + "dokuz";
                                break;
                            }
                    }
                }
            }
        }
    }
}
