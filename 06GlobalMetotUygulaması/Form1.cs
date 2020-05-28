using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06GlobalMetotUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string isaret;
        int sayi,sayi2;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            isaret = "+";
            sayi = int.Parse(textBox1.Text);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            isaret = "-";
            sayi = int.Parse(textBox1.Text);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            isaret = "*";
            sayi = int.Parse(textBox1.Text);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            isaret = "/";
            sayi = int.Parse(textBox1.Text);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            sayi2 = int.Parse(textBox1.Text);
            if(isaret=="+")
            {
                textBox1.Text = Class1.topla(sayi, sayi2).ToString();
            }
            if (isaret == "-")
            {
                textBox1.Text = Class1.cik(sayi, sayi2).ToString();
            }
            if (isaret == "*")
            {
                textBox1.Text = Class1.carp(sayi, sayi2).ToString();
            }
            if (isaret == "/")
            {
                textBox1.Text = Class1.bol(sayi, sayi2).ToString();
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            string metin = textBox2.Text;
            if (comboBox1.Text=="Büyük")
            {
                label3.Text = metin.ToUpper();
            }
            else if(comboBox1.Text=="Küçük")
            {
                label3.Text = metin.ToLower();
            }
            else
            {
                MessageBox.Show("Hata");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            sayi = 0;
            sayi2 =0;
        }
    }
}
