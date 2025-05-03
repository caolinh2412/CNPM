using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    public class DAL_CongThuc
    {
        private static string connectionString = DBConnection.GetConnectionString();

        public DataTable GetCongThucByMaMon(string maMon)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_LayCongThuc", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaMon", maMon);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy công thức món: " + ex.Message);
            }
            return dt;
        }
        public bool InsertCongThuc(DTO_CongThuc congThuc)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ThemCongThuc", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaMon", congThuc.MaMon);
                        cmd.Parameters.AddWithValue("@MaNL", congThuc.MaNL);
                        cmd.Parameters.AddWithValue("@SoLuong", congThuc.SoLuong);
                        cmd.Parameters.AddWithValue("@DonViTinh", congThuc.DonViTinh);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm công thức: " + ex.Message);
            }
        }
        public bool DeleteCongThuc(string maCT)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string procedure = "sp_DeleteCongThuc";
                    SqlCommand command = new SqlCommand(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaCT", maCT);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        public bool KiemTraTonKho(DTO_ThucDon mon, int soLuong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_KiemTraTonKho", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm tham số đầu vào
                    cmd.Parameters.AddWithValue("@MaMon", mon.MaMon);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);

                    // Thêm tham số đầu ra
                    SqlParameter ketQuaParam = new SqlParameter("@KetQua", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(ketQuaParam);
                  
                    cmd.ExecuteNonQuery();

                    // Lấy kết quả
                    return (bool)ketQuaParam.Value;
                }
            }
        }
        public void CapNhatKhoKhiXoaMon(string maMon, int soLuong)
        {
            // Gọi thủ tục sp_CapNhatKhoKhiXoaMon
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CapNhatKhoKhiXoaMon", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaMon", maMon);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}