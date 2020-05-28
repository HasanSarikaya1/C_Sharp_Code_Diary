using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _24SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        string yol= "Data Source=(LocalDb)\\hasandb; Initial Catalog=okul; Integrated Security=true;";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(yol);
            if (baglan.State==ConnectionState.Closed)
            {
                baglan.Open();
            }
            SqlCommand komut = new SqlCommand("Select * from ogrenci", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(yol);
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand kaydet = new SqlCommand("Insert into ogrenci(no,adi,soyadi,cinsiyet) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "')",baglanti);
            kaydet.ExecuteNonQuery();
            MessageBox.Show("Kayıt İşlemi Başarıyla Tamamlandı.");
            if (baglanti.State==ConnectionState.Open)
            {
                baglanti.Close();
            }
            button1_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(yol);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sil = new SqlCommand("delete ogrenci where no="+dataGridView1.CurrentRow.Cells["no"].Value.ToString(),baglanti);
            sil.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silme İşlemi Tamamlandı.");
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            button1_Click(sender, e);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(yol);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand guncelle = new SqlCommand("update ogrenci set no='" + textBox1.Text + "',adi='" + textBox2.Text + "',soyadi='" + textBox3.Text + "',cinsiyet='" + comboBox1.Text + "' where no=" + textBox1.Text + "",baglanti);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncelleme İşlemi Tamamlandı.");
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            button1_Click(sender, e);

        }
    }
}
