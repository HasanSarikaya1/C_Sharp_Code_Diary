using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17MultidimensionalArrays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int satırno = 0;
        string[,] iller = new string[81, 3];
        private void button1_Click(object sender, EventArgs e)
        {
            int kontrol = 0;
            iller[satırno, 0] = textBox1.Text;
            string yeni = "";
            string sehiradi = textBox2.Text;
            for (int i = 0; i < sehiradi.Length; i++)
            {
                if (i == 0)
                {
                    yeni = yeni + sehiradi[i].ToString().ToUpper();
                }
                else
                {
                    yeni = yeni + sehiradi[i].ToString().ToLower();
                }
            }
            for (int i = 0; i < 81; i++)
            {
                if (yeni == iller[i, 1])
                {
                    kontrol = 1;
                    break;
                }
            }
            if (kontrol == 1)
            {
                MessageBox.Show("Daha Önce Girdiniz...");
            }
            else if (kontrol == 0)
            {
                iller[satırno, 1] = yeni;
                iller[satırno, 2] = comboBox1.Text;
            }
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "";
            satırno++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            comboBox1.Text = "";
            for (int i = 0; i < 81; i++)
            {
                if (iller[i, 0] == textBox1.Text)
                {
                    textBox2.Text = iller[i, 1];
                    comboBox1.Text = iller[i, 2];
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < 81; i++)
            {
                if (iller[i, 2] == comboBox1.Text)
                {
                    listBox1.Items.Add(iller[i, 0] + "\t" + iller[i, 1] + "\t" + iller[i, 2]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Plaka no,il adı ve bölge girildiğinde dizinin içerisine kayıt eden sonrasında bölge seçilip listele dendiğinde o bölgedeki kaydedilmiş illeri plaka numaralarıyla birlikte listbox'a yazdıran program");
        }
        int sayi = 1;
        int listno = 0;
        int yenisatirno = 0;
        string[,] ogrenci = new string[100, 5];
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult kayit = MessageBox.Show("Kayıt İşlemini Tamamlamak İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (textBox4.Text == ""|| textBox5.Text==""||textBox6.Text==""||comboBox2.Text=="")
            {
                MessageBox.Show("Boş Alan Bırakmayınız...");
            }
            else if (kayit==DialogResult.No)
            {
                MessageBox.Show("Kayıt İşlemi İsteğiniz Üzerine Gerçekleştirilmedi :)");
            }
            else if (kayit==DialogResult.Yes)
            {
                ogrenci[yenisatirno, 0] = textBox3.Text;
                ogrenci[yenisatirno, 1] = textBox4.Text;
                ogrenci[yenisatirno, 2] = textBox5.Text;
                ogrenci[yenisatirno, 3] = textBox6.Text;
                ogrenci[yenisatirno, 4] = comboBox2.Text;
                yenisatirno++;
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                comboBox2.Text = "";
                MessageBox.Show("Kayıt İşlemi Başarıyla Tamamlandı...");
                sayi++;
                textBox3.Text = sayi.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Text = sayi.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("SIRA NO   NO   AD   SOYAD   CİNSİYET");
            for (int i = 0; i < yenisatirno; i++)
            {
                listBox2.Items.Add(ogrenci[i, 0] +"\t" + ogrenci[i, 1] + "\t" + ogrenci[i, 2]+ "\t"+ogrenci[i,3]+ "\t"+ogrenci[i,4]);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult güncellle = MessageBox.Show("Seçmiş Olduğunuz Kayıt Güncellenecek ! Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (güncellle==DialogResult.Yes)
            {
               
                ogrenci[listno - 2, 0] = textBox3.Text;
                ogrenci[listno - 2, 1] = textBox4.Text;
                ogrenci[listno - 2, 2] = textBox5.Text;
                ogrenci[listno - 2, 3] = textBox6.Text;
                ogrenci[listno - 2, 4] = comboBox2.Text;
                MessageBox.Show("Kayıt İşlemi Başarıyla Tamamlandı :)");
                button5_Click(sender, e);
            }
            else if (güncellle==DialogResult.No)
            {
                MessageBox.Show("Güncelleme İşlemi Yapılmadı");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show("Seçmiş Olduğunuz Kayıt Silinecek ! Devam etmek istiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (sil == DialogResult.Yes)
            {
                ogrenci[listno - 2, 0] = "";
                ogrenci[listno - 2, 1] = "";
                ogrenci[listno - 2, 2] = "";
                ogrenci[listno - 2, 3] = "";
                ogrenci[listno - 2, 4] = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                comboBox2.Text = "";
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
            else if (sil == DialogResult.No)
            {
                MessageBox.Show("Silme İşlemi Yapılmadı");
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Items.Add("SIRA NO   NO   AD   SOYAD   CİNSİYET");
            for (int i = 0; i < yenisatirno; i++)
            {
                if (comboBox3.Text=="Ada Göre")
                {
                    if (textBox7.Text==ogrenci[i,2])
                    {
                        
                        listBox2.Items.Add(ogrenci[i, 0] + "\t" + ogrenci[i, 1] + "\t" + ogrenci[i, 2] + "\t" + ogrenci[i, 3] + "\t" + ogrenci[i, 4]);
                        
                        
                    }
                    else
                    {
                        continue;
                        
                        
                    }
                }
                else if (comboBox3.Text=="Numaraya Göre")
                {
                    if (textBox7.Text == ogrenci[i, 1])
                    {
                        listBox2.Items.Add(ogrenci[i, 0] + "\t" + ogrenci[i, 1] + "\t" + ogrenci[i, 2] + "\t" + ogrenci[i, 3] + "\t" + ogrenci[i, 4]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (comboBox3.Text=="Soyada Göre")
                {
                    if (textBox7.Text == ogrenci[i, 3])
                    {

                        listBox2.Items.Add(ogrenci[i, 0] + "\t" + ogrenci[i, 1] + "\t" + ogrenci[i, 2] + "\t" + ogrenci[i, 3] + "\t" + ogrenci[i, 4]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2_Click(sender, e);
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            try
            {
                listno = listBox2.SelectedIndex;
                listno = listno + 1;
                if (listno<0)
                {
                    MessageBox.Show("Kişi Seçimi yapın.");
                }
                else
                {
                    textBox3.Text = ogrenci[listno - 2, 0];
                    textBox4.Text = ogrenci[listno - 2, 1];
                    textBox5.Text = ogrenci[listno - 2, 2];
                    textBox6.Text = ogrenci[listno - 2, 3];
                    comboBox2.Text = ogrenci[listno - 2, 4];
                }
            }
            catch (Exception)
            {
                
                
            }
        }
    }
}
