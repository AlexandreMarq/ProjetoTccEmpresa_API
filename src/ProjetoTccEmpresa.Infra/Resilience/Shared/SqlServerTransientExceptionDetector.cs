using System.ComponentModel;
using System.Data.SqlClient;

namespace ProjetoTccEmpresa_API.Infrastructure.Resilience.Shared
{
    public class SqlServerTransientExceptionDetector
    {
        public static bool ShouldRetryOn(SqlException ex)
        {
            foreach (SqlError error in ex.Errors)
            {
                switch (error.Number)
                {
                    case 20:
                        return true;
                }
            }
            return false;
        }

        public static bool ShouldRetryOn(Win32Exception ex)
        {
            return ex.NativeErrorCode switch
            {
                0x102 or 0x121 => true,
                _ => false,
            };
        }
    }
}
