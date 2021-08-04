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
    public partial class GioHang : Form
    {
        string t_username;
        float t_tongtien;
        List<ChiTietGioHang_DTO> ctghs;

        public GioHang(string username)
        {
            InitializeComponent();
            t_username = username;
            loadGio(username);
        }

        public void loadGio(string username)
        {
            ctghs = GioHang_BUS.Instance.getChiTietGioHang(username);
            int count = ctghs.Count;
            int slTong = ctghs.Sum(item => item.SoLuong);

            
            lbSLTong.Text = slTong.ToString();
            ListItemGioHang[] listItems = new ListItemGioHang[count];
            flowLayoutPanel1.Controls.Clear();
            
            float total = 0;
            for (int j = 0; j < count; j++)
            {
                listItems[j] = new ListItemGioHang();
                listItems[j].Username = t_username;
                listItems[j].MaSP = ctghs[j].MaHang;
                listItems[j].TenSP = ctghs[j].TenHang;
                listItems[j].MoTa = ctghs[j].MoTa;
                listItems[j].Gia = ctghs[j].Gia;
                listItems[j].SoLuong = ctghs[j].SoLuong;
                listItems[j].IM = ctghs[j].HinhAnh;
                listItems[j].ThanhTien = ctghs[j].ThanhTien;
                total += listItems[j].ThanhTien;

                flowLayoutPanel1.Controls.Add(listItems[j]);
            }

            t_tongtien = total;
            lbTotal.Text = String.Format("{0:C}", total);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool isValid()
        {
            if (txtName.Text.ToString().Equals("") || txtCardnumber.Text.ToString().Equals(""))
                return false;
            if (txtExdate.Text.ToString().Equals(""))
                return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                bool kq = HoaDon_BUS.Instance.themHoaDon(t_username, t_tongtien, ctghs);
                string mss = kq == true ? "Đặt hàng thành công" : "Lỗi xảy ra";
                Message.Instance.Show(mss, 1);
                bool xgh = GioHang_BUS.Instance.xoaGioHang(t_username);
                this.Close();
                GioHang gh = new GioHang(t_username);
                gh.ShowDialog();
            } else
            {
                Message.Instance.Show("Hãy điền chính xác thông tin thanh toán", 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadGio(t_username);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
