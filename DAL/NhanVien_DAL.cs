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
    public class NhanVien_DAL
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

        public List<DangNhap_DTO> GetAllEmployees()
        {
            List<DangNhap_DTO> employees = new List<DangNhap_DTO>();
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
                                DangNhap_DTO employee = new DangNhap_DTO
                                {
                                    MaND = reader["MaND"].ToString(),
                                    HoVaTen = reader["HoVaTen"].ToString(),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Email = reader["email"].ToString(),
                                    SDT = reader["SDT"].ToString(),
                                    NgayDiLam = Convert.ToDateTime(reader["NgayDiLam"])
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
        public bool DeleteEmployee(string maNV)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string procedure = "DeleteEmployee";
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
        public bool UpdateEmployee(DangNhap_DTO employee)
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
        public bool InsertEmployee(DangNhap_DTO employee)
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
        public List<CaLam_DTO> GetWorkScheduleByEmployeeId(string maNV)
        {
            List<CaLam_DTO> workSchedule = new List<CaLam_DTO>();
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
                        CaLam_DTO caLam = new CaLam_DTO
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
        public bool InsertWorkSchedule(CaLam_DTO workSchedule)
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
        public bool UpdateWorkSchedule(CaLam_DTO workSchedule)
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
