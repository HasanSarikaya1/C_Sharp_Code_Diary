using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace hastanerandevu
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        public static string adsoyad="";
        private void button1_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Doktorlar where DoktorAdiSoyadi='" + textBox1.Text + "'AND Sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (dr.Read())
                {
                    adsoyad = textBox1.Text;
                    MessageBox.Show("Hoşgeldiniz. Doktor " + adsoyad + "", "Giriş Yapılıyor...");
                    Form1.frm7.Show();
                    this.Hide();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adınız Veya Şifreniz Yanlış");
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız.");
            }
        }
    }
}
