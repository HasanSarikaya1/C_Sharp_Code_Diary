using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13UncheckedVetrycatchfinally
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Değişkenlerin alacağı değerlerin dışında değer girilirse program içerisinde taşma meydana gelir.Bu taşmanın önüne geçmek için 2 seçenek mevcuttur.Bunlardan ilki programlama dilinin derleyicisinin projelerdeki taşma problemlerine karşı etkin hale getirerek yanlış sonuç yerine hata ile kesilmesi sağlanabilir.(check for arithmetic underflow/overflow seçeneği)İkinci seçenek ise checked ifadesiyle kodlama esnasında bu işlem yapılmaktadır.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(textBox1.Text);
            int s2 = Convert.ToInt32(textBox2.Text);
            int sonuc;
            checked
            {
                sonuc = s1 * s2;
            }
            /*unchecked  "Bu komut check for arithmetic overflow/underflow seçeneği aktifken yapılmalıdır."
            {
                sonuc = s1 * s2;
            }*/
            label3.Text = sonuc.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox2.Text) >= 18 && Convert.ToInt32(textBox3.Text) >= 70 && Convert.ToInt32(textBox4.Text) >= 70 && radioButton1.Checked == true || radioButton2.Checked==true && comboBox1.Text=="Olumlu")
                {
                    MessageBox.Show("Uygunsunuz");
                }
                else
                {
                    MessageBox.Show("Uygun Değilsiniz");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata  " + hata.Message); ;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sayac = 2;
            try
            {
                
                int s1 = Convert.ToInt32(textBox6.Text);
                int s2 = Convert.ToInt32(textBox7.Text);
                int s3 = Convert.ToInt32(textBox8.Text);
                while (sayac <= s1)
                {
                    if (s1%sayac==0&&s2%sayac==0&&s3%sayac==0)
                    {
                        label12.Text = sayac.ToString();
                    }
                    sayac++;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata "+hata.Message);  
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }
    }
}
