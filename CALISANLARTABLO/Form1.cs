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

namespace SORU7Ö
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=bilgiler1.mdb");
        string sql = "select * from tablo1";

        void göster()

        {
            DataTable tablo = new DataTable();
        OleDbDataAdapter adaptor = new OleDbDataAdapter(sql,baglan);
            adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
        
        
        
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            göster();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {

                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;

                }
                else
                {

                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCyan;
                
                }
            
            }




        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            string ad = dataGridView1.CurrentRow.Cells["ADI"].Value.ToString();
            string soyad = dataGridView1.CurrentRow.Cells["SOYADI"].Value.ToString();
            if (e.RowIndex>=0  && e.ColumnIndex==1)
            {
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = ad + " " + soyad;
            }
            }

        public static string ad, soyad, memleket;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ad = dataGridView1.CurrentRow.Cells["ADI"].Value.ToString();
            soyad = dataGridView1.CurrentRow.Cells["SOYADI"].Value.ToString();
            memleket = dataGridView1.CurrentRow.Cells["MEMLEKET"].Value.ToString();

            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        
        }
    }
}
