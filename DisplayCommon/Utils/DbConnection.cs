using DisplayCommon.Models;
using Npgsql;

namespace DisplayCommon.Utils
{
    public class DbConnection
    {
        static NpgsqlConnectionStringBuilder _connection;

        public static void InitializeDb(DatabaseConfiguration configuration)
        {
            _connection = new NpgsqlConnectionStringBuilder
            {
                Host = configuration.Host,
                Database = configuration.Database,
                UserName = configuration.UserName,
                Password = configuration.Password,
                Port = configuration.Port,
                Pooling = false,
            };
        }

        public static NpgsqlConnectionStringBuilder GetConnectionString()
        {
            return _connection;
        }
    }
}
