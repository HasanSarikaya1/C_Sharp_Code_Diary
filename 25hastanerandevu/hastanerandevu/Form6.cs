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
    public partial class Form6 : Form
    {
        public Form6()
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
            cmd = new OleDbCommand("Select * From randevubilgi where Tc='"+Form1.tc+"'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Randevu_Id"].ToString());
                item.SubItems.Add(dr["Tc"].ToString());
                item.SubItems.Add(dr["Klinik_Adi"].ToString());
                item.SubItems.Add(dr["Doktor_Adi"].ToString());
                item.SubItems.Add(dr["Tarih"].ToString());
                item.SubItems.Add(dr["Saat"].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            randevugör();
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
                OleDbCommand cmd = new OleDbCommand("Delete * From randevubilgi where Randevu_Id=" + TC + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Randevu Silme Başarılı", "Bilgilendirme");
                randevugör();
            }
            catch (Exception hata)
            {
                con.Close();
                MessageBox.Show(hata.Message);
            }
        }
    }
}
