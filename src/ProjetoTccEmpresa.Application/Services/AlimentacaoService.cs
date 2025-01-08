using AutoMapper;
using MediatR;
using ProjetoTccEmpresa.Application.DTOs.Alimentacao.Requests.Search;
using ProjetoTccEmpresa.Application.Interfaces;
using ProjetoTccEmpresa.Application.Features.Alimentacao.Search;
using ProjetoTccEmpresa.Domain.Models;
using ProjetoTccEmpresa.Domain.Wrappers;

namespace ProjetoTccEmpresa.Application.Services
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
