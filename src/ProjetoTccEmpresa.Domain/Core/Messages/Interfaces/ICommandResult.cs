using System.ComponentModel.DataAnnotations;

namespace ProjetoTccEmpresa.Domain.Core.Messages.Interfaces
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        object Data { get; set; }
        ValidationResult ValidationResult { get; set; }
    }
}
