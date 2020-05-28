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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string girisyapan;
        OleDbConnection con;
        DataSet ds;
        OleDbDataAdapter da;
        public static string satisyapan;
        public void girisyapankim()
        {
            girisyapan = Form1.girisyapan.ToString();
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select * From elemanbil where Eleman_TC='" + girisyapan + "' ", con);
            cmd.ExecuteNonQuery();
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                label1.Text =  "Hoşgeldiniz "+" "+rd["Eleman_Ad"].ToString() + "  " + rd["Eleman_Soyad"].ToString();
                satisyapan=rd["Eleman_Ad"].ToString()+"  "+rd["Eleman_Soyad"].ToString();
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.frm3.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.frm4.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.frm5.Show(); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=bilgisayarsatis.accdb");
            da = new OleDbDataAdapter("Select * from satisbil",con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "satisbil");
            dataGridView1.DataSource = ds.Tables["satisbil"];
            con.Close();

            if (Form1.elemangirdimi==false)
            {
                label1.Text = "Hoşgeldiniz" + " " + "Admin";
            }
            else
            {
                girisyapankim();
            }
            ToolTip açıklama = new ToolTip();
            açıklama.SetToolTip(button1, "Personel İşlemleri.");
            açıklama.SetToolTip(button2, "Ürün İşlemleri.");
            açıklama.SetToolTip(button3, "Müşteri İşlemleri");
            açıklama.SetToolTip(button4, "Satış İşlemler.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.frm6.Show(); 
        }
    }
}
