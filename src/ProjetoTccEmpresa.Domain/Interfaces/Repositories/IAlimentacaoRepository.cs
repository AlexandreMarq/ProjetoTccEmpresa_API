using ProjetoTccEmpresa.Domain.DTO;

namespace ProjetoTccEmpresa.Domain.Interfaces.Repositories
{
    public interface IAlimentacaoRepository
    {
        Task<IResult<IEnumerable<AlimentacaoDTO>>> GetFonteAlimentacao();
    }
}
