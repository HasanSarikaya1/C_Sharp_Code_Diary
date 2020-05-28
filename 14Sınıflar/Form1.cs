using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14Sınıflar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hasan yeniclass = new hasan();
            yeniclass.Kenar1 =Convert.ToInt32(textBox1.Text);
            yeniclass.Kenar2 = Convert.ToInt32(textBox2.Text);
            label3.Text = "Alan : " + yeniclass.alan().ToString();
            label4.Text = "Çevre : " + yeniclass.cevre().ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogrenciekle eklesinif = new ogrenciekle();
            eklesinif.adi = textBox3.Text;
            eklesinif.soyadi = textBox4.Text;
            eklesinif.sinif = textBox5.Text;
            eklesinif.duzenle();
            listBox1.Items.Add(eklesinif.ekle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int s1 = Convert.ToInt32(textBox6.Text);
                int s2 = Convert.ToInt32(textBox7.Text);
                sinif sf = new sinif();
                label10.Text = sf.sayi(textBox6.Text, textBox7.Text);
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata : "+hata.Message);
            }
        }
    }
}
