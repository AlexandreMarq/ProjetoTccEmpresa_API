using System.Data;

namespace ProjetoTccEmpresa.Infra.Data.Context
{
    public abstract class BaseContext : IDisposable
    {
        public IDbConnection Connection { get; protected set; }
        public IDbTransaction Transaction { get; set; }
        public void Dispose() => Connection?.Dispose();
    }
}
