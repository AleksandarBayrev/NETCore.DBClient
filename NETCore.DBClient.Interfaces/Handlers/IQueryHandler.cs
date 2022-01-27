using Dapper;
using System.Data;

namespace AB.NETCore.DBClient.Interfaces.Handlers
{
    public interface IQueryHandler
    {
        Task<IEnumerable<TResult>> ExecuteQuery<TResult>(
            IDbConnection connection,
            string storedProcedure,
            DynamicParameters parameters,
            CommandType commandType
        );
    }
}
