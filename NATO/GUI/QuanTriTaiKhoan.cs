using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NATO.DTO;
using NATO.BUS;

namespace NATO.GUI
{
    public partial class QuanTriTaiKhoan : Form
    {
        public QuanTriTaiKhoan()
        {
            InitializeComponent();
        }

        private void QuanTriTaiKhoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kLMQSDataSet1.TAIKHOAN' table. You can move, or remove it, as needed.
            //this.tAIKHOANTableAdapter.Fill(this.kLMQSDataSet1.TAIKHOAN);
            load_TaiKhoan("ALL");
        }

        private void load_TaiKhoan(string s)
        {
            dataGridView1.Rows.Clear();
            List<TaiKhoan_DTO> tks = TaiKhoan_BUS.Instance.getAllTaiKhoan(s);
            foreach (TaiKhoan_DTO tk in tks)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = tk.Username;
                newRow.Cells[1].Value = tk.HoTen;
                newRow.Cells[2].Value = tk.Email;

                newRow.Cells[3].Value = tk.SDT;
                newRow.Cells[4].Value = tk.DiaChi;
                newRow.Cells[5].Value = tk.GT.ToString();

                newRow.Cells[6].Value = tk.QuocTich;
                newRow.Cells[7].Value = tk.IsAdmin.ToString();

                dataGridView1.Rows.Add(newRow);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = txtSearch.Text.ToString();
            load_TaiKhoan(s);
        }
    }
}
