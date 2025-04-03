using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAL
{    
   public class Kho_DAL
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";
        public List<Kho_DTO> GetAllNguyenLieu()
        {
            List<Kho_DTO> nguyenLieuList = new List<Kho_DTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    string procedure = "GetAllKho";
                    using (SqlCommand command = new SqlCommand(procedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Kho_DTO nguyenLieu = new Kho_DTO
                                {
                                    MaNL = reader["MaNL"].ToString(),
                                    TenNL = reader["TenNL"].ToString(),
                                    SoLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                                    DonViTinh = reader["DonViTinh"].ToString(),
                                    NgayNhap = Convert.ToDateTime(reader["NgayNhap"]),
                                    TenNCC = reader["TenNCC"].ToString(),
                                    SDT = reader["SDT"].ToString()
                                };
                                nguyenLieuList.Add(nguyenLieu);
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
            return nguyenLieuList;
        }
        public bool DeleteNguyenLieu(string maNL)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string procedure = "DeleteNguyenLieu";
                    SqlCommand command = new SqlCommand(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNL", maNL);
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
        public bool UpdateNguyenLieu(Kho_DTO nguyenLieu)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string procedure = "UpdateNguyenLieu";
                    SqlCommand command = new SqlCommand(procedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNL", nguyenLieu.MaNL);
                    command.Parameters.AddWithValue("@TenNL", nguyenLieu.TenNL);
                    command.Parameters.AddWithValue("@SoLuongTon", nguyenLieu.SoLuongTon);
                    command.Parameters.AddWithValue("@DonViTinh", nguyenLieu.DonViTinh);
                    command.Parameters.AddWithValue("@NgayNhap", nguyenLieu.NgayNhap);
                    command.Parameters.AddWithValue("@TenNCC", nguyenLieu.TenNCC);
                    command.Parameters.AddWithValue("@SDT", nguyenLieu.SDT);
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
        public bool InsertNguyenLieu(Kho_DTO nguyenLieu)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "ThemNguyenLieu"; 
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số cho Stored Procedure
                    command.Parameters.AddWithValue("@TenNL", nguyenLieu.TenNL);
                    command.Parameters.AddWithValue("@SoLuongTon", nguyenLieu.SoLuongTon);
                    command.Parameters.AddWithValue("@DonViTinh", nguyenLieu.DonViTinh);
                    command.Parameters.AddWithValue("@NgayNhap", nguyenLieu.NgayNhap);
                    command.Parameters.AddWithValue("@TenNCC", nguyenLieu.TenNCC);
                    command.Parameters.AddWithValue("@SDT", nguyenLieu.SDT);

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
        public string GetNextMaNL()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetNextMaNL", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                return command.ExecuteScalar()?.ToString() ?? "NL01";
            }
        }
    }
}
