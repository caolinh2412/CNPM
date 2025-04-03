using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ChiTietDonHang_DAL
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";

        public bool ThemChiTietDonHang(ChiTietDonHang_DTO chiTietDH)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO ChiTietDonHang (MaDH, MaMon, SoLuong, Gia) 
                                   VALUES (@MaDH, @MaMon, @SoLuong, @Gia)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDH", chiTietDH.MaDH);
                        cmd.Parameters.AddWithValue("@MaMon", chiTietDH.MaMon);
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

        public List<ChiTietDonHang_DTO> LayChiTietDonHangTheoMaDH(string maDH)
        {
            List<ChiTietDonHang_DTO> danhSachChiTiet = new List<ChiTietDonHang_DTO>();

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
                                ChiTietDonHang_DTO chiTiet = new ChiTietDonHang_DTO
                                {
                                    MaCTDH = reader.GetString(reader.GetOrdinal("MaCTDH")),
                                    MaDH = reader.GetString(reader.GetOrdinal("MaDH")),
                                    MaMon = reader.GetString(reader.GetOrdinal("MaMon")),
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
    }
}