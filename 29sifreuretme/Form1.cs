using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _29sifreuretme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string no = "170756039";
        string adsoyad = "hasansarikaya";
        int kucukharf, buyukharf, sayi, adindis, noindis;
        Random rastgele = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                adindis = adsoyad.Length;
                noindis = no.Length;
                sayi = Convert.ToInt32(textBox2.Text);
                kucukharf = Convert.ToInt32(textBox1.Text);
                buyukharf = Convert.ToInt32(textBox3.Text);
                for (int i = 0; i < kucukharf; i++)
                {
                    int adharfuret = rastgele.Next(1, Convert.ToInt32(adindis));
                    label1.Text += adsoyad[adharfuret].ToString().ToLower();
                }
                for (int i = 0; i < sayi; i++)
                {
                    int nouret = rastgele.Next(1, Convert.ToInt32(noindis));
                    label1.Text += no[nouret].ToString();
                }
                for (int i = 0; i < buyukharf; i++)
                {
                    int buyukharfuret = rastgele.Next(1, Convert.ToInt32(adindis));
                    label1.Text += adsoyad[buyukharfuret].ToString().ToUpper();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Programda Hata Oluştu.Yeniden Başlatılıyor...");
                Application.Restart();
                throw;
            }
            
        }
    }
}
