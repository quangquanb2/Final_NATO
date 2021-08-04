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
    public class DanhMuc_DAO
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["NATODB"].ConnectionString;
        public List<DanhMuc_DTO> getAllDanhMuc()
        {
            List<DanhMuc_DTO> dms = new List<DanhMuc_DTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM DANHMUC";

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        DanhMuc_DTO dm = new DanhMuc_DTO();
                        dm.MaDM = rdr["MaDanhMuc"].ToString();
                        dm.TenDM = rdr["TenDanhMuc"].ToString();
                        dm.MoTa = rdr["MoTa"].ToString();

                        dms.Add(dm);
                    }
                    return dms;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return null;
            }
        }

        public DanhMuc_DTO getDanhMuc(string madm)
        {
            DanhMuc_DTO dm = new DanhMuc_DTO();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM DANHMUC WHERE MaDanhMuc=@m";
                    cmd.Parameters.Add("@m", SqlDbType.NVarChar).Value = madm;

                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        dm.MaDM = rdr["MaDanhMuc"].ToString();
                        dm.TenDM = rdr["TenDanhMuc"].ToString();
                        dm.MoTa = rdr["MoTa"].ToString();
                    }
                    return dm;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return null;
            }
        }
        
        public bool themDanhMuc(DanhMuc_DTO dm)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    string madm = dm.MaDM;
                    string tendm = dm.TenDM;
                    string mota = dm.MoTa;

                    cmd.CommandText = "INSERT INTO DANHMUC VALUES(@m,@t,@mt)";
                    cmd.Parameters.Add("@m", SqlDbType.NVarChar).Value = madm;
                    cmd.Parameters.Add("@t", SqlDbType.NVarChar).Value = tendm;
                    cmd.Parameters.Add("@mt", SqlDbType.NVarChar).Value = mota;

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

        public bool updateDanhMuc(DanhMuc_DTO dm)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "UPDATE DANHMUC SET TenDanhMuc=@tdm, MoTa=@mt WHERE MaDanhMuc=@mdm";
                    cmd.Parameters.Add("@tdm", SqlDbType.NVarChar).Value = dm.TenDM;
                    cmd.Parameters.Add("@mt", SqlDbType.NVarChar).Value = dm.MoTa;
                    cmd.Parameters.Add("@mdm", SqlDbType.NVarChar).Value = dm.MaDM;

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
