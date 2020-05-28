using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10RastgeleSayıyıBulmaveSwitch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            switch (comboBox1.Text)
            {
                case "Bilişim":
                    {
                        listBox1.Items.Add("anadolu 9a"+"anadolu 10a"+"anadolu 11a");
                        break;
                    }
                case "Muhasebe":
                    {
                        listBox1.Items.Add("10c"+"11c"+"12c");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Hatalı Veya Yanlış Seçim.");
                        break;
                    }
                    
            }
        }
        int sayi, hak;

        private void button3_Click(object sender, EventArgs e)
        {
            int rak = textBox1.Text.Length;
            int tahmin = int.Parse(textBox1.Text);
            if (rak==2)
            {
                if (tahmin==sayi)
                {
                    MessageBox.Show("Tebrikler");
                    textBox1.Clear();
                }
                else if (hak == 0)
                {
                    MessageBox.Show("Hakkınız Bitti");
                    textBox1.Enabled = false;
                    button3.Enabled = false;
                }
                else if (tahmin > sayi)
                {
                    hak = hak - 1;
                    MessageBox.Show("Daha Düşük Rakam Veriniz.");
                    label2.Text = "Kalan Hakkınız : " + hak.ToString();
                }
                else if (tahmin < sayi)
                {
                    hak = hak - 1;
                    MessageBox.Show("Daha Yüksek Rakam Veriniz.");
                    label2.Text = "Kalan Hakkınız : " + hak.ToString();
                }
                

            }
            
            else
            {
                MessageBox.Show("2 Basamaklı Sayı Giriniz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hak = 5;
            textBox1.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random uret = new Random();
            sayi = uret.Next(10,99);
            hak = 5;
            label2.Text = "Kalan Hakkınız : " + hak.ToString();
        }
    }
}
