using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_ThucDon
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["CafeShopConnection"].ConnectionString;
        public string maMonMoi;


        public List<DTO_ThucDon> GetMenuItemsByCategory(string category)
        {
            List<DTO_ThucDon> menuItems = new List<DTO_ThucDon>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {                  
                    SqlCommand command = new SqlCommand("LayDanhSachMonTheoMaDanhMuc", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MaDanhMuc", category);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_ThucDon item = new DTO_ThucDon
                            {
                                MaMon = reader["MaMon"].ToString(),
                                TenMon = reader["TenMon"]?.ToString() ?? string.Empty,
                                Gia = Convert.ToDecimal(reader["Gia"]),
                                HinhAnh = reader["HinhAnh"]?.ToString() ?? string.Empty,
                                MaDM = reader["MaDM"]?.ToString() ?? string.Empty,

                            };
                            menuItems.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách món ăn: " + ex.Message);
            }

            return menuItems;
        }

        public List<DTO_ThucDon> GetAllMenuItems()
        {
            List<DTO_ThucDon> menuItems = new List<DTO_ThucDon>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "LayTatCaMonAn"; 
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure; 
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DTO_ThucDon item = new DTO_ThucDon
                        {
                            MaMon = reader["MaMon"].ToString(),
                            TenMon = reader["TenMon"]?.ToString() ?? string.Empty,
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            HinhAnh = reader["HinhAnh"]?.ToString() ?? string.Empty,
                            MaDM = reader["MaDM"]?.ToString() ?? string.Empty,
                        };
                        menuItems.Add(item);
                    }
                }
            }
            return menuItems;
        }

        public bool ThemMonMoi(DTO_ThucDon thucDon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("ThemMonMoi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaDM", thucDon.MaDM);
                        cmd.Parameters.AddWithValue("@TenMon", thucDon.TenMon);
                        cmd.Parameters.AddWithValue("@Gia", thucDon.Gia);
                        cmd.Parameters.AddWithValue("@HinhAnh", thucDon.HinhAnh);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm món: " + ex.Message);
            }
        }

        public bool XoaMon(string maMon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_XoaMon", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaMon", maMon);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public int GetTongSoMon()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_TinhTongSoMonTrongMenu", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi lấy tổng số món trong menu: " + ex.Message);
            }
        }
        public DTO_ThucDon GetMonById(string maMon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("getMonById", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DTO_ThucDon
                        {
                            MaMon = reader["MaMon"].ToString(),
                            TenMon = reader["TenMon"].ToString(),
                            Gia = Convert.ToDecimal(reader["Gia"]),                        
                            HinhAnh = reader["HinhAnh"].ToString(),
                            MaDM = reader["MaDM"].ToString(),
                        };
                    }
                }
            }
            return null;
        }
        public bool UpdateMon(DTO_ThucDon thucDon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateMon", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@MaMon", thucDon.MaMon);
                        cmd.Parameters.AddWithValue("@MaDM", thucDon.MaDM);
                        cmd.Parameters.AddWithValue("@TenMon", thucDon.TenMon);
                        cmd.Parameters.AddWithValue("@Gia", thucDon.Gia);
                        cmd.Parameters.AddWithValue("@HinhAnh", thucDon.HinhAnh);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật món: " + ex.Message);
            }
        }
    }
}
   