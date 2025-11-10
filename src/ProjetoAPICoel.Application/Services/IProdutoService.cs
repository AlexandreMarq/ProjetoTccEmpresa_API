using ProjetoAPICoel.Application.Dtos;
using ProjetoAPICoel.Domain.Entities;

namespace ProjetoAPICoel.Application.Services
{
    public interface IProdutoService
    {
        Task<List<ProdutoDto>> BuscarProdutoPorIDAsync(BuscarProdutoIdRequest resquest);
        Task<int> CadastraProdutoAsync(CastrarProdutoRequest resquest);
    }
}
