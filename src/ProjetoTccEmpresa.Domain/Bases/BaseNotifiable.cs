using Flunt.Notifications;
using ProjetoTccEmpresa.Domain.Enum;
using ProjetoTccEmpresa.Domain.Interfaces;

namespace ProjetoTccEmpresa.Domain.Bases
{
    public abstract class BaseNotifiable : Notifiable<Notification>
    {
        public static IResult<TData> Success<TData>(TData data, string message = null)
        {
            message ??= "Operation completed successfully.";

            return new Result<TData>(data, message);
        }

        public static IResult<TData> Error<TData>(IReadOnlyCollection<Notification> notifications, string message = null)
        {
            message ??= "Error while performing the operation.";

            return new Result<TData> (notifications, message);
        }

        public static IResult<TData> ErrorWithData<TData>(TData data, IReadOnlyCollection<Notification> notifications, string message = null)
        {
            message ??= "Error while performing the operation.";

            return new Result<TData>(data, notifications, message);
        }

        public IResult<TData> StopWithNotification<TData>(ENotificationMessage notificationMessage, string key = "")
        {
            AddNotification(key, notificationMessage.ToString());

            return Error<TData>(Notifications);
        }

        public bool MergeNotificarionsAndValidade<T>(IResult<T> result)
        {
            IEnumerable<Notification> notifications = result.GetNotifications();

            foreach (Notification notification in notifications)
                AddNotification(notification);

            return IsValid;
        }
    }
}
