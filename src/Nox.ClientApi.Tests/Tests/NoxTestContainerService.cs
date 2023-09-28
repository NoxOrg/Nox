using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Nox;
using Nox.Types.EntityFramework.Abstractions;
using Testcontainers.MsSql;
using Testcontainers.PostgreSql;

namespace ClientApi.Tests;

public class NoxTestContainerService : IAsyncLifetime
{
    //To change DatabaseProvider just replace DbProviderKind.
    public static readonly DatabaseServerProvider DbProviderKind = DatabaseServerProvider.SqlServer;

    private DockerContainer? _dockerContainer;
    private Func<string> _connectionStringGetter = () => string.Empty;
    
    public INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurations)
    {
        var connectionString = _connectionStringGetter();
        if(DbProviderKind == DatabaseServerProvider.SqlServer)
        {
            connectionString = connectionString.Replace("master", "clientapi");
        }
        return DbProviderKind switch
        {
            DatabaseServerProvider.Postgres => new PostgreSqlTestProvider(connectionString, configurations),
            DatabaseServerProvider.SqlServer => new MsSqlTestProvider(connectionString, configurations),
            _ => throw new NotImplementedException($"{DbProviderKind} is not suported"),
        };
    }

    public Task InitializeAsync()
    {
        switch (DbProviderKind)
        {
            case DatabaseServerProvider.Postgres:
                var postgreContainer = new PostgreSqlBuilder()
                  .WithImage("postgres:14.7")
                  .WithDatabase("db")
                  .WithUsername("postgres")
                  .WithPassword("postgres")
                  .WithAutoRemove(true)
                  .WithCleanUp(true)
                  .Build();

                _connectionStringGetter = postgreContainer.GetConnectionString;
                _dockerContainer = postgreContainer;

                break;
            case DatabaseServerProvider.SqlServer:
                var sqlContainer = new MsSqlBuilder()                
                .WithAutoRemove(true)                
                .WithCleanUp(true)
                .Build();

                _connectionStringGetter = sqlContainer.GetConnectionString;
                _dockerContainer = sqlContainer;

                break;
            default:
                throw new NotImplementedException($"{DbProviderKind} is not supported");
        }

        return _dockerContainer.StartAsync();
    }

    public Task DisposeAsync()
    {
        if (_dockerContainer is null)
        {
            throw new ApplicationException("Container has not been started yet. Invoke StartAsync method first.");
        }
        return _dockerContainer.DisposeAsync().AsTask();
    }
}
