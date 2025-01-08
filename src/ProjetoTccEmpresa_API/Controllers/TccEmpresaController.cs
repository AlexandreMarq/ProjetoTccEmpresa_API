using Microsoft.AspNetCore.Mvc;

namespace ProjetoTccEmpresa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TccEmpresaController : ControllerBase
    {

        private readonly ILogger<TccEmpresaController> _logger;

        public TccEmpresaController(ILogger<TccEmpresaController> logger)
        {
            _logger = logger;
        }

    }
}
