using AutoMapper;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using ProjetoTccEmpresa.Domain.ViewModel;
using ProjetoTccEmpresa.Domain.Interfaces;

namespace ProjetoTccEmpresa_API.Configurations
{
    public class BaseController : ControllerBase
    {
        private readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> GetResult<T, TMapTo>(IResult<T> result)
        {
            IEnumerable<Notification> notifications = result.GetNotifications();

            IEnumerable<NotificationViewModel> notificationViewModels = _mapper.Map<IEnumerable<NotificationViewModel>>(notifications);

            var responce = new ResponceViewModel<TMapTo>
            {
                IsSuccess = !notifications.Any(),
                Data = _mapper.Map<TMapTo>(result.GetData()),
                Notifications = notificationViewModels,
                Message = result.GetMessage()
            };

            return HandleResponseAsync(responce);
        }

        public IActionResult HandleResponseAsync<T>(ResponceViewModel<T> responce)
        {
            return responce.IsSuccess ? Ok(responce) : BadRequest(responce);
        }
    }
}
