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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        OleDbDataReader dr2;
        public static Form1 frm1 = new Form1();
        public static Form2 frm2 = new Form2();
        public static Form3 frm3 = new Form3();
        public static Form4 frm4 = new Form4();
        public static Form5 frm5 = new Form5();
        public static Form6 frm6 = new Form6();
        public static Form7 frm7 = new Form7();
        public static Form8 frm8 = new Form8();
        public static Form9 frm9 = new Form9();
        public static Form10 frm10 = new Form10();
        public static string tc = "";
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                frm2.Show();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1,"Giriş Yap");
            açıklama.SetToolTip(button2, "Kayıt Ol");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM hastabilgi where TC_Kimlik_No='" + textBox1.Text + "'AND Parola='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (dr.Read())
                {
                    tc = textBox1.Text;
                    MessageBox.Show("Kullanıcı Adı Ve Şifre Doğru.", "Giriş Yapılıyor...");
                    frm3.Show();
                    this.Hide();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Veya Şifrenizi Yanlış Girdiniz.", "Bilgilendirme Penceresi");
                    textBox1.Clear();
                    textBox2.Clear();
                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
                con.Close();
            }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Programda Hata Oluştu."+hata.ToString());
                throw;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            frm8.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta Girişi İçin : Kullanıcı Adı=11111111111(11 adet 1) Şifreler Sabit 12345 Admin Girişi İçin kullanıcı adı alanına hasansarikaya Yazılacak Şifre 12345  Doktor Girişi İçin Doktor adı yani ZiyaAyık şifre 12345");
        }
    }
}
