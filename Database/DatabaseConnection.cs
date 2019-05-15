using MySql.Data.MySqlClient;

namespace Databases
{
    public class DatabaseConnection
    {
        protected static MySqlConnection conn { get; set; }

        public void SetConnectionString(string connectionString)
        {
            conn = new MySqlConnection(connectionString);
        }
    }
}
