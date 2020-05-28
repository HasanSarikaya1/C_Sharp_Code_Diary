using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;
using System.IO;

namespace _23WPF_Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timer2.Tick += new EventHandler(timer2_tick); //Örnekleme
            timer2.Interval = new TimeSpan(0, 0, 1);
        }
        int a = 0;
        DispatcherTimer timer2 = new DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
        }
        int b;
        void timer_tick(object sender,EventArgs e)
        {
            DateTime saat = DateTime.Now;
            progressbar1.Value = saat.Hour;
            progressbar2.Value = saat.Minute;
            progressbar3.Value = saat.Second;
            label1.Content = saat.Hour;
            label2.Content = saat.Minute;
            label3.Content = saat.Second;
            if (slider1.Value==progressbar1.Value&&slider2.Value==progressbar2.Value&&b==0)
            {
                timer2.Start();
                MessageBox.Show("Uyan");
                
            }
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            a = 0;
            label7.Content = "Saat : "+slider1.Value.ToString();
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            a = 0;
            label8.Content = "Dakika: " + slider2.Value.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int c;
            
            if (slider2.Value>=55)
            {
                c = Convert.ToInt32(slider2.Value) + 5;
                slider2.Value = c - 60;
                slider1.Value++;
                timer2.Stop();
            }
            else
            {
                slider2.Value = slider2.Value + 5;
                timer2.Stop();
            }
        }
        SoundPlayer player = new SoundPlayer();
        void timer2_tick(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            string path = "C:\\Windows\\Media\\ding.wav";
            player.SoundLocation = path;
            player.Play();
            a++;
            if (a==60)
            {
                timer2.Stop();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            timer2.Stop();
            b++;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog hasan = new OpenFileDialog();
            hasan.Filter = "Metin Dosyaları |*.txt|" + "Bütün Dosyalar |*.*";
            hasan.Title = "Dosya Aç";
            if (hasan.ShowDialog()==true)
            {
                string dosya;
                dosya = hasan.FileName;
                TextReader okuyucu = File.OpenText(dosya);
                listbox1.Items.Add(okuyucu.ReadToEnd());
            }
        }
    }
}
