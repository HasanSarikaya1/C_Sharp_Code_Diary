using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04MetotUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void maas(int yev,int ssk,int gun)
        {
            int brut = gun * yev;
            int sko = (brut * ssk) / 100;
            int net = brut - sko;
            label6.Text = net.ToString();
            label7.Text = sko.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            int c = Convert.ToInt32(comboBox1.Text);
            maas(a,c,b);
        }
    }
}
