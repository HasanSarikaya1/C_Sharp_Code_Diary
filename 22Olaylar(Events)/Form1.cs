using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22Olaylar_Events_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string yaziyacevir(string b)
        {
            MessageBox.Show("2 Basamaklı Gir.");
            b = "Uyarı";
            return b;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ceviri yeniceviri = new ceviri(textBox1.Text);
            yeniceviri.olay += new ceviri.temsilciler(yaziyacevir);
            yeniceviri.Yazi = textBox1.Text;
            label1.Text = yeniceviri.Yazi;
        }
    }
}
