using ProjetoTccEmpresa.Domain.DTO;

namespace ProjetoTccEmpresa.Domain.Interfaces.Services
{
    public interface IAlimentacaoServices
    {
        Task<IResult<IEnumerable<AlimentacaoDTO>>> GetFonteAlimentacao();
    }
}
