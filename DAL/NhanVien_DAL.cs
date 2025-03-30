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
                string query = "SELECT MAX(MaND) FROM NguoiDung";
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

                    string query = "SELECT MaND, HoVaTen, GioiTinh, email, SDT, NgayDiLam FROM NguoiDung WHERE MaQL IS NOT NULL";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                    string query = "DELETE FROM NguoiDung WHERE MaND = @MaND";
                    SqlCommand command = new SqlCommand(query, connection);
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
                    string query = "UPDATE NguoiDung SET HoVaTen = @HoVaTen, GioiTinh = @GioiTinh, email = @Email, SDT = @SDT, NgayDiLam = @NgayDiLam WHERE MaND = @MaND";
                    SqlCommand command = new SqlCommand(query, connection);
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
                    string defaultPassword = "CafeShop" + employee.MaND;
                    string query = "INSERT INTO NguoiDung (MaND, HoVaTen, email, SDT, GioiTinh, password, NgayDiLam) VALUES (@MaND, @HoVaTen, @Email, @SDT, @GioiTinh, @Password, @NgayDiLam)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaND", employee.MaND);
                    command.Parameters.AddWithValue("@HoVaTen", employee.HoVaTen);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@SDT", employee.SDT);
                    command.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh);
                    command.Parameters.AddWithValue("@Password", defaultPassword);
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
        private string GenerateMaLLV()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ISNULL(MAX(CAST(SUBSTRING(MaLLV, 4, LEN(MaLLV) - 3) AS INT)), 0) + 1 FROM LichLamViec";
                SqlCommand command = new SqlCommand(query, connection);
                int maxNumber = (int)command.ExecuteScalar();
                return "LLV" + maxNumber.ToString("D3"); 
            }
        }

        public bool InsertWorkSchedule(CaLam_DTO workSchedule)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string maLLV = GenerateMaLLV();

                string query = "INSERT INTO LichLamViec (MaLLV, MaND, Ngay, CaLam) VALUES (@MaLLV, @MaND, @Ngay, @CaLam)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLLV", maLLV);
                command.Parameters.AddWithValue("@MaND", workSchedule.MaND);
                command.Parameters.AddWithValue("@Ngay", workSchedule.Ngay);
                command.Parameters.AddWithValue("@CaLam", workSchedule.CaLam);
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteWorkSchedule(string maLLV)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM LichLamViec WHERE MaLLV = @MaLLV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLLV", maLLV);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
        public bool UpdateWorkSchedule(CaLam_DTO workSchedule)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE LichLamViec SET MaND = @MaND, Ngay = @Ngay, CaLam = @CaLam WHERE MaLLV = @MaLLV";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaLLV", workSchedule.MaLLV);
                command.Parameters.AddWithValue("@MaND", workSchedule.MaND);
                command.Parameters.AddWithValue("@Ngay", workSchedule.Ngay);
                command.Parameters.AddWithValue("@CaLam", workSchedule.CaLam);
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }
        public int GetEmployeeCount()
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM NguoiDung WHERE MaQL IS NOT NULL";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                count = (int)command.ExecuteScalar();
            }
            return count;
        }
    }
}
