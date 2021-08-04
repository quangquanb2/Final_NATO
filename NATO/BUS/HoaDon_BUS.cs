using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DAO;
using NATO.DTO;

namespace NATO.BUS
{
    public class HoaDon_BUS
    {
        HoaDon_DAO hd = new HoaDon_DAO();

        public static HoaDon_BUS instance;
        public static HoaDon_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new HoaDon_BUS();
                return instance;
            }
        }

        public bool themHoaDon(string username, float tongtien, List<ChiTietGioHang_DTO> ctgh)
        {
            DateTime thisday = DateTime.Today;
            int mhd = hd.themHoaDon(username, tongtien, thisday);
            if (mhd == -1)
            {
                return false;
            } else
            {
                bool kq = hd.themChiTietHoaDon(ctgh, mhd);
                return kq;
            }
        }

        public List<HoaDon_DTO> getHoaDonFromUsername(string username)
        {
            List<HoaDon_DTO> dr = hd.getHoaDonFromUsername(username);
            return dr;
        }

        public List<ChiTietGioHang_DTO> getChiTietHoaDon(int mhd)
        {
            List<ChiTietGioHang_DTO> cthds = hd.getChiTietHoaDon(mhd);
            return cthds;
        }
    }
}
