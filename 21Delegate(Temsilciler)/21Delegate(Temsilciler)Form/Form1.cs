using _21Delegate_Temsilciler_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21Delegate_Temsiciler_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate string temsil(string ifade); //örnek1 için
        public string kelime1, kelime2, kelime3;  // örnek1 için
        string[] dizi = new string[100];
        int indis = 0;
        public delegate string temsilcim(params string[] ifade);

        private void button3_Click(object sender, EventArgs e)
        {
            bul b = new bul();
            temsilcim t = new temsilcim(b.bes);
            MessageBox.Show("5'e Tam bölünenlerin sayısı : "+t(dizi));
            t = b.uc;
            MessageBox.Show("3'e Tam Bölünenlerin Sayısı : "+t(dizi));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dizi[indis] = textBox2.Text;
            indis++;
            textBox2.Clear();
            textBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)//örnek 1in butonu
        {
            donustur d = new donustur();
            temsil t = new temsil(d.buyuk);
            kelime1 = t(textBox1.Text);
            t += d.kucuk;
            kelime2 = t(textBox1.Text);
            t += d.karisik;
            kelime3 = t(textBox1.Text);
            MessageBox.Show(kelime1+"\n"+kelime2+"\n"+kelime3);
            textBox1.Clear();
        }
    }
}
