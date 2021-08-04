using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NATO.DTO
{
    public class MatHang_DTO
    {
        private string maHang;
        private string tenHang;
        private int soLuong;
        private string hinhAnh;
        private float gia;
        private string moTa;
        private string maDM;

        public MatHang_DTO()
        {
            maHang = "";
            tenHang = "";
            soLuong = 0;
            hinhAnh = "";
            gia = 0;
            moTa = "";
            maDM = "";
        }

        public MatHang_DTO(string maHang, string tenHang, int soLuong, string hinhAnh, float gia, string moTa, string maDM)
        {
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.soLuong = soLuong;
            this.hinhAnh = hinhAnh;
            this.gia = gia;
            this.moTa = moTa;
            this.maDM = maDM;
        }

        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }
        public float Gia { get; set; }
        public string MoTa { get; set; }
        public string MaDM { get; set; }
    }
}
