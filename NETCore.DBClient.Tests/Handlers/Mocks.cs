using Dapper;
using Moq;
using Moq.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AB.NETCore.DBClient.Tests.Handlers
{
    internal static class Mocks
    {
        private static readonly IEnumerable<int> mockList = new List<int> { 1, 2, 3, 4 };

        internal static IEnumerable<int> GetMockData()
        {
            return mockList.Select(x => x).ToList();
        }

        internal static class DbMock
        {
            public static IDbConnection GetDbMock(ConnectionState connectionState)
            {
                var mock = new Mock<IDbConnection>();
                mock.CallBase = false;
                mock.SetupDapperAsync(x =>
                    x.QueryAsync<int>(
                        It.IsAny<string>(),
                        It.IsAny<DynamicParameters>(),
                        It.IsAny<IDbTransaction>(),
                        It.IsAny<int>(),
                        It.IsAny<CommandType>()
                    )
                ).ReturnsAsync(GetMockData());
                mock.SetupGet(x => x.State).Returns(connectionState);
                return mock.Object;
            }
        }
    }
}
