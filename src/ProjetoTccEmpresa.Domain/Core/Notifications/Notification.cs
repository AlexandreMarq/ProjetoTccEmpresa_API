using MediatR;

namespace ProjetoTccEmpresa.Domain.Core.Notifications
{
    public class Notification : INotification
    {
        public string Code { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; }
        public Guid Id { get; }
        public Notification(string text, string code = null)
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
            Text = text;
            Code = code;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
