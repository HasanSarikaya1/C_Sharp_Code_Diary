using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15EnumVeSerbestÇalışma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum aylar
        {
            ocak,şubat,mart,nisan,mayıs,haziran,temmuz,ağustos,eylül,ekim,kasım,aralık
        }
        enum ogrenci
        {
            hasan,ismail,enes,mert,sefa,merve,engin,abdullah
        }
        enum iller
        {
            adana=1,adıyaman=2,afyon=3,ağrı=4,amasya=5,ankara=6,antalya=7,artvin=8,aydın=9,balıkesir=10,erzincan=24,erzurum=25,izmir=35
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayac=0;
            for (int i = 0; i < 12; i++)
            {
                listBox1.Items.Add((aylar)sayac).ToString();
                sayac++;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random uret = new Random();
            int sayi = uret.Next(0,8);
            label1.Text = "Öğrenci Adı : " + ((ogrenci)sayi).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            label3.Text = "İl : "+((iller)a).ToString();
            if (textBox1.Text==label3.Text)
            {
                MessageBox.Show("Böyle Bir İl Henüz Eklenmedi veya Yok");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] ay = Enum.GetNames(typeof(aylar));
            foreach (string ayYaz in ay)
            {
                listBox2.Items.Add(ayYaz);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Girilen sayının comboboxdan seçilen sayının tabanına çeviren program");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int kalan, bölünen;
            int taban = Convert.ToInt32(comboBox1.Text);
            bölünen = Convert.ToInt32(textBox2.Text);
            label5.Text = "";
            for (int i = 0; bölünen >= taban; i++)
            {
                kalan = bölünen % taban;
                label5.Text = kalan.ToString() + label5.Text;
                bölünen = bölünen / taban;
            }
            label5.Text = bölünen.ToString() + label5.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Girilen Mail Adresinde @ işaretinin olup olmadığını kontrol eden program");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = 0;
            string mail = textBox3.Text;
            int uzunluk = mail.Length;
            for (int i = 0; i < uzunluk; i++)
            {
                if (mail[i]=='@')
                {
                    a = 1;
                }
                
            }
            if (a == 0)
            {
                MessageBox.Show("Mail Adresiniz Uygun Değil");
            }
            else
            {
                MessageBox.Show("Mail Adresiniz Uygun.");
            }
        }
    }
}
