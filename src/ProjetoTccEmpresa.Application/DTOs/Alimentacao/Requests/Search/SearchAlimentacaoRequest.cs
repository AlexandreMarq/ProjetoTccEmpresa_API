using ProjetoTccEmpresa.Application.Wrappers;

namespace ProjetoTccEmpresa.Application.DTOs.Alimentacao.Requests.Search
{
    public class SearchAlimentacaoRequest : Pagination
    {
        public int id_alimentacao { get; set; }
        public string alimentacao { get; set; }
    }
}
