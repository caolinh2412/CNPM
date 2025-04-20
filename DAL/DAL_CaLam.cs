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

        public List<DTO_CaLam> GetCaLamTheoNgayVaMaNV(DateTime ngay, string maNV)
        {
            List<DTO_CaLam> list = new List<DTO_CaLam>();
            string query = "SELECT * FROM LichLamViec WHERE Ngay = @ngay AND MaNV = @maNV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
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
                    list.Add(caLam);
                }
            }

            return list;
        }
        public List<DTO_CaLam> GetWorkScheduleByEmployeeId(string maNV)
        {
            List<DTO_CaLam> workSchedule = new List<DTO_CaLam>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaLLV, MaNV, Ngay, CaLam, TrangThai FROM LichLamViec WHERE MaNV = @MaNV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaNV", maNV);
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
        public bool InsertWorkSchedule(DTO_CaLam workSchedule)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "InsertWorkSchedule";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;

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
        public bool DeleteWorkSchedule(string maLLV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DeleteWorkSchedule"; // Tên stored procedure
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure; // Chỉ định đây là stored procedure
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
        public bool UpdateWorkSchedule(DTO_CaLam workSchedule)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "CapNhatLichLamViec";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;

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

