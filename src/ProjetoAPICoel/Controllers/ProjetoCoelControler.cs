using Microsoft.AspNetCore.Mvc;
using ProjetoAPICoel.Application.Dtos;
using ProjetoAPICoel.Application.Services;
using ProjetoAPICoel.Application.Validators;

namespace ProjetoCoelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoCoelControler : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProjetoCoelControler(IProdutoService service)
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
            var validator = new CastrarProdutoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var retorno = await _service.CadastraProdutoAsync(request);

            if (retorno > 0)
                return BadRequest("Erro ao Cadastrar Produto");

            return Ok("Produto cadastrado com sucesso");
        }

        [HttpPost("AtualizaProduto")]
        public async Task<IActionResult> AtualizaProduto([FromQuery] AtualizarProdutoRequest request)
        {
            var validator = new AtualizarProdutoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var retorno = await _service.AtualizaProdutoIdAsync(request);

            if (retorno > 0)
                return BadRequest("Erro ao Alterar Produto");

            return Ok("Produto Atualizado com sucesso");
        }

        [HttpPost("ExcluiProduto")]
        public async Task<IActionResult> DesabilitaProduto([FromQuery] DesabilitarProdutoRequest request)
        {
            var validator = new DesabilitarProdutoValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            var retorno = await _service.DesabilitaProdutoAsync(request);

            if (retorno > 0)
                return BadRequest("Erro ao Excluir Produto");

            return Ok("Produto Excluido com sucesso");
        }
    }
}
