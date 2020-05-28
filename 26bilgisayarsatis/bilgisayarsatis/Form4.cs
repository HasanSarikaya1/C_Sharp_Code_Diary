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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public static string ürünkod = "";
        public static int ürünno;
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            da = new OleDbDataAdapter("SELECT Ürün_No,Ürün_Adı,Ürün_Kodu,Ürün_Fiyatı,Adet,Kategori from ürünbil", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ürünbil");
            dataGridView1.DataSource = ds.Tables["ürünbil"];
            con.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1, "Ürün Ekle");
            açıklama.SetToolTip(button6, "Ürün Ara");
            açıklama.SetToolTip(button1, "Ürün Güncelle");
            açıklama.SetToolTip(button3, "Ürün Sil");
            açıklama.SetToolTip(button5, "Alanları Temizle");
            açıklama.SetToolTip(button4, "Geri Çık");
            griddoldur();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" | textBox2.Text != "" | textBox3.Text != "" | comboBox2.Text != ""|textBox8.Text!="")
                {
                    if (true)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into ürünbil (Ürün_No,Ürün_Adı,Ürün_Kodu,Ürün_Fiyatı,Adet,Kategori) values ('" + ürünno + "','" + textBox1.Text + "','" + textBox5.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Ürün Ekleme Başarılı.", "Bilgilendirme Penceresi");
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "İşlemci")
                ürünkod = "İ";
            if (comboBox2.Text == "Ekran Kartı")
                ürünkod = "E";
            if (comboBox2.Text == "Anakart")
                ürünkod = "A";
            if (comboBox2.Text == "Bellek")
                ürünkod = "B";
            if (comboBox2.Text == "Harddisk")
                ürünkod = "H";
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            connection.Open();
            OleDbCommand maxCommand = new OleDbCommand("SELECT max(Ürün_No) from ürünbil", connection);
            Int32 max = (Int32)maxCommand.ExecuteScalar();
            max++;
            ürünno = max;
            textBox5.Text = ürünkod + ürünno.ToString();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Ada Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from ürünbil where Ürün_Adı like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "ürünbil");
                    dataGridView1.DataSource = ds.Tables["ürünbil"];
                    con.Close();
                    textBox4.Clear();
                }
                if (comboBox1.Text == "Sınıfa Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from ürünbil where Kategori like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "ürünbil");
                    dataGridView1.DataSource = ds.Tables["ürünbil"];
                    con.Close();
                    textBox4.Clear();
                }
                if (comboBox1.Text == "Fiyat'a Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from ürünbil where Ürün_Fiyatı like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "ürünbil");
                    dataGridView1.DataSource = ds.Tables["ürünbil"];
                    con.Close();
                    textBox4.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Boş Alan Bırakmayınız...", "Bilgilendirme");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox1.Clear();
            textBox5.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox2.Text != "" && textBox8.Text != "")
                {
                    if (true)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "update ürünbil set Ürün_Adı='" + textBox1.Text + "',Ürün_Fiyatı='" + textBox2.Text + "',Adet='" + textBox3.Text + "',Kategori='" + comboBox2.Text + "' where Ürün_No=" + textBox8.Text + "";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Ürün Bilgileri Başarıyla Güncellendi.", "Bilgilendirme Penceresi");
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox2.Text != "" && textBox8.Text != "")
                {
                    if (true)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from ürünbil where Ürün_No=" + textBox8.Text + "";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Ürün Silme Başarılı.", "Bilgilendirme Penceresi");
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.frm2.Show();
            this.Hide();
        }
    }
}
