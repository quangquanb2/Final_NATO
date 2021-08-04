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
    public partial class DoiMatKhau : Form
    {
        TaiKhoan_DTO t_tk = new TaiKhoan_DTO();
        public DoiMatKhau(TaiKhoan_DTO tk)
        {
            InitializeComponent();
            t_tk = tk;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (t_tk.MatKhau != txtmkc.Text.ToString())
                Message.Instance.Show("Nhập sai mật khẩu", 0);
            else
            {
                if (txtmkm1.Text.ToString() != txtmkm2.Text.ToString())
                {
                    Message.Instance.Show("Xác nhận mật khẩu không trùng nhau", 0);
                }
                else
                {
                    bool kq = TaiKhoan_BUS.Instance.doiMatKhau(t_tk.Username, txtmkm1.Text.ToString());
                    string ms = kq == true ? "Đổi mật khẩu thành công" : "Lỗi xảy ra";
                    Message.Instance.Show(ms, 1);
                }
            }
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
