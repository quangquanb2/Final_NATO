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
    public class TaiKhoan_DAO
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["NATODB"].ConnectionString;

        public bool doiMatKhau(string username, string mkm)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "UPDATE TAIKHOAN SET MatKhau=@mk WHERE Username=@u";
                    cmd.Parameters.Add("@u", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@mk", SqlDbType.NVarChar).Value = mkm;

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

        public TaiKhoan_DTO getTaiKhoan(string username)
        {
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM TAIKHOAN WHERE Username = @U";
                    cmd.Parameters.Add("@U", SqlDbType.NVarChar).Value = username;

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        tk.Username = username;
                        tk.HoTen = rdr["HoTen"].ToString();
                        tk.Email = rdr["Email"].ToString();
                        tk.SDT = rdr["SDT"].ToString();
                        tk.DiaChi = rdr["DiaChi"].ToString();

                        tk.GT = rdr.GetBoolean(rdr.GetOrdinal("GioiTinh"));

                        tk.QuocTich = rdr["QuocTich"].ToString();

                        tk.IsAdmin = rdr.GetBoolean(rdr.GetOrdinal("IsAdmin"));
                        tk.HinhAnh = rdr["AVATAR"].ToString();
                        tk.MatKhau = rdr["MatKhau"].ToString();

                        return tk;
                    }
                    else
                    {
                        return null;
                    }
                        
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return null;
            }
        }

        public bool updateTaiKhoan(TaiKhoan_DTO tk)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "UPDATE TAIKHOAN SET HoTen=@ht, Email=@e, SDT=@s, DiaChi=@dc, GioiTinh=@gt, QuocTich=@qt, AVATAR=@av WHERE Username=@u";
                    cmd.Parameters.Add("@u", SqlDbType.NVarChar).Value = tk.Username;
                    cmd.Parameters.Add("@ht", SqlDbType.NVarChar).Value = tk.HoTen;
                    cmd.Parameters.Add("@e", SqlDbType.NVarChar).Value = tk.Email;
                    cmd.Parameters.Add("@s", SqlDbType.NVarChar).Value = tk.SDT;
                    cmd.Parameters.Add("@dc", SqlDbType.NVarChar).Value = tk.DiaChi;
                    cmd.Parameters.Add("@gt", SqlDbType.Bit).Value = tk.GT;
                    cmd.Parameters.Add("@qt", SqlDbType.NVarChar).Value = tk.QuocTich;
                    cmd.Parameters.Add("@av", SqlDbType.NVarChar).Value = tk.HinhAnh;

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
        
        public bool isAdmin(string username)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT IsAdmin FROM TAIKHOAN WHERE Username = @U";
                    cmd.Parameters.Add("@U", SqlDbType.NVarChar).Value = username;

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        bool isAdmin = rdr.GetBoolean(rdr.GetOrdinal("IsAdmin"));
                        return isAdmin;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return false;
            }
        }

        public List<TaiKhoan_DTO> getAllTaiKhoan(string s)
        {
            List<TaiKhoan_DTO> tks = new List<TaiKhoan_DTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    if (s.Equals("ALL"))
                    {
                        cmd.CommandText = "SELECT * FROM TAIKHOAN";
                    }
                    else
                    {
                        string tr1 = "%" + s + "%";
                        string tr2 = "%" + s;
                        string tr3 = s + "%";
                        cmd.CommandText = "SELECT * FROM TAIKHOAN WHERE Username LIKE @tr1 OR Username LIKE @tr2 OR Username LIKE @tr3 OR HoTen LIKE @tr1 OR HoTen LIKE @tr2 OR HoTen LIKE @tr3";
                        cmd.Parameters.Add("@tr1", SqlDbType.NVarChar).Value = tr1;
                        cmd.Parameters.Add("@tr2", SqlDbType.NVarChar).Value = tr2;
                        cmd.Parameters.Add("@tr3", SqlDbType.NVarChar).Value = tr3;
                    }
                        
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TaiKhoan_DTO tk = new TaiKhoan_DTO();
                        tk.Username = rdr["Username"].ToString();
                        tk.HoTen = rdr["HoTen"].ToString();
                        tk.Email = rdr["Email"].ToString();
                        tk.SDT = rdr["SDT"].ToString();
                        tk.DiaChi = rdr["DiaChi"].ToString();
                        tk.GT = rdr.GetBoolean(rdr.GetOrdinal("GioiTinh"));
                        tk.QuocTich = rdr["QuocTich"].ToString();
                        tk.IsAdmin = rdr.GetBoolean(rdr.GetOrdinal("IsAdmin"));
                        tk.HinhAnh = rdr["AVATAR"].ToString();

                        tks.Add(tk);
                    }
                    return tks;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return null;
            }
        }
    }
}
