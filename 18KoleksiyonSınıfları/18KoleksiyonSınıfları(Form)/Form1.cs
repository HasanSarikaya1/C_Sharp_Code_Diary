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

namespace _18KoleksiyonSınıfları_Form_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList siniflistesi = new ArrayList();
            siniflistesi.Add("Erzurum");
            siniflistesi.Add(25);
            siniflistesi.Add(true);
            textBox1.Text = siniflistesi[0].ToString();
        }
        ArrayList ortalama = new ArrayList();
        int toplam = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            ortalama.Add(Convert.ToInt32(textBox2.Text));
            textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (int a in ortalama)
            {
                toplam = toplam + a;
            }
            label1.Text = (toplam / ortalama.Count).ToString();
        }
        Queue ku = new Queue();
        string[,] hasta = new string[100,4];
        int satir = 0;
        string tc, stc;

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                tc = ku.Dequeue().ToString();
                for (int i = 0; i < 100; i++)
                {
                    if (tc == hasta[i, 0])
                    {
                        listBox1.Items.Add("İçerideki Hasta : " + hasta[i, 1] + " " + hasta[i,2]);
                        break;
                    }
                }
                stc = ku.Peek().ToString();
                for (int i = 0; i < 100; i++)
                {
                    if (stc==hasta[i,0])
                    {
                        listBox1.Items.Add("Sıradaki Hasta : " + hasta[i, 1] + " " + hasta[i, 2]);
                        break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ku.Enqueue(textBox3.Text);
            hasta[satir, 0] = textBox3.Text;
            hasta[satir, 1] = textBox4.Text;
            hasta[satir, 2] = textBox5.Text;
            hasta[satir, 3] = comboBox1.Text;
            satir++;
            textBox3.Clear(); 
            textBox4.Clear(); 
            textBox5.Clear(); 
            comboBox1.Text = ""; 
            textBox3.Focus();
            MessageBox.Show("Kayıt İşlemi Başarıyla tamamlandı.");
        }
    }
}
