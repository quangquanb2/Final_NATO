using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NATO.BUS;
using NATO.DTO;

namespace NATO.GUI
{
    public partial class DonHang : Form
    {
        string t_username;

        public struct MyStruct
        {
            public MyStruct(int mahd, float tongtien, DateTime ngay)
            {
                this.MaHD = mahd;
                this.TongTien = tongtien;
                this.Ngay = ngay;
            }

            public int MaHD { get; set; }
            public float TongTien { get; set; }
            public DateTime Ngay { get; set; }
        }

        public DonHang(string username)
        {
            InitializeComponent();
            t_username = username;
            load_donHang(t_username);
        }
        
        private void load_donHang(string username)
        {
            List<HoaDon_DTO> hds = HoaDon_BUS.Instance.getHoaDonFromUsername(username);
            int count = hds.Count;
            /*
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = hds;*/

            dataGridView1.Rows.Clear();
            foreach (HoaDon_DTO hd in hds)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = hd.MaHD;
                newRow.Cells[1].Value = String.Format("{0:C}", hd.TongTien);
                newRow.Cells[2].Value = hd.Date.ToString("dd-MM-yyyy");

                dataGridView1.Rows.Add(newRow);
            }
            dataGridView1.Visible = true;
        }

        private void DonHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kLMQSDataSet1.TAIKHOAN' table. You can move, or remove it, as needed.
            //this.tAIKHOANTableAdapter.Fill(this.kLMQSDataSet1.TAIKHOAN);
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            load_chitiet(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                load_chitiet(id);
            } catch (Exception ex)
            {

            }
        }

        private void load_chitiet(string id)
        {
            ChiTietDonHang ct = new ChiTietDonHang(Int16.Parse(id));
            ct.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
