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
    public partial class ThemDanhMuc : Form
    {
        public ThemDanhMuc()
        {
            InitializeComponent();
            load_DanhMuc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DanhMuc_DTO dm = new DanhMuc_DTO();
            dm.MaDM = txtMDM.Text.ToString();
            dm.TenDM = txtTDM.Text.ToString();
            dm.MoTa = txtMT.Text.ToString();

            bool kq = DanhMuc_BUS.Instance.themDanhMuc(dm);
            string mss = kq == true ? "Thêm danh mục thành công" : "Thêm không thành công";
            Message.Instance.Show(mss, 1);
        }

        private void load_DanhMuc()
        {
            List<DanhMuc_DTO> dms = DanhMuc_BUS.Instance.getAllDanhMuc();
            dataGridView1.Rows.Clear();

            foreach (DanhMuc_DTO dm in dms)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = dm.MaDM;
                newRow.Cells[1].Value = dm.TenDM;
                newRow.Cells[2].Value = dm.MoTa;
                dataGridView1.Rows.Add(newRow);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMDM.Text = "";
            txtMT.Text = "";
            txtTDM.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string mdm = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SuaDanhMuc smd = new SuaDanhMuc(mdm);
                smd.ShowDialog();
            }
            catch (Exception ex)
            {
                Message.Instance.Show("Bấm vô hàng sản phẩm cần sửa.", 0);
            }
        }
    }
}
