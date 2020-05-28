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

namespace bilgisayarsatis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Form1 frm1=new Form1();
        public static Form2 frm2=new Form2();
        public static Form3 frm3=new Form3();
        public static Form4 frm4 = new Form4();
        public static Form5 frm5 = new Form5();
        public static Form6 frm6 = new Form6();
        public static string kuladi, sifre,girisyapan;
        public static bool elemangirdimi = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            OleDbCommand cmd = new  OleDbCommand("SELECT adminad,adminsif from adminler", con);
            con.Open();
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                kuladi = oku["adminad"].ToString();
                sifre = oku["adminsif"].ToString();
            }
            con.Close();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1,"Giriş Yap.");
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        OleDbDataReader dr2;
        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu Program Hasan Sarıkaya Ve Tuğra Öztürk Tarafından Sistem Analizi Ve Tasarımı Dersi İçin Yapılmıştır.");
            System.Diagnostics.Process.Start("https://www.atauni.edu.tr"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM elemanbil where Eleman_TC='" + textBox1.Text + "'AND Eleman_sif='" + textBox2.Text + "'";
                dr = cmd.ExecuteReader();
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (dr.Read())
                    {
                        elemangirdimi = true;
                        girisyapan = textBox1.Text;
                        MessageBox.Show("Kullanıcı Adı Ve Şifre Doğru.", "Giriş Yapılıyor...");
                        frm2.Show();
                        this.Hide();
                        con.Close();
                    }
                    else if (elemangirdimi == false)
                    {
                        con.Close();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "SELECT * FROM adminler where adminad='" + textBox1.Text + "'AND adminsif='" + textBox2.Text + "'";
                        dr2 = cmd.ExecuteReader();
                        if (dr2.Read())
                        {
                            MessageBox.Show("Admin Girişi Başarılı.");
                            frm2.Show();
                            this.Hide();
                            con.Close();
                        }
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
                MessageBox.Show(hata.Message);
                throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Giriş Bilgisi Kullanıcı Adı : 111111111111 (12 tane 1) Şifreler Sabit :12345 (Program İçindeki Güvenlik Kodu'da Buna Dahil)");
        }
    }
}
