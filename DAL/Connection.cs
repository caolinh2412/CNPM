using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Connection
    {
        private static SqlConnection? cn;

        public static void connect()
        {

            string s = "initial catalog = CafeShop; data source = LAPTOP-K789CPDG; integrated security = true";

            cn = new SqlConnection(s);
            cn.Open();

        }

        public static void actionQuery(string sql)
        {
            connect();
            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.ExecuteNonQuery();
        }

        public static DataTable selectQuery(string sql)
        {
            connect();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }


        public static void executeProc(string procName, params SqlParameter[] sqlParameters)

        {
            connect();
            SqlCommand cmd = new SqlCommand(procName, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            if (sqlParameters != null)
            {
                cmd.Parameters.AddRange(sqlParameters);
            }

            cmd.ExecuteNonQuery();
        }
    }
}

