using FluentValidation.Results;
using FluentValidation;

namespace ProjetoTccEmpresa_API.Domain.Entities.Validator
{
    public class ValidatorBase
    {
        protected async Task Notify(ValidationResult validationResult)
        {
            foreach ( ValidationFailure error in validationResult.Errors)
            {
                await Notify(error.ErrorMessage);
            }
        }

        private async Task Notify(string message, string code = null)
        {
            await Notify(message, code);
        }

        protected bool RunValidationNoBaseEntity<TV, TE>(TV validate, TE entity) where TV : AbstractValidator<TE>
        {
            ValidationResult validationResult = validate.Validate(entity);
            if (validationResult.IsValid)
            {
                return true;
            }
            Notify(validationResult).Wait();
            return false;
        }
    }
}
