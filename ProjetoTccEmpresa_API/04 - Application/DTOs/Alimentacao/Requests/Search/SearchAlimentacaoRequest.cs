using ProjetoTccEmpresa_API.Application.Wrappers;

namespace ProjetoTccEmpresa_API.Application.DTOs.Alimentacao.Requests.Search
{
    public class SearchAlimentacaoRequest : Pagination
    {
        public int id_alimentacao { get; set; }
        public string alimentacao { get; set; }
    }
}
