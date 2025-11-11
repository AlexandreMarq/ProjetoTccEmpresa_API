using FluentValidation;
using ProjetoAPICoel.Application.Dtos;

namespace ProjetoAPICoel.Application.Validators
{
    public class DesabilitarProdutoValidator : AbstractValidator<DesabilitarProdutoRequest>
    {
        public DesabilitarProdutoValidator()
        {
            ValidaCampoObrigatorio();
        }

        private void ValidaCampoObrigatorio()
        {
            RuleFor(x => x.IdProduto).NotEmpty().WithMessage("Necessario informar Id do Produto");
            RuleFor(x => x.StatusProduto).NotEmpty().WithMessage("Necessario informar StatusProduto do Produto");
        }
    }
}
