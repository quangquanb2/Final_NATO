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
    public class HoaDon_DAO
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["NATODB"].ConnectionString;

        public int themHoaDon(string username, float tongtien, DateTime ngayxuat)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "INSERT INTO HOADON(Username, TongTien, NgayXuat) VALUES(@u, @t, @d)";
                    cmd.Parameters.Add("@u", SqlDbType.NVarChar).Value = username;
                    cmd.Parameters.Add("@t", SqlDbType.Float).Value = tongtien;
                    cmd.Parameters.Add("@d", SqlDbType.Date).Value = ngayxuat;
                     
                    int eff = cmd.ExecuteNonQuery();

                    if (eff != 1)
                    {
                        return -1;
                    } else
                    {
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = con;

                        cmd2.CommandText = "SELECT TOP 1 MaHoaDon FROM HOADON ORDER BY MaHoaDon DESC";
                        int getid = Int16.Parse(cmd2.ExecuteScalar().ToString());
                        return getid;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return -1;
            }
        }
        

        public bool themChiTietHoaDon(List<ChiTietGioHang_DTO> cthd, int mhd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    foreach (ChiTietGioHang_DTO ct in cthd)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "INSERT INTO CHITIETHOADON VALUES(@mhd, @mh, @sl, @g, @t)";
                        cmd.Parameters.Add("@mhd", SqlDbType.Int).Value = mhd;
                        cmd.Parameters.Add("@mh", SqlDbType.NVarChar).Value = ct.MaHang;
                        cmd.Parameters.Add("@sl", SqlDbType.Int).Value = ct.SoLuong;
                        cmd.Parameters.Add("@g", SqlDbType.Float).Value = ct.Gia;
                        cmd.Parameters.Add("@t", SqlDbType.Float).Value = ct.SoLuong * ct.Gia;
                        
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connect failed");
                return false;
            }
        }

        public List<HoaDon_DTO> getHoaDonFromUsername(string username)
        {
            List<HoaDon_DTO> ctgh = new List<HoaDon_DTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT * FROM HOADON WHERE Username=@u";
                    cmd.Parameters.Add("@u", SqlDbType.NVarChar).Value = username;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        HoaDon_DTO ct = new HoaDon_DTO();
                        ct.MaHD = Int16.Parse(dr["MaHoaDon"].ToString());
                        ct.TongTien = float.Parse(dr["TongTien"].ToString());
                        ct.Date = Convert.ToDateTime(dr["NgayXuat"].ToString());

                        ctgh.Add(ct);
                    }
                    return ctgh;
                }
            } catch (Exception ex)
            {
                return null;
            }
        }

        public List<ChiTietGioHang_DTO> getChiTietHoaDon(int mhd)
        {
            List<ChiTietGioHang_DTO> ctghs = new List<ChiTietGioHang_DTO>();
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT MATHANG.MaHang, TenHang, MATHANG.MoTa, MATHANG.HinhAnh, CHITIETHOADON.SoLuong, CHITIETHOADON.Gia, CHITIETHOADON.TongTien" +
                                        " FROM CHITIETHOADON, MATHANG" +
                                        " WHERE CHITIETHOADON.MaHoaDon = @mh AND CHITIETHOADON.MaHang = MATHANG.MaHang";
                    cmd.Parameters.Add("@mh", SqlDbType.Int).Value = mhd;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ChiTietGioHang_DTO ct = new ChiTietGioHang_DTO();
                        ct.TenHang = dr["TenHang"].ToString();
                        ct.MoTa = dr["MoTa"].ToString();
                        ct.SoLuong = Int16.Parse(dr["SoLuong"].ToString());
                        ct.Gia = float.Parse(dr["Gia"].ToString());
                        ct.ThanhTien = float.Parse(dr["TongTien"].ToString());

                        ctghs.Add(ct);
                    }
                    return ctghs;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
