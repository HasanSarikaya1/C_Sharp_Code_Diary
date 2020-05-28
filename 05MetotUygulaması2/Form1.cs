using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05MetotUygulaması2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void islem(int sayi)
        {
            int karesi = sayi * sayi;
            button1.Text = karesi.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            islem(a);
        }
        string adsoyad(string a,string b)
        {
            return a  + " " + b;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = adsoyad(textBox2.Text,textBox3.Text);
        }
    }
}
