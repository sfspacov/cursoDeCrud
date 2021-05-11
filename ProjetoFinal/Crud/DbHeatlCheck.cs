using Crud.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Crud
{
    public class DbHeatlCheck : BaseEntity, IHealthCheck
    {

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync(cancellationToken);
                    return HealthCheckResult.Healthy();
                }
                catch (DbException ex)
                {
                    return new HealthCheckResult(status: context.Registration.FailureStatus, exception: ex);
                }
            }
        }
    }
}
