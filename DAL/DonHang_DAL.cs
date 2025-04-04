using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DTO;
using System.ComponentModel;

namespace DAL
{
    public class DonHang_DAL
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";
      
        public DataTable GetAllDonHangWithTenNV()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllDonHang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách đơn hàng với tên người dùng: " + ex.Message);
            }
            return dt;
        }


        public DonHangDTO GetDonHangById(string maDH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM DonHang WHERE MaDH = @MaDH";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDH", maDH);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DonHangDTO
                            {
                                MaDH = reader.GetString(reader.GetOrdinal("MaDH")),
                                NgayDat = reader.GetDateTime(reader.GetOrdinal("NgayDat")),
                                MaND = reader.GetString(reader.GetOrdinal("MaND")),
                                TongTien = reader.GetDecimal(reader.GetOrdinal("TongTien")),
                            };
                        }
                    }
                }
            }
            return null;
        }

 

        public bool ThemDonHangVaChiTiet(DonHangDTO donHang, BindingList<ChiTietDonHang_DTO> chiTietDonHangs, out string maDH)
        {
            maDH = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ThemDonHangVaChiTiet", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số đầu vào
                        cmd.Parameters.AddWithValue("@NgayDat", donHang.NgayDat);
                        cmd.Parameters.AddWithValue("@MaND", donHang.MaND);

                        // Tạo DataTable cho chi tiết đơn hàng
                        DataTable chiTietTable = new DataTable();
                        chiTietTable.Columns.Add("MaMon", typeof(string));
                        chiTietTable.Columns.Add("TenMon", typeof(string));
                        chiTietTable.Columns.Add("SoLuong", typeof(int));
                        chiTietTable.Columns.Add("Gia", typeof(decimal));

                        foreach (var chiTiet in chiTietDonHangs)
                        {
                            chiTietTable.Rows.Add(chiTiet.MaMon, chiTiet.TenMon, chiTiet.SoLuong, chiTiet.Gia);
                        }

                        // Thêm tham số ChiTietDonHang
                        SqlParameter chiTietParam = cmd.Parameters.AddWithValue("@ChiTietDonHang", chiTietTable);
                        chiTietParam.SqlDbType = SqlDbType.Structured;

                        // Thêm tham số đầu ra MaDH
                        SqlParameter maDHParam = new SqlParameter("@MaDH", SqlDbType.NVarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(maDHParam);

                        // Thực thi stored procedure
                        cmd.ExecuteNonQuery();

                        // Lấy giá trị MaDH từ tham số đầu ra
                        maDH = maDHParam.Value.ToString();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm đơn hàng và chi tiết: " + ex.Message);
            }
        }
        public string GetNextMaDH()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LayMaDonHangTiepTheo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số đầu ra
                        SqlParameter maDHParam = new SqlParameter("@MaDH", SqlDbType.NVarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(maDHParam);

                        // Thực thi stored procedure
                        cmd.ExecuteNonQuery();

                        // Lấy giá trị MaDH từ tham số đầu ra
                        string nextMaDH = maDHParam.Value.ToString();
                        return nextMaDH;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã đơn hàng tiếp theo: " + ex.Message);
            }
        }
        public void CapNhatSoLuongTonKho(string maDH)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_CapNhatSoLuongTonKho", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaDH", maDH);

                        cmd.ExecuteNonQuery(); 
                    }
                }
            }
            catch (SqlException ex)
            {        
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi cập nhật tồn kho: " + ex.Message);
            }
        }
        public int GetTongDH()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_TongSoKhach", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi lấy tổng số hóa đơn: " + ex.Message);
            }
        }
        public decimal GetTongDoanhThu(DateTime ngay)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_TinhDoanhThuTrongNgay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ngay", ngay);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi lấy doanh thu trong ngày: " + ex.Message);
            }
        }
        public Dictionary<int, decimal> GetDoanhThuTheoThang(int nam)
        {
            Dictionary<int, decimal> doanhThuTheoThang = new Dictionary<int, decimal>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetDoanhThuTheoThang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nam", nam);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int thang = reader.GetInt32(0); 
                                decimal doanhThu = reader.GetDecimal(1); 
                                doanhThuTheoThang[thang] = doanhThu;
                            }
                        }
                    }
                }
                return doanhThuTheoThang;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy doanh thu theo tháng: " + ex.Message);
            }
        }
    }
}
