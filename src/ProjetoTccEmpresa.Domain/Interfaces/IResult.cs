using Flunt.Notifications;

namespace ProjetoTccEmpresa.Domain.Interfaces
{
    public interface IResult<TData>
    {
        IEnumerable<Notification> GetNotifications();
        void AddNotifications(IReadOnlyCollection<Notification> newNotifications);
        TData GetData();
        string GetMessage();
        public bool IsValid();
    }
}
