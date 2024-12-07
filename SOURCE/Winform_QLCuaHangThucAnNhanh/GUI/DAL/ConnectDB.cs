using System.Data.SqlClient;

namespace DAL
{
    public class ConnectDB
    {
		public static SqlConnection GetConnection()
		{
			string connectionString = "Data Source=DESKTOP-1HLJNV7;Initial Catalog=QLCuaHangKFC;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=True;TrustServerCertificate=True"; 
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open(); 
			return connection;
		}
	}
}
