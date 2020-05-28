using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace _19ParametreDizileri_Form_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int kucukbul(params int[] paralistesi)
        {
            int enkucuk = paralistesi[0];
            foreach (int eleman in paralistesi)
            {
                if (eleman == 0)
                {
                    continue;
                }
                if (eleman<enkucuk)
                {
                    enkucuk = eleman;
                }
            }
            return enkucuk;
        }
        int[] sayi = new int[100];
        int indis = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            sayi[indis] = Convert.ToInt32(textBox1.Text);
            indis++;
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = kucukbul(sayi).ToString();
        }
        string[] dizi = new string[100];
        int indis1 = 0;
        string a(params string[] paramsa)
        {
            int adet = 0;
            foreach (string eleman in paramsa)
            {
                if (eleman==null)
                {
                    continue;
                }
                if (eleman[0]=='a' && eleman[eleman.Length-1]=='a')
                {
                    adet++;
                }
            }
            return adet.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dizi[indis1] = textBox2.Text;
            indis1++;
            textBox2.Clear();
            textBox2.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = a(dizi);
        }
    }
}
