using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CaLam
    {
        private static string connectionString = DBConnection.GetConnectionString();
        // Lay danh sách ca làm việc theo ngày
        public List<DTO_CaLam> GetCaLamTheoNgayVaMaNV(DateTime ngay, string maNV)
        {
            List<DTO_CaLam> list = new List<DTO_CaLam>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Gọi stored procedure sp_GetCaLamTheoNgayVaMaNV
                SqlCommand cmd = new SqlCommand("sp_GetCaLamTheoNgayVaMaNV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ngay", ngay);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Gán dữ liệu đọc được vào đối tượng DTO_CaLam
                    DTO_CaLam caLam = new DTO_CaLam
                    {                    
                        MaLLV = reader["MaLLV"].ToString(),
                        MaNV = reader["MaNV"].ToString(),
                        Ngay = Convert.ToDateTime(reader["Ngay"]),
                        CaLam = reader["CaLam"].ToString(),
                        TrangThai = reader["TrangThai"].ToString()
                    };
                    list.Add(caLam);
                }
            }

            return list;
        }
        // Lay danh sách ca làm việc theo mã nhân viên
        public List<DTO_CaLam> GetWorkScheduleByEmployeeId(string maNV)
        {
            List<DTO_CaLam> workSchedule = new List<DTO_CaLam>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Gọi stored procedure
                SqlCommand command = new SqlCommand("sp_GetWorkScheduleByEmployeeId", connection); 
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@maNV", maNV);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_CaLam caLam = new DTO_CaLam
                        {
                            MaLLV = reader["MaLLV"].ToString(),
                            MaNV = reader["MaNV"].ToString(),
                            Ngay = Convert.ToDateTime(reader["Ngay"]),
                            CaLam = reader["CaLam"].ToString(),
                            TrangThai = reader["TrangThai"].ToString()
                        };
                        workSchedule.Add(caLam);
                    }
                }
            }
            return workSchedule;
        }
        // Insert ca làm việc
        public bool InsertWorkSchedule(DTO_CaLam workSchedule)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "InsertWorkSchedule"; // Tên stored procedure
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Truyền các tham số cho stored procedure
                    command.Parameters.AddWithValue("@MaNV", workSchedule.MaNV);
                    command.Parameters.AddWithValue("@Ngay", workSchedule.Ngay);
                    command.Parameters.AddWithValue("@CaLam", workSchedule.CaLam);

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
        // Xóa ca làm việc
        public bool DeleteWorkSchedule(string maLLV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DeleteWorkSchedule"; // Tên stored procedure
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@MaLLV", maLLV);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
        // Cập nhật ca làm việc
        public bool UpdateWorkSchedule(DTO_CaLam workSchedule)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "CapNhatLichLamViec";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Truyền dữ liệu cần cập nhật
                    command.Parameters.AddWithValue("@MaLLV", workSchedule.MaLLV);
                    command.Parameters.AddWithValue("@MaNV", workSchedule.MaNV);
                    command.Parameters.AddWithValue("@Ngay", workSchedule.Ngay);
                    command.Parameters.AddWithValue("@CaLam", workSchedule.CaLam);
                    command.Parameters.AddWithValue("@TrangThai", workSchedule.TrangThai);

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
    }
}

