using Dapper;
using ProjetoTccEmpresa_API.Domain.Wrappers;
using ProjetoTccEmpresa_API.Domain.Interfaces;
using ProjetoTccEmpresa_API.Domain.Models;
using ProjetoTccEmpresa_API.Infrastructure.Data.Context;
using System.Data.SqlClient;
using System.Data;
using ProjetoTccEmpresa_API.Infrastructure.Data.Core.Extensions;
using Microsoft.Win32;

namespace ProjetoTccEmpresa_API.Infrastructure.Repositories
{
    public class AlimentacaoRepository : IAlimentacaoRepository
    {
        public IConfiguration _config;
        public IDbTransaction _dbTransaction;

        public AlimentacaoRepository(IConfiguration configuration, IDbTransaction dbTransaction)
        {
            _config = configuration;
            _dbTransaction = dbTransaction;
        }

        public async Task<Pagination<IEnumerable<Alimentacao>>> GetAlimentacao(int pageNumber, int pageSize)
        {
            using (var sqlConnection = new SqlConnection(_config.GetConnectionString(nameof(TccEmpresaContext))))
            {
                string _query = @"
                    SELECT COUNT(1)
                    FROM alimentacao(nolock);

                    SELECT id_alimentacao as IdAlimentacao
                        , alimentacao
                    FROM alimentacao(nolock)
                    ORDER BY id_alimentacao ASC
                    OFFSET @Offset ROWS
                    FETCH NEXT @Rows ROWS ONLY;
                ";

                var parms = new DynamicParameters();

                parms.Add("@Offset", (pageNumber - 1) * pageSize);
                parms.Add("@Rows", pageSize);

                var result = await sqlConnection.QueryMultipleAsyncWithRetry(sql:  _query,
                                                                            param: parms,
                                                                            commandType: CommandType.Text,
                                                                            commandTimeout: 3000,
                                                                            transaction: _dbTransaction);

                var totalRecords = await result.ReadSingleAsync<int>();
                var records = await result.ReadAsync<Alimentacao>();

                return new Pagination<IEnumerable<Alimentacao>>(records, pageNumber, pageSize, totalRecords);

            }
        }

        public Alimentacao GetAlimentacaoById(int id)
        {
            using (var sqlConnection = new SqlConnection(_config.GetConnectionString(nameof(TccEmpresaContext))))
            {
                string _query = $@"
                    SELECT id_alimentacao as IdAlimentacao
                        , alimentacao
                    FROM alimentacao(nolock)
                    WHERE id_alimentacao = '{id}'
                ";

                return sqlConnection.QueryFirstOrDefault<Alimentacao>(_query, commandTimeout: 300);
            }
        }
    }
}
