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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataReader dr;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataSet ds;
        private void Form5_Load(object sender, EventArgs e)
        {
            doktorgetir();
            klinikgetir();
            bilgigetir();
        }
        void bilgigetir()
        {
            listView1.Items.Clear();
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            con.Open();
            cmd = new OleDbCommand("Select * From hastabilgi", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["TC_Kimlik_No"].ToString());
                item.SubItems.Add(dr["Ad"].ToString());
                item.SubItems.Add(dr["Soyad"].ToString()); 
                item.SubItems.Add(dr["Cinsiyet"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        void doktorgetir()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            da = new OleDbDataAdapter("SELECT Doktor_Id,Klinik_Id,DoktorAdiSoyadi,Sifre from Doktorlar", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Doktorlar");
            dataGridView2.DataSource = ds.Tables["Doktorlar"];
            con.Close();
        }
        void klinikgetir()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            da = new OleDbDataAdapter("SELECT Klinik_ID,Klinik_Adi from Klinikler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Klinikler");
            dataGridView1.DataSource = ds.Tables["Klinikler"];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            string TC = "";
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem itm = listView1.SelectedItems[0];
                TC = itm.SubItems[0].Text;
            }
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Delete * From hastabilgi where TC_Kimlik_No='" + TC + "'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Hasta Silme Başarılı","Bilgilendirme");
                bilgigetir();
            }
            catch (Exception hata)
            {
                con.Close();
                MessageBox.Show(hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            DialogResult silme = new DialogResult();
            silme = MessageBox.Show("Seçilen Kliniği Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (silme == DialogResult.Yes)
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from Klinikler where Klinik_ID=" + textBox1.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Klinik Silme Başarılı.", "Bilgilendirme Penceresi");
                klinikgetir();
            }
            if (silme == DialogResult.No)
            {
               
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sonklinik;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            DialogResult silme = new DialogResult();
            silme = MessageBox.Show("Yazılan Kliniği Eklemek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (silme == DialogResult.Yes)
            {
                con.Open();
                OleDbCommand maxCommand = new OleDbCommand("SELECT max(Klinik_ID) from Klinikler", con);
                Int32 max = (Int32)maxCommand.ExecuteScalar();
                max++;
                sonklinik = max;
                cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Klinikler (Klinik_ID,Klinik_Adi) values ('" + max + "','" + textBox2.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Klinik Ekleme Başarılı.", "Bilgilendirme Penceresi");
                textBox2.Clear();
                klinikgetir();
            }
            if (silme == DialogResult.No)
            {

            }
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            DialogResult silme = new DialogResult();
            silme = MessageBox.Show("Seçilen Doktoru Silmek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (silme == DialogResult.Yes)
            {
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "delete from Doktorlar where Doktor_Id=" + textBox3.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Doktor Silme Başarılı.", "Bilgilendirme Penceresi");
                doktorgetir();
            }
            if (silme == DialogResult.No)
            {

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text!=""&&textBox5.Text!=""&&textBox6.Text!="")
            {
                int sondoktor;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
                DialogResult silme = new DialogResult();
                silme = MessageBox.Show("Yazılan Doktoru Eklemek İstiyormusunuz ?", "Uyarı", MessageBoxButtons.YesNo);
                if (silme == DialogResult.Yes)
                {
                    con.Open();
                    OleDbCommand maxCommand = new OleDbCommand("SELECT max(Doktor_Id) from Doktorlar", con);
                    Int32 max = (Int32)maxCommand.ExecuteScalar();
                    max++;
                    sondoktor = max;
                    cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Doktorlar (Doktor_Id,Klinik_Id,DoktorAdiSoyadi,Sifre) values ('" + max + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox6.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Doktor Ekleme Başarılı.", "Bilgilendirme Penceresi");
                    textBox4.Clear();
                    textBox5.Clear();
                    doktorgetir();
               }
                if (silme == DialogResult.No)
                {

                }
            }
            else
            {
                MessageBox.Show("Klinik No'su Ve Doktor Adı Soyadı Bölümünü Boş Bırakmayınız !","Uyarı");
                textBox4.Clear();
                textBox5.Clear();
                textBox4.Focus();
            }
        }
    }
}
