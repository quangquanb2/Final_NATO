using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NATO.DTO;

namespace NATO.DAO
{
    public class ThongKe_DAO
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["NATODB"].ConnectionString;

        public Dictionary<string, float> getTTBanChay()
        {
            Dictionary<string, float> sl = new Dictionary<string, float>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT MATHANG.TenHang, SUM(CHITIETHOADON.TongTien) as TongTien" +
                                        " FROM MATHANG, CHITIETHOADON" +
                                        " WHERE MATHANG.MaHang = CHITIETHOADON.MaHang" +
                                        " GROUP BY CHITIETHOADON.MaHang, MATHANG.TenHang, MATHANG.MaDanhMuc" +
                                        " ORDER BY TongTien DESC";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        sl[dr["TenHang"].ToString()] = float.Parse(dr["TongTien"].ToString()); 
                    }
                    return sl;
                }
            } catch (Exception ex)
            {
                return null;
            }
        }

        public Dictionary<string, float> getSLBanChay()
        {
            Dictionary<string, float> sl = new Dictionary<string, float>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT MATHANG.TenHang, SUM(CHITIETHOADON.SoLuong) as SoLuong" +
                                        " FROM MATHANG, CHITIETHOADON" +
                                        " WHERE MATHANG.MaHang = CHITIETHOADON.MaHang" +
                                        " GROUP BY CHITIETHOADON.MaHang, MATHANG.TenHang, MATHANG.MaDanhMuc" +
                                        " ORDER BY SoLuong DESC";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        sl[dr["TenHang"].ToString()] = float.Parse(dr["SoLuong"].ToString());
                    }
                    return sl;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Dictionary<string, int> getDMBanChay()
        {
            Dictionary<string, int> sl = new Dictionary<string, int>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT D.TenDanhMuc, Sum(D.TongSoLuong) as TongSoLuong" +
                                       " FROM (" +
                                       " SELECT DANHMUC.TenDanhMuc, SUM(CHITIETHOADON.SoLuong) as TongSoLuong" +
                                       " FROM MATHANG, CHITIETHOADON, DANHMUC" +
                                       " WHERE MATHANG.MaHang = CHITIETHOADON.MaHang AND DANHMUC.MaDanhMuc = MATHANG.MaDanhMuc" +
                                       " GROUP BY CHITIETHOADON.MaHang, MATHANG.TenHang, MATHANG.MaDanhMuc, DANHMUC.TenDanhMuc" +
                                       " ) as D" +
                                       " GROUP BY D.TenDanhMuc" +
                                       " ORDER BY TongSoLuong DESC";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        sl[dr["TenDanhMuc"].ToString()] = Int16.Parse(dr["TongSoLuong"].ToString());
                    }
                    return sl;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Dictionary<string, int> getMHBanChayT(string ngay)
        {
            Dictionary<string, int> sl = new Dictionary<string, int>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT D.TenHang, SUM(D.SoLuong) as SoLuong" +
                                        " FROM (" +
                                        " SELECT HOADON.MaHoaDon, CHITIETHOADON.MaHang, CHITIETHOADON.SoLuong, MATHANG.TenHang" +
                                        " FROM HOADON, CHITIETHOADON, MATHANG" +
                                        " WHERE HOADON.MaHoaDon = CHITIETHOADON.MaHoaDon" +
                                        " AND CHITIETHOADON.MaHang = MATHANG.MaHang" +
                                        " AND HOADON.NgayXuat >= '" + ngay +
                                        "') AS D" +
                                        " GROUP BY D.TenHang" +
                                        " ORDER BY SoLuong DESC";
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        sl[dr["TenHang"].ToString()] = Int16.Parse(dr["SoLuong"].ToString());
                    }
                    return sl;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
