using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_NhanVien
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";

        public string MaNvLonNhat()
        {
            string maxCode = "NV000";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(MaND) FROM NguoiDung WHERE MaND LIKE 'NV%'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                var result = command.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    maxCode = result.ToString();
                }
            }
            return maxCode;
        }

        public List<DTO_DangNhap> GetAllEmployees()
        {
            List<DTO_DangNhap> employees = new List<DTO_DangNhap>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string procedure = "GetAllEmployees";
                    using (SqlCommand command = new SqlCommand(procedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DTO_DangNhap employee = new DTO_DangNhap
                                {
                                    MaND = reader["MaND"].ToString(),
                                    HoVaTen = reader["HoVaTen"].ToString(),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Email = reader["email"].ToString(),
                                    SDT = reader["SDT"].ToString(),
                                    NgayDiLam = Convert.ToDateTime(reader["NgayDiLam"]),
                                    TrangThai = reader["TrangThai"].ToString()
                                };
                                employees.Add(employee);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
            return employees;
        }
        public bool TatHD(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string procedure = "TatHD";
                    SqlCommand command = new SqlCommand(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaND", maNV);
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
        public bool UpdateEmployee(DTO_DangNhap employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string procedure = "UpdateEmployee";
                    SqlCommand command = new SqlCommand(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaND", employee.MaND);
                    command.Parameters.AddWithValue("@HoVaTen", employee.HoVaTen);
                    command.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@SDT", employee.SDT);
                    command.Parameters.AddWithValue("@NgayDiLam", employee.NgayDiLam);
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
        public bool InsertEmployee(DTO_DangNhap employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "InsertEmployee";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure; 

                  
                    command.Parameters.AddWithValue("@HoVaTen", employee.HoVaTen);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@SDT", employee.SDT);
                    command.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh);
                    command.Parameters.AddWithValue("@NgayDiLam", employee.NgayDiLam);

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
        public List<DTO_CaLam> GetWorkScheduleByEmployeeId(string maNV)
        {
            List<DTO_CaLam> workSchedule = new List<DTO_CaLam>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaLLV, MaND, Ngay, CaLam FROM LichLamViec WHERE MaND = @MaND";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaND", maNV);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_CaLam caLam = new DTO_CaLam
                        {
                            MaLLV = reader["MaLLV"].ToString(),
                            MaND = reader["MaND"].ToString(),
                            Ngay = Convert.ToDateTime(reader["Ngay"]),
                            CaLam = reader["CaLam"].ToString()
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

                    command.Parameters.AddWithValue("@MaND", workSchedule.MaND);
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
                    command.Parameters.AddWithValue("@MaND", workSchedule.MaND);
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
        public int GetEmployeeCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DemNv"; 
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure; 

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
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
