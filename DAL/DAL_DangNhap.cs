using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Configuration;

namespace DAL
{
    public class DAL_DangNhap
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["CafeShopConnection"].ConnectionString;
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
                                MaNV = reader["MaNV"].ToString(),
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
