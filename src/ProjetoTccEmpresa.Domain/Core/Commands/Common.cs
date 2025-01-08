using MediatR;
using ProjetoTccEmpresa.Domain.Core.Messages.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoTccEmpresa.Domain.Core.Commands
{
    public abstract class Common : IRequest<ICommandResult>, IBaseRequest
    {
        public DateTime Timestamp { get; private set; }

        [JsonIgnore]
        public ValidationResult? ValidationResult { get; set; }

        protected Common()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
