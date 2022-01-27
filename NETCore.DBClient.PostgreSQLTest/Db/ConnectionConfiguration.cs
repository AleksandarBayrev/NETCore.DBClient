namespace NETCore.DBClient.PostgreSQLTest.Db
{
    public class ConnectionConfiguration
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string SearchPath { get; init; }
        public string Database { get; init; }
    }
}