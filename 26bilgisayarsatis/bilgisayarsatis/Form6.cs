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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        bool stokvarmi = false;
        void müsterigrid()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            da = new OleDbDataAdapter("SELECT Müşteri_Adı,Müşteri_Soyadı,TC_Kimlik_No from müsteribil", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "müsteribil");
            dataGridView2.DataSource = ds.Tables["müsteribil"];
            con.Close();
        }
        void satisgrid()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            da = new OleDbDataAdapter("SELECT * from satisbil", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "satisbil");
            dataGridView1.DataSource = ds.Tables["satisbil"];
            con.Close();
        }
        void ürünfiyat()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            con.Open();
            try
            {
                OleDbCommand cmd = new OleDbCommand("Select Ürün_Fiyatı From ürünbil where Ürün_Adı='" + comboBox2.Text + "'", con);
                cmd.ExecuteNonQuery();
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    textBox5.Clear();
                    textBox5.Text = (rd["Ürün_Fiyatı"].ToString());
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            con.Close();
        }
        void stokkontrol()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            con.Open();
            cmd = new OleDbCommand("Select Adet From ürünbil where Ürün_Adı='" + comboBox2.Text + "'", con);
            OleDbDataReader oku;
            oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                if (int.Parse(textBox7.Text) <= int.Parse(oku[0].ToString()))
                    stokvarmi = true;
            }
            cmd.Dispose();
            con.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button1,"Satış Eklemek İçin Tıklayınız");
            aciklama.SetToolTip(button3, "Satış Silmek İçin Tıklayınız");
            aciklama.SetToolTip(button4, "Ana Ekrana Dönmek İçin Tıklayınız");
            aciklama.SetToolTip(button5, "Alanları Temizlemek İçin Tıklayınız");
            aciklama.SetToolTip(button6, "Arama Yapmak İçin Tıklayınız");
            satisgrid();
            müsterigrid();
            if (Form1.elemangirdimi==true)
            {
                textBox6.Text = Form2.satisyapan.ToString();
            }
            else
            {
                textBox6.Text = Form1.kuladi.ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            con.Open();
            try
            {
                comboBox2.Items.Clear();
                OleDbCommand cmd = new OleDbCommand("Select * From ürünbil where Kategori='" + comboBox3.Text + "'", con);
                cmd.ExecuteNonQuery();
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox2.Items.Clear();
                    comboBox2.Items.Add(rd["Ürün_Adı"].ToString());
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            con.Close();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ürünfiyat();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox9.Text = (int.Parse(textBox5.Text) * int.Parse(textBox7.Text)).ToString();
            }
            catch
            {
                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBox9.Text != "" && textBox6.Text != "")
                {
                    stokkontrol();
                    if (stokvarmi == true)
                    {
                        int ürünadet;
                        ürünadet = int.Parse(textBox7.Text);
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "Insert into satisbil(Müşteri_Adı,Müşteri_Soyad,TC_Kimlik_No,Ürün_Adı,Ürün_Fiyat,Adet,Toplam_Tutar,Tarih,Satış_Yapan) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "'," + textBox7.Text + "," + textBox9.Text + ",'" + dateTimePicker1.Text + "','" + textBox6.Text + "') ";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "Update ürünbil set Adet=Adet-'" + ürünadet + "' where Ürün_Adı='" + comboBox2.Text + "'";
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        con.Close();
                        MessageBox.Show("Kayıt İşlemi Tamamlandı.");
                        satisgrid();
                    }
                    else
                    {
                        MessageBox.Show("Stokta Yeterli Sayıda Ürün Yok.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Boş Alan Bırakmayınız.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu." + hata.ToString());
                throw;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.frm2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ürünadet;
            ürünadet = int.Parse(textBox7.Text);
            try
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from satisbil where Fatura_No=" + textBox8.Text + "";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "Update ürünbil set Adet=Adet+'" + ürünadet + "' where Ürün_Adı='" + comboBox2.Text + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                MessageBox.Show("Satış Silme Başarılı.", "Bilgilendirme Penceresi");
                satisgrid();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu."+hata.ToString());
                throw;
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            satisgrid();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            müsterigrid();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Ad'a Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from satisbil where Müşteri_Adı like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "satisbil");
                    dataGridView1.DataSource = ds.Tables["satisbil"];
                    con.Close();
                    textBox4.Clear();
                }
                if (comboBox1.Text == "Soyada Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from satisbil where Müşteri_Soyad like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "satisbil");
                    dataGridView1.DataSource = ds.Tables["satisbil"];
                    con.Close();
                    textBox4.Clear();
                }
                if (comboBox1.Text == "No'ya Göre")
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
                    da = new OleDbDataAdapter("Select * from satisbil where Fatura_No like '" + textBox4.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "satisbil");
                    dataGridView1.DataSource = ds.Tables["satisbil"];
                    con.Close();
                    textBox4.Clear();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Boş Alan Bırakmayınız...", "Bilgilendirme");
            }
        }
    }
}
