using Dapper;
using ProjetoTccEmpresa_API.Infrastructure.Resilience.Policies;
using System.Data;

namespace ProjetoTccEmpresa_API.Infrastructure.Data.Core.Extensions
{
    public static class DapperExtension
    {
        public static async Task<SqlMapper.GridReader> QueryMultipleAsyncWithRetry(this IDbConnection cnn, string sql, object param = null,
                                                                                    IDbTransaction transaction = null, int? commandTimeout = null,
                                                                                    CommandType? commandType = null) => 
            await DatabaseRetryPolicy.RetryPolicy.ExecuteAsync(async () => await cnn.QuerySingleAsync(sql, param, transaction, commandTimeout, commandType));
    }
}
