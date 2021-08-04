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
    public partial class PersonalInformation : Form
    {
        TaiKhoan_DTO t_tk;
        public static List<string> QT = new List<string>() {
            "Việt Nam",
            "Hàn Quốc",
            "Mỹ",
            "Trung Quốc",
            "Nga",
            "Triều Tiên",
            "Đức",
            "Nhật"
        };

        public PersonalInformation(TaiKhoan_DTO tk)
        {
            InitializeComponent();
            t_tk = tk;
            Load_Information(t_tk);
        }

        private void Load_Information(TaiKhoan_DTO tk)
        {
            lblUsername.Text = tk.MatKhau;
            txtHoten.Text = tk.HoTen;
            txtEmail.Text = tk.Email;
            txtDiachi.Text = tk.DiaChi;
            txtSDT.Text = tk.SDT;
            cbGT.SelectedItem = tk.GT == false ? "Nam" : "Nữ";
            cbQT.DataSource = new BindingSource(QT, null);
            cbQT.SelectedItem = tk.QuocTich;
            pictureBox1.ImageLocation = tk.HinhAnh;
        }

        private void PersonalInformation_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Load_Information(t_tk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.Username = lblUsername.Text.ToString();
            tk.HoTen = txtHoten.Text.ToString();
            tk.Email = txtEmail.Text.ToString();
            tk.DiaChi = txtDiachi.Text.ToString();
            tk.SDT = txtSDT.Text.ToString();
            tk.GT = cbGT.SelectedItem.ToString() == "Nam" ? false : true;
            tk.QuocTich = cbQT.SelectedItem.ToString();
            tk.HinhAnh = pictureBox1.ImageLocation;

            bool kq = TaiKhoan_BUS.Instance.updateTaiKhoan(tk);
            string mss = kq == true ? "Update tài khoản thành công" : "Lỗi xảy ra";
            Message.Instance.Show(mss, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string imageLocation;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = ofd.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau(t_tk);
            dmk.ShowDialog();
        }
    }
}
