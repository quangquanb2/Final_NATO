using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DTO;
using NATO.DAO;

namespace NATO.BUS
{
    public class TaiKhoan_BUS
    {
        public static TaiKhoan_BUS instance;
        public static TaiKhoan_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaiKhoan_BUS();
                return instance;
            }
        }

        TaiKhoan_DAO tkdao = new TaiKhoan_DAO();

        public TaiKhoan_DTO getTaiKhoan(string username)
        {
            return tkdao.getTaiKhoan(username);
        }

        public bool updateTaiKhoan(TaiKhoan_DTO tk)
        {
            return tkdao.updateTaiKhoan(tk);
        }

        public bool isAdmin(string username)
        {
            return tkdao.isAdmin(username);
        }

        public bool doiMatKhau(string username, string mk)
        {
            return tkdao.doiMatKhau(username, mk);
        }

        public List<TaiKhoan_DTO> getAllTaiKhoan(string s)
        {
            return tkdao.getAllTaiKhoan(s);
        }
    }
}
