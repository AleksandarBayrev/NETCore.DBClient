using Npgsql;

namespace AB.NETCore.DBClient.PostgreSQLTest.Db
{
    internal static class Connection
    {
        private static NpgsqlConnection _connection;
        public static NpgsqlConnection GetConnection(ConnectionConfiguration model, bool overrideInstance = false)
        {
            if (_connection == null || overrideInstance)
            {
                var connectionString = new NpgsqlConnectionStringBuilder();
                connectionString.Host = model.Host;
                connectionString.Port = model.Port;
                connectionString.Username = model.Username;
                connectionString.Password = model.Password;
                connectionString.SearchPath = model.SearchPath;
                connectionString.Database = model.Database;
                _connection = new NpgsqlConnection(connectionString.ConnectionString);
            }
            return _connection;
        }
    }
}
