using FluentValidation;
using ProjetoAPICoel.Application.Dtos;

namespace ProjetoAPICoel.Application.Validators
{
    public class CastrarProdutoValidator : AbstractValidator<CastrarProdutoRequest>
    {
        public CastrarProdutoValidator()
        {
            ValidaCamposObrigatorios();
        }

        private void ValidaCamposObrigatorios()
        {
            RuleFor(x => x.ModeloProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.DescricaoReduzidaProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.DescricaoCompletaProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.StatusProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.LinkProdutoSite).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.ParemetrosProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.AlarmesProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.EsquemaLigacaoProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.LinkExemploLigacao).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.DimencoesProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.IdFuncaoProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.IdCategoriaProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.CertificadoProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.AlimentacaoProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.CodManualProduto).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
            RuleFor(x => x.CategoriaVenda).NotEmpty().WithMessage(" Todos os campos são obrigatórios");
        }
    }
}
