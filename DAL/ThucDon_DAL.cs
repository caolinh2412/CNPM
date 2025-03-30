using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ThucDon_DAL
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";

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
                            MaMon = Convert.ToInt32(reader["MaMon"]),
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
                            MaMon = Convert.ToInt32(reader["MaMon"]),
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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Menu(TenMon, Gia, LoaiMon, TrangThai, HinhAnh) " +
                               "VALUES (@TenMon, @Gia, @LoaiMon, @TrangThai, @HinhAnh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenMon", mon.TenMon);
                cmd.Parameters.AddWithValue("@Gia", mon.Gia);
                cmd.Parameters.AddWithValue("@LoaiMon", mon.LoaiMon);
                cmd.Parameters.AddWithValue("@TrangThai", mon.TrangThai);
                cmd.Parameters.AddWithValue("@HinhAnh", mon.HinhAnh);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
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
    }
}
