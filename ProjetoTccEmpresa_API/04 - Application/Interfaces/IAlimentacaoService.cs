using ProjetoTccEmpresa_API.Application.DTOs.Alimentacao.Requests.Search;
using ProjetoTccEmpresa_API.Domain.Models;
using ProjetoTccEmpresa_API.Domain.Wrappers;

namespace ProjetoTccEmpresa_API.Application.Interfaces
{
    public interface IAlimentacaoService
    {
        Task<Pagination<IEnumerable<Alimentacao>>> SearchAlimentacao(SearchAlimentacaoRequest request);
    }
}
