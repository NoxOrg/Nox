using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Nox.Integration.Store.SqlServer;

public static class SqlServerStoreOptionsBuilderExtension
{
    public static StoreOptionsBuilder UseSqlServer(this StoreOptionsBuilder optionsBuilder)
    {
        var serverConfig = optionsBuilder.ServerConfiguration;
        optionsBuilder
            .ServiceCollection
            .AddDbContext<IntegrationDbContext>(opt =>
            {
                var csb = new SqlConnectionStringBuilder(serverConfig.Options)
                {
                    DataSource = $"{serverConfig.ServerUri},{serverConfig.Port ?? 1433}",
                    UserID = serverConfig.User,
                    Password = serverConfig.Password,
                    InitialCatalog = serverConfig.Name,
                    ApplicationName = "IntegrationStore"
                };
                opt.UseSqlServer(csb.ConnectionString);
            });
        return optionsBuilder;
    }
}