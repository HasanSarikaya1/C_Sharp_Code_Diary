using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09UcgenCesidiniBulmaveMaasHesabi
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
                int k, kk, kkk;
                k = Convert.ToInt32(textBox1.Text);
                kk = Convert.ToInt32(textBox2.Text);
                kkk = Convert.ToInt32(textBox3.Text);
                if (k == kk && kk == kkk && k == kkk)
                {
                    MessageBox.Show("Eşkenar Üçgen");
                }
                else if (k == kk || k == kkk || kk == kkk)
                {
                    MessageBox.Show("İkizkenar Üçgen");
                }
                else
                {
                    MessageBox.Show("Çeşitkenar Üçgen");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Eksik Veya Hatalı Bir Değer Girdiniz...");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mev;
            mev = comboBox1.Text;
            int uc, top, maas;
            uc = Convert.ToInt32(textBox4.Text);
            if (mev=="Ustabaşı")
            {
                if (uc<=10)
                {
                    top = uc * 5;
                    maas = 2000 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc <= 25)
                {
                    top = uc * 11;
                    maas = 2000 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc <= 40)
                {
                    top = uc * 17;
                    maas = 2000 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc >=41)
                {
                    top = uc * 30;
                    maas = 2000 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                textBox4.Clear();
                
            }
            else if (mev == "Kalfa")
            {
                if (uc <= 10)
                {
                    top = uc * 5;
                    maas = 1500 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc <= 25)
                {
                    top = uc * 11;
                    maas = 1500 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc <= 40)
                {
                    top = uc * 17;
                    maas = 1500 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc >= 41)
                {
                    top = uc * 30;
                    maas = 1500 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                textBox4.Clear();
            }
            else if (mev == "Çırak")
            {
                if (uc <= 10)
                {
                    top = uc * 5;
                    maas = 1000+ top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc <= 25)
                {
                    top = uc * 11;
                    maas = 1000 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc <= 40)
                {
                    top = uc * 17;
                    maas = 1000 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                else if (uc >= 41)
                {
                    top = uc * 30;
                    maas = 1000 + top;
                    label6.Text = "Maaşınız : " + maas.ToString();
                }
                textBox4.Clear();
            }
        }
        int hak = 5;
        int sayi = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox5.Text=="hasan"&&textBox6.Text=="1523")
            {
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.Show();
                MessageBox.Show("Giriş İşlemi Başarılı..");
            }
            else if (textBox5.Text=="" && textBox6.Text=="")
            {
                MessageBox.Show("Boş Alan Bırakmayınız.");
            }
            if (hak >0)
            {
                hak = hak - 1;
            }
            if (hak==0)
            {
                MessageBox.Show(":(");
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                button3.Enabled = false;
            }
        }
    }
}
