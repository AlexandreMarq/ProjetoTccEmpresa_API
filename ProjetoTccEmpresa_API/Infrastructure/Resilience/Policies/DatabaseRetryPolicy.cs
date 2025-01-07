using Polly.Contrib.WaitAndRetry;
using Polly.Retry;
using Polly;
using System.Data.SqlClient;
using ProjetoTccEmpresa_API.Infrastructure.Resilience.Shared;
using System.ComponentModel;
using Serilog;

namespace ProjetoTccEmpresa_API.Infrastructure.Resilience.Policies
{
    public class DatabaseRetryPolicy
    {
        private static TimeSpan MaxDelay => TimeSpan.FromSeconds(30);

        private static readonly IEnumerable<TimeSpan> RetryTimes = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromMicroseconds(1), retryCount: 2)
            .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, MaxDelay.Ticks)));

        public static readonly AsyncRetryPolicy RetryPolicy = Policy
                                                    .Handle<SqlException>(SqlServerTransientExceptionDetector.ShouldRetryOn)
                                                    .Or<TimeoutException>()
                                                    .OrInner<Win32Exception>(SqlServerTransientExceptionDetector.ShouldRetryOn)
                                                    .WaitAndRetryAsync(RetryTimes,
                                                        (exception, timeSpan, retryCount, context) =>
                                                        {
                                                            Log.Warning(
                                                                exception,
                                                                $"Failed to connect to the SQL Server. A new attempt will be made after {timeSpan}. attempt = {retryCount.ToString().PadLeft(2, '0')}"
                                                                );
                                                        });
    }
}
