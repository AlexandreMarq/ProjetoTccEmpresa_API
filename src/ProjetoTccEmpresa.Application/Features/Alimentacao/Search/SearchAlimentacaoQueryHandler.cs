using AutoMapper;
using MediatR;
using ProjetoTccEmpresa_API.Application.Features.Alimentacao.Search;
using ProjetoTccEmpresa.Domain.Entities.Validator;
using ProjetoTccEmpresa.Domain.Interfaces;
using ProjetoTccEmpresa.Domain.Wrappers;

namespace ProjetoTccEmpresa.Application.Features.Alimentacao.Search
{
    public class SearchAlimentacaoQueryHandler : ValidatorBase, IRequestHandler<SearchAlimentacaoQuery, Pagination<IEnumerable<Domain.Models.Alimentacao>>>
    {
        private readonly IAlimentacaoRepository _repository;
        private readonly IMapper _mapper;

        public SearchAlimentacaoQueryHandler(IAlimentacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Pagination<IEnumerable<Domain.Models.Alimentacao>>> Handle(SearchAlimentacaoQuery query, CancellationToken cancellationToken)
        {
            if (!RunValidationNoBaseEntity(new SearchAlimentacaoValidation(), query))
                return null;

            return await _repository.GetAlimentacao(query.PageNumber, query.PageSize);
        }
    }
}
