using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace _31palindrom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                string metin = textBox1.Text;
                metin = metin.Replace("'", "");
                metin = metin.Replace(":", "");
                metin = metin.Replace(";", "");
                metin = metin.Replace(".", "");
                metin = metin.Replace("/", "");
                metin = metin.Replace("\"", "");
                string[] parcalar = metin.Split(' ');
                foreach (string parca in parcalar)
                {

                    char[] yeni = parca.ToCharArray();
                    Array.Reverse(yeni);
                    if (string.Compare(parca, new string(yeni)).ToString() == "0")
                    {
                        listBox1.Items.Add(parca);
                    }
                    string cozum = parca.ToString();
                    for (int i = 0; i < cozum.Length; i++)
                    {
                        cozum = cozum.Substring(1, cozum.Length - 1).Substring(0, cozum.Length - 2);
                        if (cozum.Length != 1)
                        {
                            char[] yeni2 = cozum.ToCharArray();
                            Array.Reverse(yeni2);
                            if (string.Compare(cozum, new string(yeni2)).ToString() == "0")
                            {
                                listBox1.Items.Add(cozum);
                            }
                        }

                    }

                }
                object[] items = new object[listBox1.Items.Count];
                listBox1.Items.CopyTo(items, 0);
                listBox1.Items.Clear();
                Array.Sort(items, (x, y) => x.ToString().Length.CompareTo(y.ToString().Length));
                listBox1.Items.AddRange(items);
                //
                var veriler = listBox1.Items.Cast<String>().ToArray();
                string[] kelimeler;
                List<string> tekil = new List<string>();
                kelimeler = veriler;
                for (int i = 0; i < kelimeler.Length; i++)
                {
                    if (tekil.Contains(kelimeler[i]) == false)
                    {
                        tekil.Add(kelimeler[i]);
                    }
                }
                foreach (string k in tekil)
                {
                    int sayac = 0;
                    for (int i = 0; i < kelimeler.Length; i++)
                    {
                        if (kelimeler[i] == k)
                        {
                            sayac++;
                        }
                    }
                    listBox2.Items.Add(k + " >> " + sayac + " Kere Kullanılmıştır.");
                }
            }
            
            catch (Exception)
            {

                MessageBox.Show("Programda Hata Oluştu.Bu Hata Yanlış veri girişi veya başka bir sorundan kaynaklı olabilir.Program Yeniden Başlatılacak...");
                Application.Restart();
            }
            
            
        }
        //makam yapay mum kapak kısık
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
