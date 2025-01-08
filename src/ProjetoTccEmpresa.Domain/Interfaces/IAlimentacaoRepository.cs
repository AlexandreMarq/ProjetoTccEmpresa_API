using ProjetoTccEmpresa.Domain.Models;
using ProjetoTccEmpresa.Domain.Wrappers;

namespace ProjetoTccEmpresa.Domain.Interfaces
{
    public interface IAlimentacaoRepository
    {
        Task<Pagination<IEnumerable<Alimentacao>>> GetAlimentacao(int pageNumber, int pageSize);
        Alimentacao GetAlimentacaoById(int id);
    }
}
