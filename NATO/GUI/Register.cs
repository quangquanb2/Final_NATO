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
    public partial class Register : Form
    {
        public List<string> QT = new List<string>() {
            "Việt Nam",
            "Hàn Quốc",
            "Mỹ",
            "Trung Quốc",
            "Nga",
            "Triều Tiên",
            "Đức",
            "Nhật"
        };

        public Register()
        {
            InitializeComponent();
            cbQT.DataSource = new BindingSource(QT, null);
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoan_DTO tk = new TaiKhoan_DTO();
                tk.Username = txtUsername.Text.ToString();
                tk.HoTen = txtHoten.Text.ToString();
                tk.MatKhau = txtPassword.Text.ToString();
                string rmk = txtRepassword.Text.ToString();
                tk.Email = txtEmail.Text.ToString();
                tk.SDT = txtSDT.Text.ToString();
                tk.DiaChi = txtDC.Text.ToString();
                tk.QuocTich = cbQT.SelectedItem.ToString();
                tk.GT = cbGT.SelectedItem.ToString() == "Nữ";

                if (tk.MatKhau != rmk)
                {
                    Message.Instance.Show("Xác nhận mật khẩu không trùng nhau", 1);
                } else
                {
                    bool kq = Register_BUS.Instance.register(tk);
                    string mss = kq == true ? "Đăng ký Thành Công" : "Đăng ký thất bại";
                    Message.Instance.Show(mss, 1);
                }
            } catch (Exception ex)
            {
                Message.Instance.Show("Lỗi xảy ra. Hãy thử lại.", 0);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login li = new Login();
            li.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool kq = Message.Instance.Show("Bạn có muốn thoát ứng dụng?", "question");
            if (kq == true)
            {
                System.Environment.Exit(0);
            }
        }
    }
}
