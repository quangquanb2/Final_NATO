using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DAO;
using NATO.DTO;

namespace NATO.BUS
{
    public class Register_BUS
    {
        public static Register_BUS instance;
        public static Register_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new Register_BUS();
                return instance;
            }
        }

        Register_DAO rgdao = new Register_DAO();
        
        public bool register(TaiKhoan_DTO tk)
        {
            return rgdao.register(tk);
        }
    }
}
