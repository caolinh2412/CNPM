using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_CaLam
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";

        public List<DTO_CaLam> GetCaLamTheoNgayVaMaNV(DateTime ngay, string maNV)
        {
            List<DTO_CaLam> list = new List<DTO_CaLam>();
            string query = "SELECT * FROM LichLamViec WHERE Ngay = @ngay AND MaNV = @maNV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ngay", ngay);
                cmd.Parameters.AddWithValue("@maNV", maNV);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DTO_CaLam caLam = new DTO_CaLam
                    {
                        MaLLV = reader["MaLLV"].ToString(),
                        MaNV = reader["MaNV"].ToString(),
                        Ngay = Convert.ToDateTime(reader["Ngay"]),
                        CaLam = reader["CaLam"].ToString()
                    };
                    list.Add(caLam);
                }
            }

            return list;
        }
    }
}

