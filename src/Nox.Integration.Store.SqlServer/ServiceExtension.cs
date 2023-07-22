using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Solution;

namespace Nox.Integration.Store.SqlServer;

public static class ServiceExtension
{
    public static IServiceCollection AddSqlServerIntegrationStore(this IServiceCollection services, IntegrationDatabaseServer dbServer)
    {
        services.AddDbContext<IntegrationDbContext>(opt =>
        {
            var csb = new SqlConnectionStringBuilder(dbServer.Options)
            {
                DataSource = $"{dbServer.ServerUri},{dbServer.Port ?? 1433}",
                UserID = dbServer.User,
                Password = dbServer.Password,
                InitialCatalog = dbServer.Name,
                ApplicationName = "IntegrationStore"
            };
            opt.UseSqlServer(csb.ConnectionString);
        });
        return services;
    }
}

