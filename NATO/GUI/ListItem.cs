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
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        private string im;
        private string maSP;
        private string tenSP;
        private string tenDM;
        private string chiTiet;
        private string gia;
        private string username;

        public string IM
        {
            get { return im; }
            set { im = value; pictureBox1.ImageLocation = im; }
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

        public string TenSP {
            get { return tenSP; }
            set { tenSP = value; lbTen.Text = value; }
        }

        public string TenDM {
            get { return tenDM; }
            set { tenDM = value; lbDM.Text = value; }
        }

        public string ChiTiet {
            get { return chiTiet; }
            set { chiTiet = value; lbChitiet.Text = value; }
        }

        public string Gia {
            get { return gia; }
            set { gia = value; lbGia.Text = value; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int sl = Int16.Parse(txtSL.Text.ToString());
                string mss = this.MaSP;
                bool kq = GioHang_BUS.Instance.themGioHang(this.Username, mss, sl);
                string message = kq == true ? "Thêm giỏ hành thành công" : "Thất bại";
                Message.Instance.Show(message, 1);
                txtSL.Text = "";
            } catch (Exception ex)
            {
                Message.Instance.Show("Nhập vào số", 0);
            }
            
        }

        private void lbGia_Click(object sender, EventArgs e)
        {

        }
    }
}
