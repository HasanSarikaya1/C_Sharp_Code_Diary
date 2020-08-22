using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _30radio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(0,19);
            listBox1.SelectedIndex = sayi;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.fenomen;
            label1.Text = " Radyo Fenomen ";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.fenomenak;
            label1.Text = " Fenomen Akustik ";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.fenomenrap;
            label1.Text = " Fenomen Rap ";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.fenomenturk;
            label1.Text = " Fenomen Türk ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.fenomenclub;
            label1.Text = " Fenomen Clubbin ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.fenomendans;
            label1.Text = " Fenomen Dans ";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.fenomenpop;
            label1.Text = " Fenomen Pop ";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.power;
            label1.Text = " Power Fm ";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.powergold;
            label1.Text = " Power Gold ";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.powerturkbest;
            label1.Text = " Power Türk En İyiler ";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.powerturkefsane;
            label1.Text = " Power Türk Efsane ";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.powerturkakustik;
            label1.Text = " Power Türk Akustik ";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.powerturk;
            label1.Text = " Power Türk ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.alemfm;
            label1.Text = " Alem Fm ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.kralfm;
            label1.Text = " Kral Fm ";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.kralpop;
            label1.Text = " Kral Pop ";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.joyfm;
            label1.Text = " Joy Fm ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.bestfm;
            label1.Text = " Best Fm ";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.istanbulfm;
            label1.Text = " İstanbul Fm ";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = radyo.erzurum;
            label1.Text = " Erzurum İmaj Fm ";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            trackBar1.Value = 100;
            axWindowsMediaPlayer1.settings.volume = 100;
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string radyoad = listBox1.SelectedItem.ToString();
            if (radyoad=="Radyo Fenomen")
            {
                button13.PerformClick();
            }
            if (radyoad == "Fenomen Rap")
            {
                button11.PerformClick();
            }
            if (radyoad == "Fenomen Türk")
            {
                button12.PerformClick();
            }
            if (radyoad == "Fenomen Clubbin")
            {
                button8.PerformClick();
            }
            if (radyoad == "Fenomem Pop")
            {
                button10.PerformClick();
            }
            if (radyoad == "Power Fm")
            {
                button19.PerformClick();
            }
            if (radyoad == "Fenomen Akustik")
            {
                button27.PerformClick();
            }
            if (radyoad == "Fenomen Dans")
            {
                button9.PerformClick();
            }
            if (radyoad == "Power Gold")
            {
                button20.PerformClick();
            }
            if (radyoad == "Power Türk")
            {
                button18.PerformClick();
            }
            if (radyoad == "Power Türk En İyiler")
            {
                button24.PerformClick();
            }
            if (radyoad == "Power Türk Efsane")
            {
                button23.PerformClick();
            }
            if (radyoad == "Power Türk Akustik")
            {
                button22.PerformClick();
            }
            if (radyoad == "Alem Fm")
            {
                button3.PerformClick();
            }
            if (radyoad == "Kral Fm")
            {
                button16.PerformClick();
            }
            if (radyoad == "Kral Pop")
            {
                button17.PerformClick();
            }
            if (radyoad == "Joy Fm")
            {
                button15.PerformClick();
            }
            if (radyoad == "Best Fm")
            {
                button4.PerformClick();
            }
            if (radyoad == "İstanbul Fm")
            {
                button14.PerformClick();
            }
            if (radyoad == "Erzurum İmaj Fm")
            {
                button7.PerformClick();
            }

        }
        int açkapa = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
            
            if (açkapa%2==0)
            {
                axWindowsMediaPlayer1.settings.volume = 0;
                trackBar1.Value = 0;
                açkapa++;
            }
            else
            {
                axWindowsMediaPlayer1.settings.volume = 100;
                trackBar1.Value = 100;
                açkapa++;
            }
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Random rn = new Random();
            int r, g, b;
            r = rn.Next(0,255);
            b = rn.Next(0, 255);
            g = rn.Next(0, 255);
            BackColor = Color.FromArgb(r,g,b);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Bu Modu Aktif Etmek İstediğine Eminmisin ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                MessageBox.Show(" :) ");
                timer1.Interval = 150;
                timer1.Start();
            }
            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("Hayır dedin ama ben yine bi aktif ediyim beğenirsin");
                timer1.Interval = 150;
                timer1.Start();
            }
            
        }
    }
}
