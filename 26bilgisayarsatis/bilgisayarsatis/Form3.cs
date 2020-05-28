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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public static int elemanno;
        void griddoldur()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            da = new OleDbDataAdapter("SELECT Eleman_No,Eleman_Ad,Eleman_Soyad,Eleman_TC,Eleman_Tel,Eleman_Adres from elemanbil", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "elemanbil");
            dataGridView1.DataSource = ds.Tables["elemanbil"];
            con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form1.frm2.Show();
            this.Hide();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1, "Eleman Ekle.");
            açıklama.SetToolTip(button6, "Eleman Ara.");
            açıklama.SetToolTip(button2, "Eleman Güncelle.");
            açıklama.SetToolTip(button3, "Eleman Sil.");
            açıklama.SetToolTip(button5, "Alanları Temizle");
            açıklama.SetToolTip(button4, "Geri Çık");
            griddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    if (textBox7.Text != Form1.sifre)
                    {
                        MessageBox.Show("Güvenlik Kodu Yanlış.", "Bilgilendirme Penceresi");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        maskedTextBox1.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        OleDbCommand maxCommand = new OleDbCommand("SELECT max(Eleman_No) from elemanbil", con);
                        Int32 max = (Int32)maxCommand.ExecuteScalar();
                        max++;
                        elemanno = max;
                        cmd.CommandText = "insert into elemanbil (Eleman_No,Eleman_Ad,Eleman_Soyad,Eleman_sif,Eleman_TC,Eleman_Tel,Eleman_Adres) values ('" + elemanno + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + textBox5.Text + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Eleman Ekleme Başarılı.", "Bilgilendirme Penceresi");
                        griddoldur();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.","Bilgilendirme Penceresi");
                    textBox1.Focus();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Veri Girişi.","Uyarı !");
            }
            
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsWhiteSpace(e.KeyChar);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsWhiteSpace(e.KeyChar);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" | textBox2.Text != "" | textBox3.Text != "" | maskedTextBox1.Text != "" | textBox5.Text != "" | textBox6.Text != "" | textBox7.Text != "")
                {
                    if (textBox7.Text != Form1.sifre)
                    {
                        MessageBox.Show("Güvenlik Kodu Yanlış.", "Bilgilendirme Penceresi");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        maskedTextBox1.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "update elemanbil set Eleman_ad='" + textBox1.Text + "',Eleman_Soyad='" + textBox2.Text + "',Eleman_TC='" + textBox3.Text + "',Eleman_Tel='" + maskedTextBox1.Text + "',Eleman_Adres='" + textBox5.Text + "',Eleman_sif='" + textBox6.Text + "' where Eleman_No=" + textBox8.Text + "";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Eleman Bilgileri Başarıyla Güncellendi.", "Bilgilendirme Penceresi");
                        griddoldur();
                    }
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız.", "Uyarı !");
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
                if (textBox1.Text != "" | textBox2.Text != "" | textBox3.Text != "" | maskedTextBox1.Text != "" | textBox5.Text != "" | textBox6.Text != "" | textBox7.Text != "")
                {
                    if (textBox7.Text != Form1.sifre)
                    {
                        MessageBox.Show("Güvenlik Kodu Yanlış.", "Bilgilendirme Penceresi");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        maskedTextBox1.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox1.Focus();
                    }
                    else
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "delete from elemanbil where Eleman_No=" + textBox8.Text + "";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Eleman Silme Başarılı.", "Bilgilendirme Penceresi");
                        griddoldur();
                    }
                }
                else
                {
                    MessageBox.Show("Boş Alan Bırakmayınız.", "Uyarı !");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Veri Girişi.", "Uyarı !");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Ada Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from elemanbil where Eleman_Ad like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "elemanbil");
                    dataGridView1.DataSource = ds.Tables["elemanbil"];
                    con.Close();
                    textBox4.Clear();
                }
                if (comboBox1.Text == "Soyada Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from elemanbil where Eleman_Soyad like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "elemanbil");
                    dataGridView1.DataSource = ds.Tables["elemanbil"];
                    con.Close();
                    textBox4.Clear();
                }
                if (comboBox1.Text == "No'ya Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from elemanbil where Eleman_No like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "elemanbil");
                    dataGridView1.DataSource = ds.Tables["elemanbil"];
                    con.Close();
                    textBox4.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Boş Alan Bırakmayınız...","Bilgilendirme");
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
