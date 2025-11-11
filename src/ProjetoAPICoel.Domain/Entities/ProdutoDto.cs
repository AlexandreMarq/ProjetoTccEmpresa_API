using Microsoft.EntityFrameworkCore;

namespace ProjetoAPICoel.Domain.Entities
{
    [Keyless]
    public class ProdutoDto
    {
        public int IdProduto { get; set; }
        public string? ModeloProduto { get; set; }
        public string? DescricaoReduzidaProduto { get; set; }
        public string? DescricaoCompletaProduto { get; set; }
        public bool StatusProduto { get; set; }
        public string? LinkProdutoSite { get; set; }
        public string? ParemetrosProduto { get; set; }
        public string? AlarmesProduto { get; set; }
        public string? EsquemaLigacaoProduto { get; set; }
        public string? LinkExemploLigacao { get; set; }
        public string? DimencoesProduto { get; set; }
        public int CodFotoProduto { get; set; }
        public int IdFuncaoProduto { get; set; }
        public int IdCategoriaProduto { get; set; }
        public bool CertificadoProduto { get; set; }
        public int AlimentacaoProduto { get; set; }
        public int CodManualProduto { get; set; }
        public int CategoriaVenda { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtulizacao { get; set; }
    }
}
