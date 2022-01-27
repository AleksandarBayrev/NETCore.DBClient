using Dapper;
using NETCore.DBClient.Interfaces.Handlers;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.DBClient.Tests.Handlers
{
    [TestFixture]
    internal class QueryHandlerTests
    {
        [Test]
        public async Task ReturnsCorrectData_IfConnectionIsOpen()
        {
            IQueryHandler queryHandler = new QueryHandler();
            using (var connection = Mocks.DbMock.GetDbMock(ConnectionState.Open))
            {
                var result = await queryHandler.ExecuteQuery<int>(connection, "test", new DynamicParameters(), CommandType.StoredProcedure);
                var expectedResult = Mocks.GetMockData();
                Assert.AreEqual(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
            }
        }

        [Test]
        public async Task ReturnsEmptyCollection_IfConnectionIsNotOpen()
        {
            IQueryHandler queryHandler = new QueryHandler();
            using (var connection = Mocks.DbMock.GetDbMock(ConnectionState.Closed))
            {
                var result = await queryHandler.ExecuteQuery<int>(connection, "test", new DynamicParameters(), CommandType.StoredProcedure);
                var expectedResult = Enumerable.Empty<int>();
                Assert.AreEqual(JsonConvert.SerializeObject(expectedResult), JsonConvert.SerializeObject(result));
            }
        }
    }
}
