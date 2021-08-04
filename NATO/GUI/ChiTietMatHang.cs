using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NATO.BUS;
using NATO.DTO;

namespace NATO.GUI
{
    public partial class ChiTietMatHang : Form
    {
        public ChiTietMatHang(string mmh, Dictionary<string,string> dms)
        {
            InitializeComponent();
            load_MatHang(mmh,dms);
        }

        private void load_MatHang(string mmh, Dictionary<string, string> dms)
        {
            MatHang_DTO mh = MatHang_BUS.Instance.getMHbyMaMH(mmh);
            if (mh != null)
            {
                txtMamh.Text = mh.MaHang;
                txtTenhang.Text = mh.TenHang;
                txtMota.Text = mh.MoTa;
                txtSL.Text = Int16.Parse(mh.SoLuong.ToString()).ToString();
                txtGia.Text = float.Parse(mh.Gia.ToString()).ToString();
                cbDM.DataSource = new BindingSource(dms, null);
                cbDM.DisplayMember = "Value";
                cbDM.ValueMember = "Key";
                cbDM.SelectedValue = mh.MaDM;
                pictureBox1.ImageLocation = mh.HinhAnh;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MatHang_DTO mh = new MatHang_DTO();
            try
            {
                mh.MaHang = txtMamh.Text.ToString();
                mh.TenHang = txtTenhang.Text.ToString();
                mh.MoTa = txtMota.Text.ToString();
                mh.SoLuong = Int16.Parse(txtSL.Text.ToString());
                mh.Gia = float.Parse(txtGia.Text.ToString());
                mh.HinhAnh = pictureBox1.ImageLocation.ToString();
                mh.MaDM = cbDM.SelectedValue.ToString();
                bool kq = MatHang_BUS.Instance.capNhatMH(mh, mh.MaHang);
                string mss = kq == true ? "Cập nhật thành công" : "Cập nhật thất bại";
                Message.Instance.Show(mss, 1);
            } catch (Exception ex)
            {
                Message.Instance.Show("Nhập đúng và đầy đủ dữ liệu", 0);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
