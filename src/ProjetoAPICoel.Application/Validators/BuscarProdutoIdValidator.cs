using FluentValidation;
using ProjetoAPICoel.Application.Dtos;

namespace ProjetoAPICoel.Application.Validators
{
    public class BuscarProdutoIdValidator : AbstractValidator<BuscarProdutoIdRequest>
    {
        public BuscarProdutoIdValidator()
        {
            RuleFor(x => x)
                .Must(x => (x.IdProduto != null && x.IdProduto.Any()))
                .WithMessage("É necessario informar o id do produto para busca");

            RuleForEach(x => x.IdProduto).ChildRules(produto =>
                produto.RuleFor(p => p)
                    .NotEmpty().WithMessage("Necessario informar o id do produto"));
        }
    }
}
