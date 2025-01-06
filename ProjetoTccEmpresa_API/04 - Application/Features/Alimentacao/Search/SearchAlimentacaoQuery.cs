using MediatR;
using ProjetoTccEmpresa_API.Application.Wrappers;
using ProjetoTccEmpresa_API.Domain.Wrappers;

namespace ProjetoTccEmpresa_API.Application.Features.Alimentacao.Search
{
    public class SearchAlimentacaoQuery : Pagination, IRequest<Pagination<IEnumerable<Domain.Models.Alimentacao>>>
    {
        public int IdAlimentacao { get; set; }
        public string alimentacao { get; set; }
    }
}
