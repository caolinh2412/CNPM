using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DanhMuc
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";

        public List<DTO_DanhMuc> LayDanhSachDanhMuc()
        {
            List<DTO_DanhMuc> danhMucList = new List<DTO_DanhMuc>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string procedureName = "LayDanhSachTenDanhMuc";

                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            DTO_DanhMuc danhMuc = new DTO_DanhMuc
                            {
                                MaDM = reader["MaDM"]?.ToString() ?? string.Empty,
                                TenDM = reader["TenDM"]?.ToString() ?? string.Empty 
                            };
                            danhMucList.Add(danhMuc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách danh mục: " + ex.Message);
            }

            return danhMucList;
        }
        public void ThemDanhMuc(string maDM, string tenDM)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ThemDanhMuc", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaDM", maDM);
                    cmd.Parameters.AddWithValue("@TenDM", tenDM);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void XoaDanhMuc(string maDM)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_XoaDanhMuc", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaDM", maDM);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

