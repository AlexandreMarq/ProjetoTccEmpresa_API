using MediatR;
using ProjetoTccEmpresa.Domain.Core.Notifications;

namespace ProjetoTccEmpresa.Domain.Core.Events.Handlers
{
    public class Handler : INotificationHandler<Notification>
    {
        private List<Notification> _notifications;

        public Handler()
        {
            _notifications = new List<Notification>();
        }

        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public virtual List<Notification> GetLogs()
        {
            return _notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }
    }
}
