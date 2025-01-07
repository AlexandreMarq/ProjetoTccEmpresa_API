using System.Data;
using System.Data.SqlClient;

namespace ProjetoTccEmpresa_API.Infrastructure.Data.Context
{
    public class TccEmpresaContext : IDisposable
    {
        public TccEmpresaContext(IConfiguration configuration) 
        {
            Connection = new SqlConnection(configuration.GetConnectionString(nameof(TccEmpresaContext)));
            Connection.Open();
        }
        public SqlConnection Connection { get; set; }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
    }
}
