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
    public partial class HomePage : Form
    {
        TaiKhoan_DTO tk;
        string t_username;
        public HomePage(string username)
        {
            InitializeComponent();
            lbUsername.Text = username;
            t_username = username;
            tk = TaiKhoan_BUS.Instance.getTaiKhoan(username);
            pictureBox1.ImageLocation = tk.HinhAnh;
            loadDanhMuc();
            popularItems("ALL");
            someSetUp(username);
        }

        public void someSetUp(string username)
        {
            if (tk.IsAdmin == false)
            {
                button2.Hide();
                button3.Hide();
                button7.Hide();
                button10.Hide();
            }
        }

        private void loadDanhMuc()
        {
            List<DanhMuc_DTO> li = DanhMuc_BUS.Instance.getAllDanhMuc();
            Dictionary<string, string> dms = new Dictionary<string, string>();
            dms["ALL"] = "Tất cả";
            foreach (DanhMuc_DTO dm in li)
            {
                dms[dm.MaDM] = dm.TenDM;
            }

            cbDanhMuc.DataSource = new BindingSource(dms, null);
            cbDanhMuc.DisplayMember = "Value";
            cbDanhMuc.ValueMember = "Key";
        }

        private void HienThi(List<MatHang_DTO> li)
        {
            int count = li.Count;
            
            ListItem[] listItems = new ListItem[count];

            for (int j = 0; j < count; j++)
            {
                listItems[j] = new ListItem();
                listItems[j].TenSP = li[j].TenHang;
                listItems[j].TenDM = li[j].MaDM;
                listItems[j].ChiTiet = li[j].MoTa;
                listItems[j].Gia = String.Format("{0:C}",li[j].Gia);
                listItems[j].MaSP = li[j].MaHang;
                listItems[j].Username = t_username;
                listItems[j].IM = li[j].HinhAnh;

                flowLayoutPanel1.Controls.Add(listItems[j]);
            }
        }

        private void popularItems(string mdm)
        {
            flowLayoutPanel1.Controls.Clear();
            List<MatHang_DTO> li = new List<MatHang_DTO>();
            if (mdm.Equals("ALL"))
            {
                li = MatHang_BUS.Instance.getAllMatHang();
            }
            else
            {
                li = MatHang_BUS.Instance.getMHbyDM(mdm);
            }
            HienThi(li);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonalInformation pi = new PersonalInformation(tk);
            pi.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThemDanhMuc tmd = new ThemDanhMuc();
            tmd.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThemMatHang tmh = new ThemMatHang();
            tmh.ShowDialog();
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dm = cbDanhMuc.SelectedValue.ToString();
            flowLayoutPanel1.Controls.Clear();
            popularItems(dm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool kq = Message.Instance.Show("Bạn có muốn thoát ứng dụng?", "question");
            if (kq == true)
            {
                System.Environment.Exit(0);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            QuanTriTaiKhoan qttk = new QuanTriTaiKhoan();
            qttk.ShowDialog();
        }

        private void searchMatHang(string txt)
        {
            List<MatHang_DTO> li = new List<MatHang_DTO>();
            li = MatHang_BUS.Instance.searchMatHang(txt);
            // Message.Instance.Show("Completed", 1);
            flowLayoutPanel1.Controls.Clear();
            HienThi(li);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string txt = txtSearch.Text.ToString();
            searchMatHang(txt);
            txtSearch.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GioHang gh = new GioHang(lbUsername.Text.ToString());
            gh.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DonHang dh = new DonHang(t_username);
            dh.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            BaoCao bc = new BaoCao();
            bc.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.ShowDialog();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Message.Instance.Show(txtSearch.Text.ToString() + " " + txtSearch.Text.ToString().Length, 1);
                string txt = txtSearch.Text.ToString();
                searchMatHang(txt);
                txtSearch.Text = "";
            }
        }
    }
}
