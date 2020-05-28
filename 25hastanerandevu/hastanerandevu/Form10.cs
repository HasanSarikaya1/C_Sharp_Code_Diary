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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM admins where adminlogin='" + textBox1.Text + "'AND adminpassword='" + textBox2.Text + "'";
                dr = cmd.ExecuteReader();
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (dr.Read())
                    {
                        MessageBox.Show("Kullanıcı Adı Ve Şifre Doğru.", "Giriş Yapılıyor...");
                        Form1.frm5.Show();
                        this.Hide();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.");
                    textBox1.Focus();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Programda Hata Oluştu."+hata.ToString());
                throw;
            }
            
        }
    }
}
