using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11WhileOrnekveMatematikselCalısma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int sayac=0;
            while (sayac<=a)
            {
                listBox1.Items.Add(sayac.ToString());
                sayac++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klavyeden Girilen Sayıya Kadar Olan Çift Ve Tek Sayıların Toplamını Bulan Program");
        }
        int toplam = 0;
        int sayi;
        private void button3_Click(object sender, EventArgs e)
        {
            sayi = Convert.ToInt32(textBox2.Text);
            for (int i = 0; i <= sayi; i++)
            {
                if (i % 2 == 0 && comboBox1.Text=="Çift Sayılar")
                {
                    toplam = toplam + i;
                }
                else if (i%2!=0 && comboBox1.Text=="Tek Sayılar")
                {
                    toplam = toplam + i;
                }
            }
            label4.Text = toplam.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1-100 arasındaki 2 ve 5'e kalansız bölünenleri textbox'a yazdırma");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i%2==0 && i %5==0)
                {
                    listBox2.Items.Add(i);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bir kurbağa derinliği klavyeden girilen kuyuya düşüyor.Bu kurbağa gündüzleri 5 metre zıplarken gece ise bulunduğu yerden 3 metre aşağıya kayıyor.Bu kurbağa kuyudan kaç günde çıkar ?");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int h, zip;
            double gun = 0;
            zip = 0;
            h = Convert.ToInt32(textBox3.Text);
            for (; ; )
            {
                zip = zip + 5;
                gun = gun + 0.5;
                if (zip>=h)
                {
                    break;
                }
                zip = zip - 3;
                gun += 0.5;
            }
            MessageBox.Show(gun.ToString()+" Günde Çıkar"); ;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int son = 1;
            int sayi = 1;
            sayi = Convert.ToInt32(textBox4.Text);
            for (int i = 1; i <= sayi; i++)
            {
                son = i * son;
            }
            MessageBox.Show(son.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Girilen Sayının taban ve üstüne göre üssünü bulan program");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int üst = Convert.ToInt32(textBox5.Text);
            int taban = Convert.ToInt32(textBox6.Text);
            int sonuc = 1;
            for (int i = 0; i < üst; i++)
            {
                sonuc = sonuc * taban;
            }
            label9.Text = sonuc.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Girilen sayıları * şeklinde listboxta gösterme");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int deger = Convert.ToInt32(textBox7.Text);
            string yildiz = "";
            for (int i = 0; i < deger; i++)
            {
                yildiz = yildiz + "*";
                
            }
            listBox3.Items.Add(yildiz);
        }
    }
}
