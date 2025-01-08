using ProjetoTccEmpresa_API.Domain.Models;
using ProjetoTccEmpresa_API.Domain.Wrappers;

namespace ProjetoTccEmpresa_API.Domain.Interfaces
{
    public interface IAlimentacaoRepository
    {
        Task<Pagination<IEnumerable<Alimentacao>>> GetAlimentacao(int pageNumber, int pageSize);
        Alimentacao GetAlimentacaoById(int id);
    }
}
