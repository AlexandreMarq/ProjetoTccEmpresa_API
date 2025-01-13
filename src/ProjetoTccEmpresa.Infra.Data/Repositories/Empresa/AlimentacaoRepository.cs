using Dapper;
using Microsoft.Extensions.Configuration;
using ProjetoTccEmpresa.Domain.DTO;
using ProjetoTccEmpresa.Domain.Interfaces;
using ProjetoTccEmpresa.Domain.Interfaces.Repositories.Empresa;
using ProjetoTccEmpresa.Infra.Data.Context;
using System.Collections;
using System.Data.SqlClient;

namespace ProjetoTccEmpresa.Infra.Data.Repositories.Empresa
{
    public class AlimentacaoRepository : IAlimentacaoRepository
    {
        public IConfiguration _configuration;
        public AlimentacaoRepository(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public IEnumerable<AlimentacaoDTO> GetFonteAlimentacao()
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString(nameof(EmpresaContext))))
            {
                string query = @"
                                SELECT id_alimentacao as AlimentacaoId
                                    , alimentacao as Alimentacao
                                FROM alimentacao(nolock)
                ";

                return sqlConnection.Query<AlimentacaoDTO>(query, commandTimeout: 300);
            }


            
        }
    }
}
