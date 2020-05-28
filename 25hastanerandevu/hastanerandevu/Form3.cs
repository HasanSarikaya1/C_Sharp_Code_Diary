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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        string tcno = "";
        string klinikidsi = "";
        public void bilgilerigetir()
        {
            tcno = Form1.tc.ToString();
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * From hastabilgi where TC_Kimlik_No='" + tcno + "' ", con);
            cmd.ExecuteNonQuery();
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                label6.Text = rd["TC_Kimlik_No"].ToString();
                label7.Text = rd["Ad"].ToString() + " " + rd["Soyad"].ToString();
                label8.Text = rd["Doğum_Yeri"].ToString() + " / " + rd["Doğum_Tarihi"].ToString();
                label9.Text = rd["Cinsiyet"].ToString();
                label10.Text = rd["Telefon"].ToString();

            }
            con.Close();
        }
        void klinikgöster()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            con.Open();
            try
            {
                comboBox1.Items.Clear();
                OleDbCommand cmd = new OleDbCommand("Select * From Klinikler", con);
                cmd.ExecuteNonQuery();
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd["Klinik_Adi"].ToString());
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            con.Close();
        }
        void klinikid()
        {
            try
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Select * From Klinikler where Klinik_Adi='" + comboBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    klinikidsi = dr["Klinik_ID"].ToString();
                }
                con.Close();
                doktorgöster();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                con.Close();
            }
        }
        void doktorgöster()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            con.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("Select * From Doktorlar where Klinik_Id=@id", con);
                cmd.Parameters.AddWithValue("@id", klinikidsi);
                cmd.ExecuteNonQuery();
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox2.Items.Add(rd["DoktorAdiSoyadi"].ToString());
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            con.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1, "Bilgilerini Güncelle");
            açıklama.SetToolTip(button3, "Randevu Al");
            açıklama.SetToolTip(button2, "Bilgileri Yenile");
            açıklama.SetToolTip(button4, "Randevularımı Göster");
            açıklama.SetToolTip(button5, "Programı Kapat");
            bilgilerigetir();
            klinikgöster();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.frm4.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bilgilerigetir();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            klinikid();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            con.Open();
            OleDbCommand maxCommand = new OleDbCommand("SELECT max(Randevu_Id) from randevubilgi", con);
            Int32 max = (Int32)maxCommand.ExecuteScalar();
            max++;
            int randevumaxno = max;
            con.Close();
            if (comboBox1.Text==""&&comboBox2.Text==""&&comboBox3.Text=="")
            {
                MessageBox.Show("Lütfen Randevu Seçiminde Boş Alan Bırakmayınız.","Bilgilendirme");
            }
            else
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("insert into randevubilgi (Randevu_Id,Tc,Hasta_Adi,Klinik_Adi,Doktor_Adi,Tarih,Saat) values ('" + randevumaxno + "','" + Form1.tc + "','" + label7.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','" + comboBox3.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Randevu İşleminiz Başarıyla Gerçekleşmiştir");
                con.Close();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            klinikgöster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.frm6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
