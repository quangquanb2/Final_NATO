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
    public partial class SuaDanhMuc : Form
    {
        DanhMuc_DTO dm = new DanhMuc_DTO();
        public SuaDanhMuc(string madm)
        {
            InitializeComponent();
            load_inf(madm);
        }

        private void load_inf(string madm)
        {
            dm = DanhMuc_BUS.Instance.getDanhMuc(madm);
            txtMadm.Text = dm.MaDM;
            txtTendm.Text = dm.TenDM;
            txtMota.Text = dm.MoTa; 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dm.MaDM = txtMadm.Text.ToString();
            dm.TenDM = txtTendm.Text.ToString();
            dm.MoTa = txtMota.Text.ToString();
            bool kq = DanhMuc_BUS.Instance.updateDanhMuc(dm);
            string mss = kq == true ? "Update thành công" : "Lỗi xảy ra";
            Message.Instance.Show(mss, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtTendm.Text = dm.TenDM;
            txtMota.Text = dm.MoTa;
        }
    }
}
