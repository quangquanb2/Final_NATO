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
    public partial class ThemMatHang : Form
    {
        Dictionary<string, string> choices;
        public ThemMatHang()
        {
            InitializeComponent();
            GetDM();
        }

        public void GetDM()
        {
            List<DanhMuc_DTO> dms = DanhMuc_BUS.Instance.getAllDanhMuc();

            choices = new Dictionary<string, string>();

            foreach (DanhMuc_DTO dm in dms) {
                choices[dm.MaDM] =  dm.TenDM;
            }

            cbDM.DataSource = new BindingSource(choices, null);
            cbDM.DisplayMember = "Value";
            cbDM.ValueMember = "Key";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MatHang_DTO mh = new MatHang_DTO();
            try
            {
                mh.MaHang = txtMahang.Text.ToString();
                mh.TenHang = txtTenhang.Text.ToString();
                mh.SoLuong = Convert.ToInt16(txtSL.Text.ToString());
                mh.HinhAnh = pictureBox1.ImageLocation.ToString();
                mh.Gia = float.Parse(txtGia.Text.ToString());
                mh.MoTa = txtMota.Text.ToString();
                mh.MaDM = cbDM.SelectedValue.ToString();

                bool kq = MatHang_BUS.Instance.themMatHang(mh);
                string mss = kq == true ? "Thêm thành công" : "Thêm thất bại";
                Message.Instance.Show(mss, 1);
            }
            catch (Exception ex)
            {
                Message.Instance.Show("Nhập đủ và đúng định dạng cho dữ liệu", 0);
            }
        }

        private void ThemMatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kLMQSDataSet.MATHANG' table. You can move, or remove it, as needed.
            //this.mATHANGTableAdapter.Fill(this.kLMQSDataSet.MATHANG);

            List<MatHang_DTO> mhs = MatHang_BUS.Instance.getAllMatHang();
            dataGridView1.Rows.Clear();

            foreach (MatHang_DTO mh in mhs)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = mh.MaHang;
                newRow.Cells[1].Value = mh.TenHang;
                newRow.Cells[2].Value = mh.SoLuong;

                newRow.Cells[3].Value = mh.Gia;
                newRow.Cells[4].Value = mh.MoTa;
                newRow.Cells[5].Value = mh.MaDM;

                dataGridView1.Rows.Add(newRow);
            }
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string mmh = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                ChiTietMatHang ctmh = new ChiTietMatHang(mmh,choices);
                ctmh.ShowDialog();
            } catch (Exception ex)
            {
                Message.Instance.Show("Bấm vô hàng sản phẩm cần sửa.", 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string mmh = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                bool kq = Message.Instance.Show("Bạn có muốn xóa mặt hàng này?", "question");
                if (kq == true)
                {
                    bool eff = MatHang_BUS.Instance.xoaMH(mmh);
                    string mss = eff == true ? "Xóa mặt hàng " + mmh + " thành công" : "Xóa thất bại";
                    Message.Instance.Show(mss, 1);
                }
            }
            catch (Exception ex)
            {
                Message.Instance.Show("Bấm vô mặt hàng cần xóa", 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtGia.Text = "";
            txtSL.Text = "";
            txtTenhang.Text = "";
            txtMota.Text = "";
            txtMahang.Text = "";
            pictureBox1.ImageLocation = "";
        }
    }
}
