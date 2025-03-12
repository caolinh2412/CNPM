using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.DAO
{
    public class UserDAL
    {
        private SqlConnection connect;

        public UserDAL()
        {
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\THUY_LINH\Documents\cafeShop.mdf;Integrated Security=True;Connect Timeout=30;Encrypt= False");
        }

        public DataTable GetUser(string username, string password, string role)
        {
            DataTable dataTable = new DataTable();
            try
            {
                connect.Open();
                string query = role == "Nhân viên" ?
                    "SELECT * FROM NhanVien WHERE username = @usern AND password = @pass" :
                    "SELECT * FROM QuanLy WHERE username = @usern AND password = @pass";

                using (SqlCommand sqlCommand = new SqlCommand(query, connect))
                {
                    sqlCommand.Parameters.AddWithValue("@usern", username);
                    sqlCommand.Parameters.AddWithValue("@pass", password);

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không kết nối được." + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return dataTable;
        }
        public bool RegisterUser(string id, string username, string email, string sex, string password, DateTime date)
        {
            try
            {
                connect.Open();
                string insertData = "INSERT INTO NhanVien (id, username, email, gioiTinh, password, profile_img, date_signup) VALUES(@id, @usern, @email, @sex, @pass, @img, @date)";
                using (SqlCommand sqlCommand = new SqlCommand(insertData, connect))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@usern", username);
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@sex", sex);
                    sqlCommand.Parameters.AddWithValue("@pass", password);
                    sqlCommand.Parameters.AddWithValue("@img", "");
                    sqlCommand.Parameters.AddWithValue("@date", date);

                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không kết nối được." + ex);
            }
            finally
            {
                connect.Close();
            }
        }
        public DataTable CheckUsername(string username)
        {
            DataTable dataTable = new DataTable();
            try
            {
                connect.Open();
                string query = "SELECT * FROM NhanVien WHERE username = @usern";
                using (SqlCommand sqlCommand = new SqlCommand(query, connect))
                {
                    sqlCommand.Parameters.AddWithValue("@usern", username);
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không kết nối được." + ex);
            }
            finally
            {
                connect.Close();
            }
            return dataTable;
        }

        public string GenerateNewUserId()
        {
            string newId = "NV001";
            try
            {
                connect.Open();
                string countQuery = "SELECT TOP 1 id FROM NhanVien WHERE id LIKE 'NV%' ORDER BY id DESC";
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
                throw new Exception("Không kết nối được." + ex);
            }
            finally
            {
                connect.Close();
            }
            return newId;
        }
        public bool IsEmailExists(string email)
        {
            try
            {
                connect.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE Email = @Email";
                using (SqlCommand sqlCommand = new SqlCommand(query, connect))
                {
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    int count = (int)sqlCommand.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không kết nối được." + ex);
            }
            finally
            {
                connect.Close();
            }
        }
        public void UpdatePassword(string email, string newPassword)
        {
            try
            {
                connect.Open();
                string query = "UPDATE NhanVien SET Password = @Password WHERE Email = @Email";
                using (SqlCommand sqlCommand = new SqlCommand(query, connect))
                {
                    sqlCommand.Parameters.AddWithValue("@Password", newPassword);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không kết nối được." + ex);
            }
            finally
            {
                connect.Close();
            }
        }
    }
}