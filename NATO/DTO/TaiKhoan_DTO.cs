using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NATO.DTO
{
    public class TaiKhoan_DTO
    {
        private string username;
        private string hoten;
        private string email;
        private string sdt;
        private string diachi;
        private bool gt;
        private string quoctich;
        private string matkhau;
        private bool isadmin;
        private string hinhanh;

        public TaiKhoan_DTO()
        {
            username = "";
            hoten = "";
            email = "";
            sdt = "";
            diachi = "";
            gt = false;
            quoctich = "";
            matkhau = "";
            isadmin = false;
        }

        public TaiKhoan_DTO(string username, string hoten, string email, string sdt, string diachi, bool gt, string quoctich, string matkhau, bool isadmin, string hinhanh)
        {
            this.Username = username;
            this.HoTen = hoten;
            this.Email = email;
            this.SDT = sdt;
            this.DiaChi = diachi;
            this.GT = gt;
            this.QuocTich = quoctich;
            this.MatKhau = matkhau;
            this.IsAdmin = isadmin;
            this.HinhAnh = hinhanh;
        }

        public string Username { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public bool GT { get; set; }
        public string QuocTich { get; set; }
        public string MatKhau { get; set; }
        public bool IsAdmin { get; set; }
        public string HinhAnh { get; set; }
    }
}
