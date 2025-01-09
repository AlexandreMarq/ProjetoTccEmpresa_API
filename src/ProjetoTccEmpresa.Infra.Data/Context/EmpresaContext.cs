using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ProjetoTccEmpresa.Infra.Data.Context
{
    public sealed class EmpresaContext : BaseContext
    {
        public EmpresaContext(IConfiguration configurarion)
        {
            Connection = new SqlConnection(configurarion.GetConnectionString(nameof(EmpresaContext)));
            Connection.Open();
        } 
    }
}
