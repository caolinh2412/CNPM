using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ThucDon_DAL
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";
        public string maMonMoi;

        public List<ThucDon_DTO> GetMenuItemsByCategory(string category)
        {
            List<ThucDon_DTO> menuItems = new List<ThucDon_DTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaMon, TenMon, Gia, LoaiMon, TrangThai, HinhAnh FROM Menu WHERE LoaiMon = @LoaiMon";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoaiMon", category);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThucDon_DTO item = new ThucDon_DTO
                        {
                            MaMon = reader["MaMon"].ToString(),
                            TenMon = reader["TenMon"]?.ToString() ?? string.Empty,
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            LoaiMon = reader["LoaiMon"]?.ToString() ?? string.Empty,
                            TrangThai = reader["TrangThai"]?.ToString() ?? string.Empty,
                            HinhAnh = reader["HinhAnh"]?.ToString() ?? string.Empty
                        };
                        menuItems.Add(item);
                    }
                }
            }
            return menuItems;
        }

        public List<ThucDon_DTO> GetAllMenuItems()
        {
            List<ThucDon_DTO> menuItems = new List<ThucDon_DTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaMon, TenMon, Gia, LoaiMon, TrangThai, HinhAnh FROM Menu";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ThucDon_DTO item = new ThucDon_DTO
                        {
                            MaMon = reader["MaMon"].ToString(),
                            TenMon = reader["TenMon"]?.ToString() ?? string.Empty,
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            LoaiMon = reader["LoaiMon"]?.ToString() ?? string.Empty,
                            TrangThai = reader["TrangThai"]?.ToString() ?? string.Empty,
                            HinhAnh = reader["HinhAnh"]?.ToString() ?? string.Empty
                        };
                        menuItems.Add(item);
                    }
                }
            }
            return menuItems;
        }
        public bool ThemMonMoi(ThucDon_DTO mon)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string procedureName = "ThemMon";
                    SqlCommand cmd = new SqlCommand(procedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LoaiMon", mon.LoaiMon);
                    cmd.Parameters.AddWithValue("@TenMon", mon.TenMon);
                    cmd.Parameters.AddWithValue("@Gia", mon.Gia);
                    cmd.Parameters.AddWithValue("@HinhAnh", mon.HinhAnh);

                    SqlParameter maMonParam = new SqlParameter("@MaMon", SqlDbType.NVarChar, 10);
                    maMonParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(maMonParam);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        maMonMoi = maMonParam.Value.ToString();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {            
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }
        public bool XoaMon(string maMon)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Menu WHERE MaMon = @MaMon", connection))
                {
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
        public ThucDon_DTO GetMonById(string maMon)
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
                        return new ThucDon_DTO
                        {
                            MaMon = reader["MaMon"].ToString(),
                            TenMon = reader["TenMon"].ToString(),
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            LoaiMon = reader["LoaiMon"].ToString(),
                            TrangThai = reader["TrangThai"].ToString(),
                            HinhAnh = reader["HinhAnh"].ToString()
                        };
                    }
                }
            }
            return null;
        }
        public bool UpdateMon(ThucDon_DTO mon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateMon", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@MaMon", mon.MaMon);
                cmd.Parameters.AddWithValue("@TenMon", mon.TenMon);
                cmd.Parameters.AddWithValue("@Gia", mon.Gia);
                cmd.Parameters.AddWithValue("@LoaiMon", mon.LoaiMon);
                cmd.Parameters.AddWithValue("@TrangThai", mon.TrangThai);
                cmd.Parameters.AddWithValue("@HinhAnh", mon.HinhAnh);
                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
