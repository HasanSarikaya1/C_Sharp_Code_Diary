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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public static int müsterino;
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            da = new OleDbDataAdapter("SELECT Müşteri_No,Müşteri_Adı,Müşteri_Soyadı,TC_Kimlik_No,Telefon_No,Adres from müsteribil", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "müsteribil");
            dataGridView1.DataSource = ds.Tables["müsteribil"];
            con.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1, "Müşteri Ekle.");
            açıklama.SetToolTip(button6, "Müşteri Ara.");
            açıklama.SetToolTip(button2, "Müşteri Güncelle.");
            açıklama.SetToolTip(button3, "Müşteri Sil.");
            açıklama.SetToolTip(button5, "Alanları Temizle");
            açıklama.SetToolTip(button4, "Geri Çık");
            griddoldur();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Ad'a Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from müsteribil where Müşteri_Adı like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "müsteribil");
                    dataGridView1.DataSource = ds.Tables["müsteribil"];
                    con.Close();
                    textBox4.Clear();
                }
                if (comboBox1.Text == "Soyada Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from müsteribil where Müşteri_Soyadı like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "müsteribil");
                    dataGridView1.DataSource = ds.Tables["müsteribil"];
                    con.Close();
                    textBox4.Clear();
                }
                if (comboBox1.Text == "No'ya Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from müsteribil where Müşteri_No like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "müsteribil");
                    dataGridView1.DataSource = ds.Tables["müsteribil"];
                    con.Close();
                    textBox4.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Boş Alan Bırakmayınız...", "Bilgilendirme");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.frm2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox2.Clear();
            textBox5.Clear();
            maskedTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "" && textBox5.Text != "")
                {
                    if (true)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "update müsteribil set Müşteri_Adı='" + textBox1.Text + "',Müşteri_Soyadı='" + textBox2.Text + "',TC_Kimlik_No='" + textBox3.Text + "',Telefon_No='" + maskedTextBox1.Text + "',Adres='" + textBox5.Text + "' where Müşteri_No=" + textBox8.Text + "";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Müşteri Bilgileri Başarıyla Güncellendi.", "Bilgilendirme Penceresi");
                        griddoldur();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.", "Bilgilendirme Penceresi");
                    textBox1.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Veri Girişi.", "Uyarı !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            connection.Open();
            OleDbCommand maxCommand = new OleDbCommand("SELECT max(Müşteri_No) from müsteribil", connection);
            Int32 max = (Int32)maxCommand.ExecuteScalar();
            max++;
            müsterino = max;
            con.Close();
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "" && textBox5.Text != "")
                {
                    if (true)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into müsteribil (Müşteri_No,Müşteri_Adı,Müşteri_Soyadı,TC_Kimlik_No,Telefon_No,Adres) values ('" + müsterino + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text  + "','" + textBox5.Text + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Müşteri Ekleme Başarılı.", "Bilgilendirme Penceresi");
                        griddoldur();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.", "Bilgilendirme Penceresi");
                    textBox1.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Veri Girişi.", "Uyarı !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "" && textBox5.Text != "")
                {
                    if (true)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from müsteribil where Müşteri_No=" + textBox8.Text + "";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Müşteri Silme Başarılı.", "Bilgilendirme Penceresi");
                        griddoldur();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.", "Bilgilendirme Penceresi");
                    textBox1.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Veri Girişi.", "Uyarı !");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            griddoldur();
        }
    }
}
