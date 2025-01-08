using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccEmpresa.Domain.Core.Bus;
using ProjetoTccEmpresa.Domain.Core.Events.Handlers;
using ProjetoTccEmpresa.Domain.Core.Notifications;
using System.Net;

namespace ProjetoTccEmpresa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TccEmpresaController : ControllerBase
    {
        private readonly Handler _events;
        private readonly Guid _guid;
        private readonly IMediatorHandler mediator;

        protected TccEmpresaController(INotificationHandler<Notification> notification, IMediatorHandler mediator)
        {
            _events = (Handler)notification;
            _guid = GetGuidId();
            _mediator = mediator;
        }

        protected IActionResult Responce(object result = null, HttpStatusCode? httpStatusCode = null)
        {
            if (result == null && IsValid())
            {
                return GetResponce(HttpStatusCode.NotFound, null);
            }

            if (!IsValid())
            {
                return GetResponce(httpStatusCode.HasValue ? httpStatusCode.Value : HttpStatusCode.OK, result);
            }

            return GetResponce(httpStatusCode.HasValue ? httpStatusCode.Value : HttpStatusCode.OK, result);
        }

        protected bool IsValid()
        {
            return !_events.HasNotifications();
        }
        private IActionResult GetResponce(HttpStatusCode statusCode, object data)
        {
            return StatusCode((int)statusCode, )
        }

    }
}
