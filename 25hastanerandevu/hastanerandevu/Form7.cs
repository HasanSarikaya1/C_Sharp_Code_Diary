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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataReader dr;
        OleDbCommand cmd;
        void randevugör()
        {
            listView1.Items.Clear();
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hastane.accdb");
            con.Open();
            cmd = new OleDbCommand("Select * From randevubilgi where Doktor_Adi='" + Form8.adsoyad + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Randevu_Id"].ToString());
                item.SubItems.Add(dr["Tc"].ToString());
                item.SubItems.Add(dr["Hasta_Adi"].ToString());
                item.SubItems.Add(dr["Klinik_Adi"].ToString());
                item.SubItems.Add(dr["Doktor_Adi"].ToString());
                item.SubItems.Add(dr["Tarih"].ToString());
                item.SubItems.Add(dr["Saat"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            randevugör();
        }
    }
}
