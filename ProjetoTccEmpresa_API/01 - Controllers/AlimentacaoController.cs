using Microsoft.AspNetCore.Mvc;
using ProjetoTccEmpresa_API.Application.Interfaces;

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

    }
}
