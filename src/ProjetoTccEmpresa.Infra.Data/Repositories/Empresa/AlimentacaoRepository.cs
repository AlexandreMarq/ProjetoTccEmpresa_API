using Microsoft.Extensions.Configuration;
using ProjetoTccEmpresa.Domain.DTO;
using ProjetoTccEmpresa.Domain.Interfaces;
using ProjetoTccEmpresa.Domain.Interfaces.Repositories.Empresa;
using ProjetoTccEmpresa.Infra.Data.Context;

namespace ProjetoTccEmpresa.Infra.Data.Repositories.Empresa
{
    public class AlimentacaoRepository : BaseRepository<EmpresaContext, IAlimentacaoRepository>
    {
        public IConfiguration _configuration;
        public AlimentacaoRepository(EmpresaContext context, IConfiguration configuration) : base(context)
        {
            _configuration = configuration;
        }

        public Task<IResult<IEnumerable<AlimentacaoDTO>>> GetFonteAlimentacao()
        {
            return null;
        }
    }
}
