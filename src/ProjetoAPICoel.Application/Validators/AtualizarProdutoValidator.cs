using FluentValidation;
using ProjetoAPICoel.Application.Dtos;

namespace ProjetoAPICoel.Application.Validators
{
    public class AtualizarProdutoValidator : AbstractValidator<AtualizarProdutoRequest>
    {
        public AtualizarProdutoValidator()
        {
            ValidaCampoObrigatorio();
        }

        private void ValidaCampoObrigatorio()
        {
            RuleFor(x => x.IdProduto).NotEmpty().WithMessage("Necessario informar Id do Produto");
        }
    }
}
