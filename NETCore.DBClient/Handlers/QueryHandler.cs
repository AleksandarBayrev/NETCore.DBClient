using Dapper;
using AB.NETCore.DBClient.Interfaces.Handlers;
using System.Data;

namespace AB.NETCore.DBClient
{
    public class QueryHandler : IQueryHandler
    {
        public async Task<IEnumerable<TResult>> ExecuteQuery<TResult>(
            IDbConnection connection,
            string sqlStatement,
            DynamicParameters parameters,
            CommandType commandType)
        {
            if (connection.State != ConnectionState.Open)
            {
                return await Task.FromResult(Enumerable.Empty<TResult>());
            }

            return await Task.FromResult(
                await connection.QueryAsync<TResult>(
                    sqlStatement,
                    parameters,
                    commandType: commandType
                ).ConfigureAwait(false)
            );
        }
    }
}