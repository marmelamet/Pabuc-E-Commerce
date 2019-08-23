using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace fiesta
{
    /// <summary>
    /// fiesta.dbLayer. MsSql bağlantı methodları ve parametreleri içindir.
    /// </summary>

    public class dblayer
    {
        /// <summary>
        /// fiesta.dbLayer. web.configDosyasından MsSql bağlantı bilgisini getirir.
        /// </summary>
        public static string GetConnection()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["pabuc"].ConnectionString;
        }
        /// <summary>
        /// fiesta.dbLayer. Mssql'den verileri okumak için kullanılır.
        /// </summary>
        public static DataTable ReadSqlData(string sql, List<SqlParameter> parameters, CommandType cmdType)
        {
            SqlConnection conn = new SqlConnection(GetConnection());
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;
            if (parameters != null)
                for (int i = 0; i < parameters.Count; i++)
                    cmd.Parameters.Add(parameters[i]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static DataTable ReadSqlData(string sql, CommandType cmdType)
        {

            SqlConnection conn = new SqlConnection(GetConnection());
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        /// <summary>
        /// fiesta.dbLayer. Mssql'de T-sql çalıştırır veri döndürmez. Sadece çalıştırılan sp'den dönen değeri verir.
        /// </summary>
        public static int ExecSqlNonQuery(string sql, List<SqlParameter> parameters, CommandType cmdType)
        {
            SqlConnection conn = new SqlConnection(GetConnection());
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = cmdType;
            SqlParameter retval = new SqlParameter("returnVal", SqlDbType.Int);
            retval.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retval);
            if (parameters != null)
                for (int i = 0; i < parameters.Count; i++)
                    cmd.Parameters.Add(parameters[i]);
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return Convert.ToInt32(retval.Value);
        }
    }
}
