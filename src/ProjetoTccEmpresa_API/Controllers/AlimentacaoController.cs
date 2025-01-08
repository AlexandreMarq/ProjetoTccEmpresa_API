using Microsoft.AspNetCore.Mvc;
using ProjetoTccEmpresa.Application.DTOs.Alimentacao.Requests.Search;
using ProjetoTccEmpresa.Application.Interfaces;
using System.Net;

namespace ProjetoTccEmpresa_API.Controllers
{
    [Route("api/alimentacao")]
    public class AlimentacaoController 
    {
        private readonly IAlimentacaoService _service;

        public AlimentacaoController(IAlimentacaoService service)
        {
            service = _service;
        }

        [HttpGet]
        public async Task<IActionResult> SearchAlimentacao([FromQuery] SearchAlimentacaoRequest request)
        {
            var alimentacao = await _service.SearchAlimentacao(request);

            return null;
        }

    }
}
