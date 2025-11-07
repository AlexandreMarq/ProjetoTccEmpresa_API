using ProjetoCoelApi.Application.Dtos;
using ProjetoCoelAPI.Domain.Entities;

namespace ProjetoCoelApi.Application.Services
{
    public interface IProjetoCoelService
    {
        Task<List<ProdutoDto>> BuscarProdutoPorIDAsync(BuscarProdutoIdRequest resquest);
    }
}
