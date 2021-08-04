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
    public partial class ChiTietDonHang : Form
    {
        public struct MyGH
        {
            public MyGH(string tensp, string chitiet, float gia, int soluong, float thanhtien, string hinhanh)
            {
                this.TenSP = tensp;
                this.ChiTiet = chitiet;
                this.Gia = gia;
                this.SoLuong = soluong;
                this.ThanhTien = thanhtien;
                this.HinhAnh = hinhanh;
            }

            public string TenSP { get; set; }
            public string ChiTiet { get; set; }
            public float Gia { get; set; }
            public int SoLuong { get; set; }
            public float ThanhTien { get; set; }
            public string HinhAnh { get; set; }
        }

        public ChiTietDonHang(int mhd)
        {
            InitializeComponent();
            load_chitiethoadon(mhd);
        }

        public void load_chitiethoadon(int mhd)
        {
            List<ChiTietGioHang_DTO> ctghs = HoaDon_BUS.Instance.getChiTietHoaDon(mhd);
            int count = ctghs.Count;

            dataGridView1.Rows.Clear();
            foreach (ChiTietGioHang_DTO hd in ctghs)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = hd.TenHang.ToString();
                newRow.Cells[1].Value = hd.MoTa.ToString();
                newRow.Cells[2].Value = hd.SoLuong.ToString();
                newRow.Cells[3].Value = String.Format("{0:C}", hd.Gia);
                newRow.Cells[4].Value = String.Format("{0:C}", hd.ThanhTien);

                dataGridView1.Rows.Add(newRow);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
