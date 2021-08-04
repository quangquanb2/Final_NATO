using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NATO.BUS;

namespace NATO.GUI
{
    public partial class ListItemGioHang : UserControl
    {
        
        public ListItemGioHang()
        {
            InitializeComponent();
        }

        private string im;
        private string maSP;
        private string tenSP;
        private int soLuong;
        private string mota;
        private float gia;
        private string username;
        private float thanhtien;

        public string IM
        {
            get { return im; }
            set { im = value; pictureBox1.ImageLocation = value; }
        }

        public string MoTa
        {
            get { return mota; }
            set { mota = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string MaSP
        {
            get { return maSP; }
            set { maSP = value; }
        }

        public string TenSP
        {
            get { return tenSP; }
            set { tenSP = value; lbTen.Text = value; }
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; lbSoluong.Text = value.ToString(); }
        }

        public float Gia
        {
            get { return gia; }
            set { gia = value; lbGia.Text = String.Format("{0:C}", value); }
        }

        public float ThanhTien
        {
            get { return thanhtien; }
            set { thanhtien = this.Gia * this.SoLuong; lbThanhtien.Text = String.Format("{0:C}", this.Gia * this.SoLuong); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kq = GioHang_BUS.Instance.xoaChiTietGioHang(this.Username, this.MaSP);
            // MessageBox.Show(this.Username.ToString());
        }
    }
}
