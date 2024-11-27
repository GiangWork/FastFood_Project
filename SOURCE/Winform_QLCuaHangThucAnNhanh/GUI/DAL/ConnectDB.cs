using System.Data.SqlClient;

namespace DAL
{
    public class ConnectDB
    {
		public static SqlConnection GetConnection()
		{
			string connectionString = "Data Source=LAPTOP-EDMBMPP4\\SQLEXPRESS;Initial Catalog=QLCuaHangKFC;Integrated Security=True"; 
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open(); 
			return connection;
		}
	}
}
