using System;
using System.Collections.Generic;
using System.Configuration;
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
        private static string connectionString = DBConnection.GetConnectionString();

        public string MaNvLonNhat()
        {
            string maxCode = "NV000";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MAX(MaNV) FROM NguoiDung";
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
                                    MaNV = reader["MaNV"].ToString(),
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
                    command.Parameters.AddWithValue("@MaNV", maNV);
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
                    command.Parameters.AddWithValue("@MaNV", employee.MaNV);
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
                    command.Parameters.AddWithValue("@MaQL", employee.MaQL);

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
