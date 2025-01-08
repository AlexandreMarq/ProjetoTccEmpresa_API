using ProjetoTccEmpresa.Application.DTOs.Alimentacao.Requests.Search;
using ProjetoTccEmpresa.Domain.Models;
using ProjetoTccEmpresa.Domain.Wrappers;

namespace ProjetoTccEmpresa.Application.Interfaces
{
    public interface IAlimentacaoService
    {
        Task<Pagination<IEnumerable<Alimentacao>>> SearchAlimentacao(SearchAlimentacaoRequest request);
    }
}
