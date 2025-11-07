using Microsoft.AspNetCore.Mvc;
using ProjetoCoelApi.Application.Dtos;
using ProjetoCoelApi.Application.Services;
using ProjetoCoelApi.Application.Validators;

namespace ProjetoCoelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoCoelControler : ControllerBase
    {
        private readonly IProjetoCoelService _service;

        public ProjetoCoelControler(IProjetoCoelService service)
        {
            _service = service;
        }

        [HttpGet("Produto/id")]
        public async Task<IActionResult> BuscaProdutoId([FromQuery] BuscarProdutoIdRequest request)
        {
            var validator = new BuscarProdutoIdValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var retorno = await _service.BuscarProdutoPorIDAsync(request);

            return Ok(retorno);
        }

        [HttpPost("CadastraProduto")]
        public async Task<IActionResult> CastraProduto([FromQuery] CastrarProdutoRequest request)
        {
            return Ok();
        }

        [HttpPost("AtualizaProduto")]
        public async Task<IActionResult> AtualizaProduto([FromQuery] AtualizarProdutoRequest request)
        {
            return Ok();
        }

        [HttpPost("DesabilitaProduto")]
        public async Task<IActionResult> DesabilitaProduto([FromQuery] DesabilitarProdutoRequest request)
        {
            return Ok();
        }
    }
}
