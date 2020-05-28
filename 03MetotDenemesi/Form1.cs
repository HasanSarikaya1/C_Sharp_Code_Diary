using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03MetotDenemesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void islem()
        {
            int uzun, kisa, sonuc;
            uzun = Convert.ToInt32(textBox1.Text);
            kisa = Convert.ToInt32(textBox2.Text);
            sonuc = uzun + kisa * 2;
            button1.Text = sonuc.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            islem();
        }
    }
}
