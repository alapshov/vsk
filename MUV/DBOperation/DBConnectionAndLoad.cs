using System.Data;
using System.Data.SqlClient;

namespace MUV.DBOperation
{
    internal class DBConnectionAndLoad
    {
        /// <summary>
        /// Соединение с базой данных
        /// </summary>
        /// <param name="connectionString">строка соединения</param>
        /// <returns></returns>
        internal SqlConnection Connection(string connectionString)
        {
                                   
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        /// <summary>
        /// Загрузка данных из таблицы
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <param name="connection">SqlConnection</param>
        /// <returns></returns>
        internal DataTable DataLoad(string query, SqlConnection connection)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }
    }
}
