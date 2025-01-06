using AutoMapper;
using MediatR;
using ProjetoTccEmpresa_API.Application.DTOs.Alimentacao.Requests.Search;
using ProjetoTccEmpresa_API.Application.Features.Alimentacao.Search;
using ProjetoTccEmpresa_API.Application.Interfaces;
using ProjetoTccEmpresa_API.Domain.Wrappers;
using ProjetoTccEmpresa_API.Domain.Models;

namespace ProjetoTccEmpresa_API.Application.Services
{
    public class AlimentacaoService : IAlimentacaoService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AlimentacaoService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public void Dispose()
            => GC.SuppressFinalize(this);

        public async Task<Pagination<IEnumerable<Alimentacao>>> SearchAlimentacao(SearchAlimentacaoRequest request)
        {
            var query = _mapper.Map<SearchAlimentacaoQuery>(request);
            return await _mediator.Send(query);
        }
    }
}
