using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_ChiTietDonHang
    {
        private static string connectionString = DBConnection.GetConnectionString();

        public bool ThemChiTietDonHang(DTO_ChiTietDonHang chiTietDH)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ThemChiTietDonHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaDH", chiTietDH.MaDH);
                        cmd.Parameters.AddWithValue("@TenMon", chiTietDH.TenMon);
                        cmd.Parameters.AddWithValue("@SoLuong", chiTietDH.SoLuong);
                        cmd.Parameters.AddWithValue("@Gia", chiTietDH.Gia);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DTO_ChiTietDonHang> LayChiTietDonHangTheoMaDH(string maDH)
        {
            List<DTO_ChiTietDonHang> danhSachChiTiet = new List<DTO_ChiTietDonHang>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LayCTHDTheoMaDH", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaDH", maDH);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_ChiTietDonHang chiTiet = new DTO_ChiTietDonHang
                                {
                                    MaCTDH = reader.GetString(reader.GetOrdinal("MaCTDH")),
                                    MaDH = reader.GetString(reader.GetOrdinal("MaDH")),                                  
                                    SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                    Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                    ThanhTien = reader.GetDecimal(reader.GetOrdinal("ThanhTien")),
                                    TenMon = reader.GetString(reader.GetOrdinal("TenMon"))
                                };
                                danhSachChiTiet.Add(chiTiet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết đơn hàng theo mã đơn hàng: " + ex.Message);
            }

            return danhSachChiTiet;
        }


        public bool XoaChiTietDonHang(int maCTDH)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM ChiTietDonHang WHERE MaCTDH = @MaCTDH";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaCTDH", maCTDH);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<DTO_ChiTietDonHang> GetTop3MonBanChay()
        {
            List<DTO_ChiTietDonHang> result = new List<DTO_ChiTietDonHang>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetTop3MonBanChay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new DTO_ChiTietDonHang
                                {
                                    TenMon = reader.GetString(0), 
                                    SoLuong = reader.GetInt32(1) 
                                });
                            }
                        }
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy top 3 món bán chạy: " + ex.Message);
            }
        }
    }
}