using System.Data.SqlClient;

namespace WebApplication5
{
    public class Connection
    {
        private static SqlConnection connection;
        private Connection() { }
        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection("Data Source=SQL8001.site4now.net;Initial Catalog=db_a84e8b_bajen;User Id=db_a84e8b_bajen_admin;Password=Savelstan123");
                connection.Open();
            }
            return connection;
        }
    }
}