using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetoAPICoel.Application.Dtos;
using ProjetoAPICoel.Application.Services;
using ProjetoAPICoel.Domain.Entities;
using ProjetoAPICoel.Infrastructure.Data;

namespace ProjetoAPICoel.Infrastructure.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public ProdutoService(IConfiguration configuration, AppDbContext context)
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
                WHERE {filtroProduto}
            ";

            return await _context.Set<ProdutoDto>().FromSqlRaw(_query).ToListAsync();
        }

        public async Task<int> CadastraProdutoAsync(CastrarProdutoRequest produto)
        {

            var _query = $@"
                INSERT INTO [dbo].[Produtos]
                           ([ModeloProduto]
                           ,[DescricaoReduzidaProduto]
                           ,[DescricaoCompletaProduto]
                           ,[StatusProduto]
                           ,[LinkProdutoSite]
                           ,[ParemetrosProduto]
                           ,[AlarmesProduto]
                           ,[EsquemaLigacaoProduto]
                           ,[LinkExemploLigacao]
                           ,[DimencoesProduto]
                           ,[CodFotoProduto]
                           ,[IdFuncaoProduto]
                           ,[IdCategoriaProduto]
                           ,[CertificadoProduto]
                           ,[AlimentacaoProduto]
                           ,[CodManualProduto]
                           ,[CategoriaVenda]
                           ,[DataCriacao]
                           ,[DataAtulizacao])
                        VALUES (
                            , @ModeloProduto
                            , @DescricaoReduzidaProduto
                            , @DescricaoCompletaProduto
                            , @StatusProduto
                            , @LinkProdutoSite
                            , @ParemetrosProduto
                            , @AlarmesProduto
                            , @EsquemaLigacaoProduto
                            , @LinkExemploLigacao
                            , @DimencoesProduto
                            , @CodFotoProduto
                            , @IdFuncaoProduto
                            , @IdCategoriaProduto
                            , @CertificadoProduto
                            , @AlimentacaoProduto
                            , @CodManualProduto
                            , @CategoriaVenda
                            , @DataCriacao
                            , @DataAtulizacao
                        );
            ";

            var rows = await _context.Database.ExecuteSqlRawAsync(_query
                , new[]
                {
                    new SqlParameter("@ModeloProduto", produto.ModeloProduto ?? (object)DBNull.Value),
                    new SqlParameter("@DescricaoReduzidaProduto", produto.DescricaoReduzidaProduto ?? (object)DBNull.Value),
                    new SqlParameter("@DescricaoCompletaProduto", produto.DescricaoCompletaProduto ?? (object)DBNull.Value),
                    new SqlParameter("@StatusProduto", produto.StatusProduto),
                    new SqlParameter("@LinkProdutoSite", produto.LinkProdutoSite ?? (object)DBNull.Value),
                    new SqlParameter("@ParemetrosProduto", produto.ParemetrosProduto ?? (object)DBNull.Value),
                    new SqlParameter("@AlarmesProduto", produto.AlarmesProduto ?? (object)DBNull.Value),
                    new SqlParameter("@EsquemaLigacaoProduto", produto.EsquemaLigacaoProduto ?? (object)DBNull.Value),
                    new SqlParameter("@LinkExemploLigacao", produto.LinkExemploLigacao ?? (object)DBNull.Value),
                    new SqlParameter("@DimencoesProduto", produto.DimencoesProduto ?? (object)DBNull.Value),
                    new SqlParameter("@CodFotoProduto", produto.CodFotoProduto),
                    new SqlParameter("@IdFuncaoProduto", produto.IdFuncaoProduto),
                    new SqlParameter("@IdCategoriaProduto", produto.IdCategoriaProduto),
                    new SqlParameter("@CertificadoProduto", produto.CertificadoProduto),
                    new SqlParameter("@AlimentacaoProduto", produto.AlimentacaoProduto),
                    new SqlParameter("@CodManualProduto", produto.CodManualProduto),
                    new SqlParameter("@CategoriaVenda", produto.CategoriaVenda),
                    new SqlParameter("@DataCriacao", produto.DataCriacao),
                    new SqlParameter("@DataAtulizacao", produto.DataAtulizacao)
                });

            return rows;
        }

        public async Task<int> AtualizaProdutoIdAsync(AtualizarProdutoRequest produto)
        {
            var _query = $@"
                    UPDATE Produtos SET ModeloProduto = @ModeloProduto
                                        , DescricaoReduzidaProduto = @DescricaoReduzidaProduto
                                        , DescricaoCompletaProduto = @DescricaoCompletaProduto
                                        , StatusProduto = @StatusProduto
                                        , LinkProdutoSite = @LinkProdutoSite
                                        , ParemetrosProduto = @ParemetrosProduto
                                        , AlarmesProduto = @AlarmesProduto
                                        , EsquemaLigacaoProduto = @EsquemaLigacaoProduto
                                        , LinkExemploLigacao = @LinkExemploLigacao
                                        , DimencoesProduto = @DimencoesProduto
                                        , CodFotoProduto = @CodFotoProduto
                                        , IdFuncaoProduto = @IdFuncaoProduto
                                        , IdCategoriaProduto = @IdCategoriaProduto
                                        , CertificadoProduto = @CertificadoProduto
                                        , AlimentacaoProduto = @AlimentacaoProduto
                                        , CodManualProduto = @CodManualProduto
                                        , CategoriaVenda = @CategoriaVenda
                                        ,DataAtulizacao = @DataAtulizacao
                    WHERE IdProduto = @IdProduto     
            ";

            var rows = await _context.Database.ExecuteSqlRawAsync(_query
                ,new[]
                {
                    new SqlParameter("@IdProduto", produto.IdProduto),
                    new SqlParameter("@ModeloProduto", produto.ModeloProduto ?? (object)DBNull.Value),
                    new SqlParameter("@DescricaoReduzidaProduto", produto.DescricaoReduzidaProduto ?? (object)DBNull.Value),
                    new SqlParameter("@DescricaoCompletaProduto", produto.DescricaoCompletaProduto ?? (object)DBNull.Value),
                    new SqlParameter("@StatusProduto", produto.StatusProduto),
                    new SqlParameter("@LinkProdutoSite", produto.LinkProdutoSite ?? (object)DBNull.Value),
                    new SqlParameter("@ParemetrosProduto", produto.ParemetrosProduto ?? (object)DBNull.Value),
                    new SqlParameter("@AlarmesProduto", produto.AlarmesProduto ?? (object)DBNull.Value),
                    new SqlParameter("@EsquemaLigacaoProduto", produto.EsquemaLigacaoProduto ?? (object)DBNull.Value),
                    new SqlParameter("@LinkExemploLigacao", produto.LinkExemploLigacao ?? (object)DBNull.Value),
                    new SqlParameter("@DimencoesProduto", produto.DimencoesProduto ?? (object)DBNull.Value),
                    new SqlParameter("@CodFotoProduto", produto.CodFotoProduto),
                    new SqlParameter("@IdFuncaoProduto", produto.IdFuncaoProduto),
                    new SqlParameter("@IdCategoriaProduto", produto.IdCategoriaProduto),
                    new SqlParameter("@CertificadoProduto", produto.CertificadoProduto),
                    new SqlParameter("@AlimentacaoProduto", produto.AlimentacaoProduto),
                    new SqlParameter("@CodManualProduto", produto.CodManualProduto),
                    new SqlParameter("@CategoriaVenda", produto.CategoriaVenda),
                    new SqlParameter("@DataAtulizacao", produto.DataAtulizacao)
                });

            return rows;
        }
    }
}
