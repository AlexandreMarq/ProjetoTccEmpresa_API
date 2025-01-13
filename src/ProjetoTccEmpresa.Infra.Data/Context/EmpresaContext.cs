using Microsoft.Extensions.Configuration;
using System.Data;
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

        public SqlConnection Connection { get; set; }

        public void Dispose()
        {
            if(Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
