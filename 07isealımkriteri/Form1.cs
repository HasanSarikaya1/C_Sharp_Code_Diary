using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isealımkriteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool durum = Convert.ToInt32(textBox1.Text) >= 25 && comboBox3.Text != "ORTAOKUL" && comboBox1.Text == "Bay" || comboBox1.Text == "Bayan" && comboBox2.Text == "Evli";
            if (durum==true)
            {
                MessageBox.Show("İşe Alım İçin Uygunsunuz...");
            }
            else
            {
                MessageBox.Show("İşe Alım İçin Uygun Değilsiniz...");
            }
        }
    }
}
