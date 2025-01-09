using AutoMapper;
using ProjetoTccEmpresa.Domain.Bases;
using ProjetoTccEmpresa.Domain.DTO;
using ProjetoTccEmpresa.Domain.Interfaces;
using ProjetoTccEmpresa.Domain.Interfaces.Repositories.Empresa;
using ProjetoTccEmpresa.Domain.Interfaces.Services;

namespace ProjetoTccEmpresa.Domain.Services
{
    internal class AlimentacaoServices : BaseNotifiable, IAlimentacaoServices
    {
        private readonly IAlimentacaoRepository _alimentacaoRepository;
        private readonly IMapper _mapper;

        public AlimentacaoServices(IAlimentacaoRepository alimentacaoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _alimentacaoRepository = alimentacaoRepository;
        }

        public async Task<IResult<IEnumerable<AlimentacaoDTO>>> GetFonteAlimentacao()
        {
            IResult<IEnumerable<AlimentacaoDTO>> fontesAlimentacao;

            fontesAlimentacao = await _alimentacaoRepository.GetFonteAlimentacao();
        }
    }
}
