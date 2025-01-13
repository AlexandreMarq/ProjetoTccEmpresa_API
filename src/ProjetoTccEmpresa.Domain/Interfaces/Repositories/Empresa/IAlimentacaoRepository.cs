using ProjetoTccEmpresa.Domain.DTO;

namespace ProjetoTccEmpresa.Domain.Interfaces.Repositories.Empresa
{
    public interface IAlimentacaoRepository
    {
        IEnumerable<AlimentacaoDTO> GetFonteAlimentacao();
    }
}
