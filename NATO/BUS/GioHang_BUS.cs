using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DAO;
using NATO.DTO;

namespace NATO.BUS
{
    public class GioHang_BUS
    {
        public static GioHang_BUS instance;
        public static GioHang_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GioHang_BUS();
                return instance;
            }
        }
        private GioHang_DAO gioHangDAO = new GioHang_DAO(); 

        public bool themGioHang(string username, string mahang, int soluong)
        {
            ChiTietGioHang_DTO ctgh = new ChiTietGioHang_DTO();
            ctgh.Username = username;
            ctgh.MaHang = mahang;
            ctgh.SoLuong = soluong;
            return gioHangDAO.themGioHang(ctgh);
        }

        public List<ChiTietGioHang_DTO> getChiTietGioHang(string username)
        {
            return gioHangDAO.getChiTietGioHang(username);
        }

        public bool xoaChiTietGioHang(string username, string mamh)
        {
            return gioHangDAO.xoaChiTietGioHang(username, mamh);
        }

        public bool xoaGioHang(string username)
        {
            return gioHangDAO.xoaGioHang(username);
        }
    }
}
