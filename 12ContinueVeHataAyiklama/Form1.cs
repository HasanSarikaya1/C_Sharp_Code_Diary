using System;
using System.Windows.Forms;

namespace _12ContinueVeHataAyiklama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 ile 20 arasındaki sayıları 11 dışında listboxa yazdırma");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 21; i++)
            {
                if (i == 11)
                {
                    continue;
                }
                listBox1.Items.Add(i);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Textbox'dan girilen sayıyı 1'e kadar kendisi kadar tekrarlayıp alt alta yazan program");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string ifade=" ";
            int a = 0;
            int sayi = Convert.ToInt32(textBox1.Text);
            for (int sutun = 0; sutun <= sayi; sutun++)
            {
               
                a++;
                for (int satir = 0; satir <= sayi; satir++)
                {
                    ifade = ifade + a.ToString();
                    if (satir == sayi)
                    {
                        listBox2.Items.Add(ifade);
                    }
                }
                
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int s1=Convert.ToInt32(textBox2.Text);
                int s2 = Convert.ToInt32(textBox3.Text);
                string islem = comboBox1.Text;
                if (islem=="+")
                {
                    label4.Text = "Sonuç : " + (s1 + s2);
                }
                else if (islem=="-")
                {
                    label4.Text = "Sonuç : " + (s1 - s2);
                }
                else if (islem == "*")
                {
                    label4.Text = "Sonuç : " + (s1 * s2);
                }
                else if (islem == "/")
                {
                    label4.Text = "Sonuç : " + (s1 / s2);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Alındı.");
                Application.Restart();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {
                int s1 = Convert.ToInt32(textBox4.Text);
                int s2 = Convert.ToInt32(textBox5.Text);
                int s3 = Convert.ToInt32(textBox6.Text);
                int sonuc;

                if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    sonuc = s1 + s2 + s3;
                    label8.Text = "Üçgenin Çevresi İçin Sonuç : " + sonuc.ToString();
                }

            }
            catch
            {
                
                if (textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
                {
                    MessageBox.Show("Eksik veya hatalı değer girildi program tekrar başlatılacak...");
                    Application.Restart();
                }
                else if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text == "")
                {
                    int s1 = Convert.ToInt32(textBox4.Text);
                    int s2 = Convert.ToInt32(textBox5.Text);
                    int sonuc = s1 * 2 + s2 * 2;
                    label8.Text = "Dikdörtgenin Çevresi İçin Sonuç : " + sonuc.ToString();
                }
                else if (textBox4.Text != "" && textBox5.Text == "" && textBox6.Text == "")
                {
                    int s1 = Convert.ToInt32(textBox4.Text);
                   
                    int sonuc = 2 * 3 * s1;
                    label8.Text = "Dairenin Çevresi İçin Sonuç : " + sonuc.ToString();
                }
                
                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Textboxların 3 tanesine değer girilirse üçgenin 2 tanesine değer girilirse dikdörtgenin,1 tanesine değer girilirse dairenin çevresini bulan ve hataları engelliyen programı yazınız...");
        }
    }
}
