using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProjetoTccEmpresa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TccEmpresaController : ControllerBase
    {
        private readonly Guid _guid;

        protected TccEmpresaController()
        {

        }

    }
}
