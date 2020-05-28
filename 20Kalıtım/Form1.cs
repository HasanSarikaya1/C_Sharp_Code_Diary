using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20Kalıtım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] sayi = new int[100];
        int indis = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            sayi[indis] = Convert.ToInt32(textBox1.Text);
            indis++;
            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yavru deneme = new yavru(sayi);
        }
        string[] yenidizi = new string[100];
        int yeniindis;
        private void button3_Click(object sender, EventArgs e)
        {
            yenidizi[yeniindis] = textBox2.Text;
            yeniindis++;
            textBox2.Clear();
            textBox2.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yeniyavru a = new yeniyavru(textBox2.Text, yenidizi);
        }
    }
}
