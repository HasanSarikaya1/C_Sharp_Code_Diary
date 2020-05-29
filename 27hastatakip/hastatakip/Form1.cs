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

namespace hastatakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hasta.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adaptor = new OleDbDataAdapter(); DataSet tasima = new DataSet();
        string resimo;
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adaptor = new OleDbDataAdapter("Select * from hasta", baglanti);
            adaptor.Fill(tasima, "hasta");
            dataGridView1.DataSource = tasima.Tables["hasta"];
            adaptor.Dispose();
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1, "Kişi Aramak İçin Tıklayınız...");
            açıklama.SetToolTip(button2, "Kişi Eklemek İçin Tıklayınız...");
            açıklama.SetToolTip(button3, "Kişi Güncellemek İçin Tıklayınız...");
            açıklama.SetToolTip(button4, "Kişi Silmek İçin Tıklayınız...");
            açıklama.SetToolTip(button5, "Kişi Resmi İçin Tıklayınız...");
            listele();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox9.Text = pictureBox1.ImageLocation;
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox1.Text != "" && richTextBox1.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into hasta(h_tc,h_adi,h_soyadi,h_telefonu,h_mail,h_adresi,h_yatis_tarihi,h_cikis_tarihi,h_ilac,h_teshis,h_ucret,h_resim) Values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + textBox5.Text + "','" + richTextBox1.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + resimo + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                tasima.Clear();
                listele();
            }
            else
            {
                MessageBox.Show("Boş alan geçmeyiniz!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                komut = new OleDbCommand();
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "update hasta set h_tc='" + textBox2.Text + "', h_adi='" + textBox3.Text + "', h_soyadi='" + textBox4.Text + "', h_telefonu='" + maskedTextBox1.Text + "', h_mail='" + textBox5.Text + "', h_adresi='" + richTextBox1.Text + "', h_yatis_tarihi='" + dateTimePicker1.Text + "', h_cikis_tarihi='" + dateTimePicker2.Text + "', h_ilac='" + textBox6.Text + "', h_teshis='" + textBox7.Text + "', h_ucret='" + textBox8.Text + "', h_resim='" + textBox9.Text + "' where h_id=" + textBox1.Text + "";
                komut.ExecuteNonQuery();
                baglanti.Close();
                tasima.Clear();
                listele();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata+"Programda Hata Oluştu.Lütfen Kontrolleri Doğru Yapınız.");
                throw;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult c;
                c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (c == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Delete from hasta where h_id=" + textBox1.Text + "";
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    tasima.Clear();
                    listele();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata + "Programda Hata Oluştu.Lütfen Kontrolleri Doğru Yapınız.");
                throw;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox9.Text = openFileDialog1.FileName;
            }
            int s = 92;
            string harf = ((char)s).ToString();
            string yazi = textBox9.Text; 
            string metin = "";
            int yaziuzunlugu = yazi.Length;
            for (int i = yaziuzunlugu; i > 0; i--)
            {
                if (yazi.Substring(i - 1, 1) == harf)
                {
                    break;
                }
                metin = metin + (yazi.Substring(i - 1, 1));
            }
            int uzunluk = metin.Length; string kelime = "";
            for (int a = uzunluk; a > 0; a--)
            {
                kelime = kelime + (metin.Substring(a - 1, 1));
            }
            textBox9.Text = "Resim/" + kelime;
            resimo = textBox9.Text;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            richTextBox1.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text=="No'ya Göre")
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hasta.accdb");
                adaptor = new OleDbDataAdapter("Select * from hasta where h_id like '%" + textBox10.Text + "%'", baglanti);
                tasima = new DataSet();
                baglanti.Open();
                adaptor.Fill(tasima, "hasta");
                dataGridView1.DataSource = tasima.Tables["hasta"];
                baglanti.Close();
                textBox10.Clear();
            }
            if (comboBox1.Text=="Ad'a Göre")
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hasta.accdb");
                adaptor = new OleDbDataAdapter("Select * from hasta where h_adi like '%" + textBox10.Text + "%'", baglanti);
                tasima = new DataSet();
                baglanti.Open();
                adaptor.Fill(tasima, "hasta");
                dataGridView1.DataSource = tasima.Tables["hasta"];
                baglanti.Close();
                textBox10.Clear();
            }
            if (comboBox1.Text == "Soyad'a Göre")
            {
                baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hasta.accdb");
                adaptor = new OleDbDataAdapter("Select * from hasta where h_soyadi like '%" + textBox10.Text + "%'", baglanti);
                tasima = new DataSet();
                baglanti.Open();
                adaptor.Fill(tasima, "hasta");
                dataGridView1.DataSource = tasima.Tables["hasta"];
                baglanti.Close();
                textBox10.Clear();
            }
            
        }
    }
}
