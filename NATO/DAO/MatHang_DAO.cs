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
    public class MatHang_DAO
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["NATODB"].ConnectionString;

        public List<MatHang_DTO> searchMatHang(string str)
        {
            List<MatHang_DTO> mhs = new List<MatHang_DTO>();

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    string tr = "%" + str + "%";
                    string tr1 = "%" + str;
                    string tr2 = str + "%";

                    cmd.CommandText = "SELECT * FROM MATHANG WHERE MoTa LIKE @t OR MoTa LIKE @tt OR MoTa LIKE @ttt";
                    cmd.Parameters.Add("@t", SqlDbType.NVarChar).Value = tr;
                    cmd.Parameters.Add("@tt", SqlDbType.NVarChar).Value = tr1;
                    cmd.Parameters.Add("@ttt", SqlDbType.NVarChar).Value = tr2;

                    mhs = runExecuteNonQuery(cmd);
                    return mhs;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return null;
            }
        }

        public List<MatHang_DTO> getAllMatHang()
        {
            List<MatHang_DTO> mhs = new List<MatHang_DTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM MATHANG";
                    mhs = runExecuteNonQuery(cmd);

                    return mhs;
                }
            }
            catch (Exception ex)
            {
                return mhs;
            }
        }

        public List<MatHang_DTO> getMHbyDM(string mdm)
        {
            List<MatHang_DTO> mhs = new List<MatHang_DTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM MATHANG WHERE MaDanhMuc=@m";
                    cmd.Parameters.Add("@m", SqlDbType.NVarChar).Value = mdm;
                    mhs = runExecuteNonQuery(cmd);

                    return mhs;
                }
            }
            catch (Exception ex)
            {
                return mhs;
            }
        }

        public bool themmatHang(MatHang_DTO mh)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    string mahang = mh.MaHang;
                    string tenhang = mh.TenHang;
                    int sl = mh.SoLuong;
                    string hinhanh = mh.HinhAnh;
                    float gia = mh.Gia;
                    string mota = mh.MoTa;
                    string madm = mh.MaDM;

                    cmd.CommandText = "INSERT INTO MATHANG VALUES(@mh,@th,@sl,@h,@g,@mt,@mdm)";
                    cmd.Parameters.Add("@mh", SqlDbType.NVarChar).Value = mahang;
                    cmd.Parameters.Add("@th", SqlDbType.NVarChar).Value = tenhang;
                    cmd.Parameters.Add("@sl", SqlDbType.Int).Value = sl;
                    cmd.Parameters.Add("@h", SqlDbType.NVarChar).Value = hinhanh;
                    cmd.Parameters.Add("@g", SqlDbType.Float).Value = gia;
                    cmd.Parameters.Add("@mt", SqlDbType.NVarChar).Value = mota;
                    cmd.Parameters.Add("@mdm", SqlDbType.NVarChar).Value = madm;

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

        public MatHang_DTO getMHbyMaMH(string maMH)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM MATHANG WHERE MaHang=@m";
                    cmd.Parameters.Add("@m", SqlDbType.NVarChar).Value = maMH;


                    SqlDataReader drd = cmd.ExecuteReader();
                    MatHang_DTO mh = new MatHang_DTO();
                    if (drd.Read())
                    {
                        mh.MaHang = drd["MaHang"].ToString();
                        mh.TenHang = drd["TenHang"].ToString();
                        mh.SoLuong = Convert.ToInt16(drd["SoLuong"].ToString());
                        mh.HinhAnh = drd["HinhAnh"].ToString();
                        mh.Gia = float.Parse(drd["Gia"].ToString());
                        mh.MoTa = drd["MoTa"].ToString();
                        mh.MaDM = drd["MaDanhMuc"].ToString();
                    }
                    return mh;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<MatHang_DTO> runExecuteNonQuery(SqlCommand cmd)
        {
            List<MatHang_DTO> mhs = new List<MatHang_DTO>();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                MatHang_DTO mh = new MatHang_DTO();
                mh.MaHang = rdr["MaHang"].ToString();
                mh.TenHang = rdr["TenHang"].ToString();
                mh.SoLuong = Convert.ToInt16(rdr["SoLuong"].ToString());
                mh.HinhAnh = rdr["HinhAnh"].ToString();
                mh.Gia = float.Parse(rdr["Gia"].ToString());
                mh.MoTa = rdr["MoTa"].ToString();
                mh.MaDM = rdr["MaDanhMuc"].ToString();

                mhs.Add(mh);
            }
            return mhs;
        }

        public bool capNhatMH(MatHang_DTO mh, string maMH)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    string tenhang = mh.TenHang;
                    int sl = mh.SoLuong;
                    string hinhanh = mh.HinhAnh;
                    float gia = mh.Gia;
                    string mota = mh.MoTa;
                    string madm = mh.MaDM;

                    cmd.CommandText = "UPDATE MATHANG SET TenHang=@th, SoLuong=@sl, HinhAnh=@h, Gia=@g, MoTa=@mt, MaDanhMuc=@mdm WHERE MaHang=@ma";
                    cmd.Parameters.Add("@th", SqlDbType.NVarChar).Value = tenhang;
                    cmd.Parameters.Add("@sl", SqlDbType.Int).Value = sl;
                    cmd.Parameters.Add("@h", SqlDbType.NVarChar).Value = hinhanh;
                    cmd.Parameters.Add("@g", SqlDbType.Float).Value = gia;
                    cmd.Parameters.Add("@mt", SqlDbType.NVarChar).Value = mota;
                    cmd.Parameters.Add("@mdm", SqlDbType.NVarChar).Value = madm;
                    cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = maMH;

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

        public bool xoaMatHang(string mamh)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "DELETE FROM MATHANG WHERE MaHang=@ma";
                    cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = mamh;

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
