using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DAO;

namespace NATO.BUS
{
    public class Login_BUS
    {
        public static Login_BUS instance;
        public static Login_BUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new Login_BUS();
                return instance;
            }
        }

        Login_DAO lgdao = new Login_DAO();

        public bool login(string username, string password)
        {
            return lgdao.login(username, password);
        }
    }
}
