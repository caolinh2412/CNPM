using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.DAO
{
    public class DataProvider
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\THUY_LINH\Documents\cafeShop.mdf;Integrated Security=True;Connect Timeout=30;Encrypt= False");

        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            connect.Open();
            SqlCommand command = new SqlCommand(query, connect);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connect.Close();
            return data;
        }
    }
}
