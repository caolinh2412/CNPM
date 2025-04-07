using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_DangNhap
    {
        private string connectionString = @"Server=LAPTOP-K789CPDG;Database=CafeShop;Integrated Security=True;TrustServerCertificate=True;";
        public DTO_DangNhap KiemTraDangNhap(string email, string matKhau)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("DangNhap", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Password", matKhau));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DTO_DangNhap
                            {
                                MaND = reader["MaND"].ToString(),
                                HoVaTen = reader["HoVaTen"].ToString(),
                                Email = reader["Email"].ToString(),
                                SDT = reader["SDT"].ToString(),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                Password = reader["Password"].ToString(),
                                NgayDiLam = reader["NgayDiLam"] as DateTime?,
                                MaQL = reader["MaQL"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public bool KiemTraEmailTonTai(string email)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("KiemTraEmailTonTai", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    var result = cmd.ExecuteScalar();
                    return result != null && (int)result > 0;
                }
            }
        }
        public bool ResetPassword(string email, string newPassword)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("ResetPassword", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Password", newPassword));
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

    }
}
