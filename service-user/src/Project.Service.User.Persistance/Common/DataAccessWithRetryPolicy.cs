using Dapper;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using Project.Service.User.Application.Helpers;
using Project.Service.User.Application.Options;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace Project.Service.User.Persistance.Common
{
    public class DataAccessWithRetryPolicy
    {
        protected AsyncRetryPolicy? retryPolicy;
        private string? _connectionString;
        private AppSettings appSettings;

        public DataAccessWithRetryPolicy(IOptions<AppSettings> options, string appName)
        {
            appSettings = options.Value;
            if(appSettings.ConnectionStrings.HasProperty(appName, out object value))
            {
                _connectionString = value?.ToString();
            }

            retryPolicy = Policy
                .Handle<SqlException>(SqlServerTransientExceptionDetector.ShouldRetryOn)
                .Or<TimeoutException>()
                .OrInner<Win32Exception>(SqlServerTransientExceptionDetector.ShouldRetryOn)
                .WaitAndRetryAsync(
                    appSettings.RetryAttempt,
                    retryAttemp => TimeSpan.FromSeconds(Math.Pow(appSettings.SleepTime, retryAttemp)),
                    (exception, timeSpan, context) =>
                    {
                        Console.WriteLine(exception.Message + " will retry after " + timeSpan);
                    });
        }

        public virtual async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameters, IDbTransaction? transaction = null, CommandType? cmdType = null)
        {
            return await retryPolicy.ExecuteAsync(async () =>
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return await connection.QueryAsync<T>(query, parameters, commandTimeout: appSettings.SqlTimeOut, commandType: CommandType.Text);
                }
            });
        }
    }
}
