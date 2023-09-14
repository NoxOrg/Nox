using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.Postgres;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace ClientApi.Tests;

public class NoxTestApplicationFactory : WebApplicationFactory<StartupFixture>
{
    public Func<string> ConnectionStringGetter { get; internal set; } = () => string.Empty;

    protected override IWebHostBuilder? CreateWebHostBuilder()
    {
        var host = WebHost.CreateDefaultBuilder(null!)
            .UseStartup<StartupFixture>()
            .ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(INoxDatabaseProvider));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                services.AddScoped<INoxDatabaseProvider>(sp=>
                {
                    var configurations = sp.GetServices<INoxTypeDatabaseConfigurator>();
                    return new PostgreSqlTestProvider(ConnectionStringGetter(), configurations);
                });
            });
        return host;
    }
}

public class PostgreSqlTestProvider : PostgresDatabaseProvider
{
    public PostgreSqlTestProvider(string connectionString, IEnumerable<INoxTypeDatabaseConfigurator> configurators) : base(configurators)
    {
        ConnectionString = connectionString;
    }

    public override DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
    {
        return optionsBuilder.UseNpgsql(ConnectionString, opts => 
        { 
            opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); 
        });
    }
}