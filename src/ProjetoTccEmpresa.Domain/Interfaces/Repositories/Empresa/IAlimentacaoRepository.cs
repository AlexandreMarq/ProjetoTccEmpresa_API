using ProjetoTccEmpresa.Domain.DTO;

namespace ProjetoTccEmpresa.Domain.Interfaces.Repositories.Empresa
{
    public interface IAlimentacaoRepository
    {
        Task<IResult<IEnumerable<AlimentacaoDTO>>> GetFonteAlimentacao();
    }
}
