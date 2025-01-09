using Flunt.Notifications;
using ProjetoTccEmpresa.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace ProjetoTccEmpresa.Domain.Bases
{
    public class Result<T> : IResult<T>
    {
        public Result()
        {
            Notifications = new List<Notification>();
        }

        public Result(T data, string message) : this()
        {
            Data = data;
            Message = message;
        }

        public Result(T data, IReadOnlyCollection<Notification> notifications, string message) : this()
        {
            Data = data;
            AddNotifications(notifications);
            Message = message;
        }

        public Result(IReadOnlyCollection<Notification> notifications, string message) : this()
        {
            AddNotifications(notifications);
            Message = message;
        }

        [JsonIgnore] public T Data { get; set; }
        [JsonIgnore] public string Message { get; set; }
        [JsonIgnore] List<Notification> Notifications { get; set; }

        #region Methods

        public T GetData() => Data;
        public string GetMessage() => Message;
        public IEnumerable<Notification> GetNotifications() => Notifications;
        public void AddNotifications(IReadOnlyCollection<Notification> notifications) => Notifications.AddRange(notifications);
        public bool IsValid()
        {
            return !Notifications.Any();
        }

        #endregion
    }
}
