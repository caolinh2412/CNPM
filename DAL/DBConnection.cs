using System.Data.SqlClient;

namespace DAL
{
    public class DBConnection
    {
        public static string GetConnectionString()
        {
            string[] lines = File.ReadAllLines("config.txt");
            string authen = lines[0]?.Trim();
            string server = lines[1]?.Trim();
            string db = lines[2]?.Trim();

            if (authen == "windows")
            {
                return $"Server={server};Database={db};Integrated Security=True;TrustServerCertificate=True;";
            }
            else if (authen == "sql")
            {
                string uid = lines[3]?.Trim(); ;
                string pw = lines[4]?.Trim(); ;
                return $"Data Source={server};Initial Catalog={db};User ID={uid};Password={pw};";
            }

            throw new Exception("Cấu hình config.txt không hợp lệ.");
        }
    }
}

