using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08GeçtiKaldıUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            int ort = Convert.ToInt32(textBox1.Text);
            if (ort>=50)
            {
                MessageBox.Show("Direk Geçtiniz..");
            }
            else
            {
                MessageBox.Show("Ortalamanız Düşük Olduğu İçin Kaldınız..Sorumluluk Sınavına Girdiyseniz Aşağıdaki Bölüme Sorumluluk Sınavından Aldığınız Notu Giriniz.");
                label2.Visible = true;
                textBox2.Visible = true;
                textBox1.Enabled = false;
                button1.Visible = false;
                button2.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            textBox2.Visible = false;
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sor = Convert.ToInt32(textBox2.Text);
            if (sor >= 50)
            {
                MessageBox.Show("Sorumluluk Sınavıyla Geçtiniz..");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Enabled = true;
                button2.Visible = false;
                button1.Visible = true;
                label2.Visible = false;
                textBox2.Visible = false;
            }
            else
            {
                MessageBox.Show("Maalesef Kaldınız...");
                textBox1.Enabled = true;
                button2.Visible = false;
                button1.Visible = true;
                label2.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int vize, final, soz, ort;
                vize = Convert.ToInt32(textBox3.Text);
                final = Convert.ToInt32(textBox4.Text);
                soz = Convert.ToInt32(textBox5.Text);
                ort = (vize + final + soz) / 3;
                label6.Text = ort.ToString();
                if (ort >= 50)
                {
                    MessageBox.Show("Ortalamanız : " + ort.ToString() + "Geçtiniz."); ;
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox3.Focus();
                }
                else if (ort <= 49)
                {
                    MessageBox.Show("Ortalamanız: " + ort.ToString() + "Kaldınız."); ;
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox3.Focus();
                }
                else
                {
                    MessageBox.Show("Yanlış Veya Eksik Değer Girildi.");
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox3.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Uygulamada Hata Oluştu.");
                Application.Restart();
            }
            
        }
    }
}
