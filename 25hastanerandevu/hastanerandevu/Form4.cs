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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        string tcno = "";
        void reverse()
        {
            tcno = Form1.tc.ToString();
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * From hastabilgi where TC_Kimlik_No='" + tcno + "' ", con);
            cmd.ExecuteNonQuery();
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                textBox1.Text = rd["TC_Kimlik_No"].ToString();
                textBox2.Text = rd["Ad"].ToString();
                textBox3.Text = rd["Soyad"].ToString();
                textBox4.Text = rd["Doğum_Yeri"].ToString();
                maskedTextBox1.Text = rd["Doğum_Tarihi"].ToString();
                maskedTextBox2.Text = rd["Telefon"].ToString();
                textBox5.Text = rd["Parola"].ToString();
            }
            con.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1, "Kaydı Güncelle");
            açıklama.SetToolTip(button2, "Ana Ekrana Dön");
            reverse();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";
            if (radioButton1.Checked == true)
                cinsiyet = "Bay";
            if (radioButton2.Checked == true)
                cinsiyet = "Bayan";

            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "" && textBox5.Text != "" && maskedTextBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (cinsiyet=="")
                {
                    MessageBox.Show("Lütfen Cinsiyetinizi Seçiniz.","Bilgilendirme !");
                }
                else
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
                    cmd = new OleDbCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "update hastabilgi set Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',Cinsiyet='" + cinsiyet + "',Doğum_Yeri='" + textBox4.Text + "',Doğum_Tarihi='" + maskedTextBox1.Text + "',Telefon='" + maskedTextBox2.Text + "',Parola='"+textBox5.Text+"' where TC_Kimlik_No='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Hasta Güncelleme Başarılı.", "Bilgilendirme Penceresi");
                    Form1.frm3.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız.", "Bilgilendirme Penceresi");
                textBox1.Focus();
            }
        }
    }
}
