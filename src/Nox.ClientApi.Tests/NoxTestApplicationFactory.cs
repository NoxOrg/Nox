using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Nox.EntityFramework.Postgres;
using Nox.EntityFramework.SqlServer;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Testcontainers.PostgreSql;

namespace ClientApi.Tests;

public class NoxTestApplicationFactory : WebApplicationFactory<StartupFixture>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
      .WithImage("postgres:14.7")
      .WithDatabase("db")
      .WithUsername("postgres")
      .WithPassword("postgres")
      .WithCleanUp(true)
      .Build();

    Task IAsyncLifetime.DisposeAsync()
    {
        return _postgreSqlContainer.DisposeAsync().AsTask();
    }

    public Task InitializeAsync()
    {
        return _postgreSqlContainer.StartAsync();
    }

    protected override IWebHostBuilder? CreateWebHostBuilder()
    {
        var host = WebHost.CreateDefaultBuilder(null!)
            .UseStartup<StartupFixture>().ConfigureTestServices(services =>
            {
                // Remove AppDbContext
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(INoxDatabaseProvider));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                services.AddScoped<INoxDatabaseProvider>(sp=>
                {
                    var configurations = sp.GetServices<INoxTypeDatabaseConfigurator>();
                    return new PostgreSqlTestProvider(_postgreSqlContainer.GetConnectionString(), configurations);
                });



                //// Add DB context pointing to test container
                //services.AddDbContext<AppDbContext>(options => { options.UseNpgsql("the new connection string"); });

                //// Ensure schema gets created
                //var serviceProvider = services.BuildServiceProvider();

                //using var scope = serviceProvider.CreateScope();
                //var scopedServices = scope.ServiceProvider;
                //var context = scopedServices.GetRequiredService<AppDbContext>();
                //context.Database.EnsureCreated();
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
    {/*
          Host = dbServer.ServerUri,
            Port = dbServer.Port ?? 5432,
            Username = dbServer.User,
            Password = dbServer.Password,
            Database = dbServer.Name,
            ApplicationName = applicationName,
      */
        return optionsBuilder
         //.UseLazyLoadingProxies()
         .UseNpgsql(ConnectionString, opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
        //var dbServer = new DatabaseServer 
        //{ 

        //};
        //return base.ConfigureDbContext(optionsBuilder, applicationName, dbServer );
    }
}