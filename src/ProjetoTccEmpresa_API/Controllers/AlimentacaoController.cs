using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccEmpresa.Domain.DTO;
using ProjetoTccEmpresa.Domain.Interfaces;
using ProjetoTccEmpresa.Domain.Interfaces.Services;
using ProjetoTccEmpresa_API.Configurations;

namespace ProjetoTccEmpresa_API.Controllers
{
    [Route("api/alimentacao")]
    public class AlimentacaoController : BaseController
    {
        public AlimentacaoController(IMapper mapper) : base(mapper)
        {

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AlimentacaoDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchAlimentacao([FromServices] IAlimentacaoServices alimentacaoServices)
        {
            IResult<IEnumerable<AlimentacaoDTO>> result = await alimentacaoServices.GetFonteAlimentacao();

            return await GetResult<IEnumerable<AlimentacaoDTO>, IEnumerable<AlimentacaoDTO>>(result);
        }

    }
}
