// See https://aka.ms/new-console-template for more information

using NETCore.DBClient;
using NETCore.DBClient.PostgreSQLTest.Db;
using NETCore.DBClient.PostgreSQLTest.DbModels;
using Newtonsoft.Json;
using Npgsql;
using System.Data;

namespace Program
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var connectionConfiguration = new ConnectionConfiguration
            {
                Host = "192.168.26.130",
                Port = 5432,
                Username = "administrator",
                Password = "Ubuntu-vps1!",
                SearchPath = "test",
                Database = "pcbuilder"
            };
            var connection = Connection.GetConnection(connectionConfiguration);
            connection.Open();
            var queryHandler = new QueryHandler();

            var res = await queryHandler.ExecuteQuery<HelloWorldModel>(
            connection,
            "SELECT * FROM test.list",
            null,
            commandType: CommandType.Text);
            Console.WriteLine($"Result: {JsonConvert.SerializeObject(res)}");
    }
}
}   