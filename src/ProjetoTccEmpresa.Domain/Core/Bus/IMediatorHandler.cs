using MediatR;
using ProjetoTccEmpresa.Domain.Core.Commands;
using ProjetoTccEmpresa.Domain.Core.Messages.Interfaces;

namespace ProjetoTccEmpresa.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublishNotification<T>(T @event) where T : INotification;
        Task<ICommandResult> SendCommand<T>(T @event) where T : Common;
    }
}
