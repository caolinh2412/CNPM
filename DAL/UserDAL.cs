using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CoffeeShopManagementSystem.DTO;

namespace CoffeeShopManagementSystem.DAL
{
    public class UserDAL
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\THUY_LINH\Documents\cafeShop.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public UserDAL() { }

        public object GetUser(string username, string password, string role)
        {
            string query = role == "Nhân viên" ?
                "SELECT * FROM NhanVien WHERE username = @usern AND password = @pass" :
                "SELECT * FROM QuanLy WHERE username = @usern AND password = @pass";

            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connect))
                    {
                        sqlCommand.Parameters.AddWithValue("@usern", username);
                        sqlCommand.Parameters.AddWithValue("@pass", password);

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (role == "Nhân viên")
                                {
                                    return new NhanVienDTO
                                    {
                                        Id = reader["id"].ToString(),
                                        Username = reader["username"].ToString(),
                                        Email = reader["email"].ToString(),
                                        GioiTinh = reader["gioiTinh"].ToString(),
                                        Password = reader["password"].ToString(),
                                        DateSignup = Convert.ToDateTime(reader["date_signup"])
                                    };
                                }
                                else
                                {
                                    return new QuanLyDTO
                                    {
                                        Id = reader["id"].ToString(),
                                        Username = reader["username"].ToString(),
                                        Email = reader["email"].ToString(),
                                        Password = reader["password"].ToString()
                                    };
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Không kết nối được." + ex.Message);
                }
            }
            return null;
        }
        public bool CheckRole(string username, string role)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = role == "Nhân viên" ?
                   "SELECT COUNT(*) FROM NhanVien WHERE Username = @Username" :
                   "SELECT COUNT(*) FROM QuanLy WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Role", role);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        public bool RegisterUser(NhanVienDTO nhanVien)
        {
            string insertData = "INSERT INTO NhanVien (id, username, email, gioiTinh, password, date_signup) VALUES(@id, @usern, @email, @sex, @pass, @date)";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(insertData, connect))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", nhanVien.Id);
                        sqlCommand.Parameters.AddWithValue("@usern", nhanVien.Username);
                        sqlCommand.Parameters.AddWithValue("@email", nhanVien.Email);
                        sqlCommand.Parameters.AddWithValue("@sex", nhanVien.GioiTinh);
                        sqlCommand.Parameters.AddWithValue("@pass", nhanVien.Password);
                        sqlCommand.Parameters.AddWithValue("@date", nhanVien.DateSignup);

                        sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Không kết nối được." + ex.Message);
                }
            }
        }

        public bool CheckUsername(string username)
        {
            string query = "SELECT COUNT(*) FROM NhanVien WHERE username = @usern";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connect))
                    {
                        sqlCommand.Parameters.AddWithValue("@usern", username);
                        int count = (int)sqlCommand.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Không kết nối được." + ex.Message);
                }
            }
        }

        public string GenerateNewUserId()
        {
            string newId = "NV001";
            string countQuery = "SELECT TOP 1 id FROM NhanVien WHERE id LIKE 'NV%' ORDER BY id DESC";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(countQuery, connect))
                    {
                        object result = sqlCommand.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string lastId = result.ToString();
                            int number = int.Parse(lastId.Substring(2)) + 1;
                            newId = "NV" + number.ToString("D3");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Không kết nối được." + ex.Message);
                }
            }
            return newId;
        }

        public bool IsEmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM NhanVien WHERE Email = @Email";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connect))
                    {
                        sqlCommand.Parameters.AddWithValue("@Email", email);
                        int count = (int)sqlCommand.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Không kết nối được." + ex.Message);
                }
            }
        }

        public void UpdatePassword(string email, string newPassword)
        {
            string query = "UPDATE NhanVien SET Password = @Password WHERE Email = @Email";
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                try
                {
                    connect.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, connect))
                    {
                        sqlCommand.Parameters.AddWithValue("@Password", newPassword);
                        sqlCommand.Parameters.AddWithValue("@Email", email);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Không kết nối được." + ex.Message);
                }
            }
        }
    }
}
