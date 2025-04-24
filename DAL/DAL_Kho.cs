using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using System.Configuration;

namespace DAL
{
    public class DAL_Kho
    {
        private static string connectionString = DBConnection.GetConnectionString();
        public List<DTO_Kho> GetAllNguyenLieu()
        {
            List<DTO_Kho> nguyenLieuList = new List<DTO_Kho>();
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
                                DTO_Kho nguyenLieu = new DTO_Kho
                                {
                                    MaNL = reader["MaNL"].ToString(),
                                    TenNL = reader["TenNL"].ToString(),
                                    SoLuongTon = reader.GetDecimal(reader.GetOrdinal("SoLuongTon")),
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
        public bool UpdateNguyenLieu(DTO_Kho nguyenLieu)
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
        public bool InsertNguyenLieu(DTO_Kho nguyenLieu)
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