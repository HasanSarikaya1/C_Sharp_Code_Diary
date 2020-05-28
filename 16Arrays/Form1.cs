using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16Arrays
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] iller = new string[24];
        int indis, uzun;
        string sehir;
        char harf;
        void labelkontrol()
        {
            label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label16.Visible = label17.Visible = label18.Visible = label19.Visible = label20.Visible = label21.Visible = false;
        }
        string[] siniflistesi = new string[16];
        int indir = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            siniflistesi[indir] = textBox1.Text;
            indir++;
            textBox1.Clear();
            label1.Text = "Sınıfın " + (indir) + " . kişisi";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < 16; i++)
            {
                if (siniflistesi[i]==null)
                {
                    continue;
                }
                listBox1.Items.Add(siniflistesi[i]);
            }
        }
        int[] ort = new int[1000];
        int miktar = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            ort[miktar] = Convert.ToInt32(textBox2.Text);
            miktar++;
            textBox2.Clear();
            int toplam=0;
            for (int i = 0; i < 1000; i++)
            {
                toplam = ort[i] + toplam;
            }
            label4.Text = "Girdiğiniz Sayıların Ortalaması: " +(toplam / miktar).ToString();

        }
        string ifade;
        int uzunluk;
        private void button4_Click(object sender, EventArgs e)
        { 
            
            ifade = textBox3.Text;
            uzunluk = ifade.Length;
            for (int i = 0; i < uzunluk; i++)
            {
                label5.Text+=ifade[i].ToString() + "*";
                
            }
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string sayi = textBox4.Text;
            uzunluk = sayi.Length;
            int toplam = 0;
            for (int i = 0; i < uzunluk; i++)
            {
                toplam = toplam + Convert.ToInt32(sayi[i].ToString());
            }
            label6.Text = toplam.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Girilen Sayının Rakamlarının Toplamını Bulma");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Random üret = new Random();
            indis = üret.Next(0,24);
            sehir = iller[indis];
            label22.Text = sehir;
            uzun = sehir.Length;
            labelkontrol();
            switch (uzun)
            {
                case 3:
                    label8.Visible = label9.Visible = label10.Visible = true;
                    break;
                case 4:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = true;
                    break;
                case 5:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = true;
                    break;
                case 6:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = true;
                    break;
                case 7:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = true;
                    break;
                case 8:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = true;
                    break;
                case 9:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label16.Visible = true;
                    break;
                case 10:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label16.Visible = label17.Visible = true;
                    break;
                case 11:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label16.Visible = label17.Visible = label18.Visible = true;
                    break;
                case 12:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label16.Visible = label17.Visible = label18.Visible = label19.Visible =  true;
                    break;
                case 13:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label16.Visible = label17.Visible = label18.Visible = label19.Visible = label20.Visible =  true;
                    break;
                case 14:
                    label8.Visible = label9.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label14.Visible = label15.Visible = label16.Visible = label17.Visible = label18.Visible = label19.Visible = label20.Visible = label21.Visible = true;
                    break;
                default:
                    break;
            }
            label22.Enabled = true;
            textBox5.Enabled = true;
            button8.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (textBox5.Text.Length==1)
            {
                harf = Convert.ToChar(textBox5.Text.ToUpper());
                for (int i = 0; i < uzun; i++)
                {
                    if (sehir[i]==harf)
                    {
                        switch (i)
                        {
                            case 0:
                                label8.Text = harf.ToString();
                                break;
                            case 1:
                                label9.Text = harf.ToString();
                                break;
                            case 2:
                                label10.Text = harf.ToString();
                                break;
                            case 3:
                                label11.Text = harf.ToString();
                                break;
                            case 4:
                                label12.Text = harf.ToString();
                                break;
                            case 5:
                                label13.Text = harf.ToString();
                                break;
                            case 6:
                                label14.Text = harf.ToString();
                                break;
                            case 7:
                                label15.Text = harf.ToString();
                                break;
                            case 8:
                                label16.Text = harf.ToString();
                                break;
                            case 9:
                                label17.Text = harf.ToString();
                                break;
                            case 10:
                                label18.Text = harf.ToString();
                                break;
                            case 11:
                                label19.Text = harf.ToString();
                                break;
                            case 12:
                                label20.Text = harf.ToString();
                                break;
                            case 13:
                                label21.Text = harf.ToString();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            else if (textBox5.Text.Length > 1)
            {
                textBox5.Text = sehir.ToUpper();
                if (sehir == textBox5.Text)
                {
                    MessageBox.Show("Tebrikler Bildiniz !!!");
                    labelkontrol();
                }
                else
                {
                    MessageBox.Show("Maalesef Bilemediniz :(");
                    Form1_Load(sender, e);
                    labelkontrol();
                }
            }
        }
        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            labelkontrol();
            iller[0] = "MUŞ"; iller[1] = "VAN"; iller[2] = "KARS"; iller[3] = "KİLİS"; iller[4] = "AĞRI"; iller[5] = "IĞDIR"; iller[6] = "HATAY"; iller[7] = "SİİRT";
            iller[8] = "BAYBURT"; iller[9] = "ERZURUM"; iller[10] = "ERZİNCAN"; iller[11] = "KIRŞEHİR"; iller[12] = "ARTVİN"; iller[13] = "AFYONKARAHİSAR"; iller[14] = "ŞANLIURFA"; iller[15] = "İSTANBUL";
            iller[16] = "GAZİANTEP"; iller[17] = "KAHRAMANMARAŞ"; iller[18] = "TEKİRDAĞ"; iller[19] = "ÇANAKKALE"; iller[20] = "ORDU"; iller[21] = "RİZE"; iller[22] = "UŞAK"; iller[23] = "GÜMÜŞHANE";
        }
    }
}
