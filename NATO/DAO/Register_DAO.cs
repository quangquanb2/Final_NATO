using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DTO;

namespace NATO.DAO
{
    public class Register_DAO
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["NATODB"].ConnectionString;

        public bool register(TaiKhoan_DTO tk)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "INSERT INTO TAIKHOAN VALUES(@u,@h,@e,@sdt,@dc,@gt,@qt,@mk,@ia,@hinh)";
                    cmd.Parameters.Add("@u", SqlDbType.NVarChar).Value = tk.Username;
                    cmd.Parameters.Add("@h", SqlDbType.NVarChar).Value = tk.HoTen;
                    cmd.Parameters.Add("@e", SqlDbType.NVarChar).Value = tk.Email;
                    cmd.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = tk.SDT;
                    cmd.Parameters.Add("@dc", SqlDbType.NVarChar).Value = tk.DiaChi;
                    cmd.Parameters.Add("@gt", SqlDbType.NVarChar).Value = tk.GT;
                    cmd.Parameters.Add("@qt", SqlDbType.NVarChar).Value = tk.QuocTich;
                    cmd.Parameters.Add("@mk", SqlDbType.NVarChar).Value = tk.MatKhau;
                    cmd.Parameters.Add("@ia", SqlDbType.NVarChar).Value = tk.IsAdmin;
                    cmd.Parameters.Add("@hinh", SqlDbType.NVarChar).Value = tk.HinhAnh;

                    int eff = cmd.ExecuteNonQuery();
                    return eff == 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return false;
            }
        }
    }
}
