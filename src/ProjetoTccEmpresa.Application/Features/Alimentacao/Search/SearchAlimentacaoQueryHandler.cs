using AutoMapper;
using MediatR;
using ProjetoTccEmpresa_API.Domain.Interfaces;
using ProjetoTccEmpresa_API.Domain.Wrappers;
using ProjetoTccEmpresa_API.Domain.Entities.Validator;

namespace ProjetoTccEmpresa_API.Application.Features.Alimentacao.Search
{
    public class SearchAlimentacaoQueryHandler: ValidatorBase, IRequestHandler<SearchAlimentacaoQuery, Pagination<IEnumerable<Domain.Models.Alimentacao>>>
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
