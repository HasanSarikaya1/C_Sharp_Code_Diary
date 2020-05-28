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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            da = new OleDbDataAdapter("SELECT TC Kimlik No,Ad,Soyad,Cinsiyet,Doğum Yeri,Doğum Tarihi,Telefon,Parola from hastabilgi", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "hastabilgi");
            //dataGridView1.DataSource = ds.Tables["hastabilgi"];
            con.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1, "Kayıt Ol");
            açıklama.SetToolTip(button2, "Ana Sayfaya Dön");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            string cinsiyet = "Seçilmedi";
            if (radioButton1.Checked == true)
                cinsiyet = "Bay";
            if (radioButton2.Checked == true)
                cinsiyet = "Bayan";

            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "" && textBox5.Text != "" && textBox6.Text != "" && maskedTextBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    if (textBox5.Text != textBox6.Text)
                    {
                        MessageBox.Show("Parola Ve Parola Tekrarı Eşleşmiyor", "Bilgilendirme Penceresi");
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox5.Focus();
                    }
                    else
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into hastabilgi (TC_Kimlik_No,Ad,Soyad,Cinsiyet,Doğum_Yeri,Doğum_Tarihi,Telefon,Parola) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + cinsiyet +"','" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "','" + textBox5.Text + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Hasta Ekleme Başarılı.", "Bilgilendirme Penceresi");
                        Form1.frm1.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.", "Bilgilendirme Penceresi");
                    textBox1.Focus();
                }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.frm1.Show();
            this.Hide();
        }
    }
}
