using Microsoft.Extensions.Configuration;
using ProjetoCoelApi.Application.Dtos;
using ProjetoCoelApi.Application.Services;
using ProjetoCoelAPI.Domain.Entities;
using ProjetoCoelAPI.Infrastructure.Data;

namespace ProjetoCoelAPI.Infrastructure.Service
{
    public class ProjetoCoelService : IProjetoCoelService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public ProjetoCoelService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<List<ProdutoDto>> BuscarProdutoPorIDAsync(BuscarProdutoIdRequest request)
        {
            var idProduto = string.Join(",", request.IdProduto.Select(p => $"{p}"));
            var filtroProduto = $" IdProduto IN ({idProduto})";
            var _query = $@" 
                SELECT IdProduto
                        ,ModeloProduto
                        ,DescricaoReduzidaProduto
                        ,DescricaoCompletaProduto 
                        ,StatusProduto 
                        ,LinkProdutoSite
                        ,ParemetrosProduto 
                        ,AlarmesProduto
                        ,EsquemaLigacaoProduto 
                        ,LinkExemploLigacao 
                        ,DimencoesProduto 
                        ,CodFotoProduto 
                        ,IdFuncaoProduto 
                        ,IdCategoriaProduto 
                        ,CertificadoProduto 
                        ,AlimentacaoProduto 
                        ,CodManualProduto 
                        ,CategoriaVenda 
                        ,DataCriacao 
                        ,DataAtulizacao
                FROM Produtos(NOLOCK)
                WHERE {idProduto}
            ";
            return await _context.Set<ProdutoDto>().FromSqlRaw(_query).ToListAsync();
        }
    }
}