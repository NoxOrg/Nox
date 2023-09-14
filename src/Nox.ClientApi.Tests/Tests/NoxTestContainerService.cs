using DotNet.Testcontainers.Containers;
using Nox;
using Nox.Types.EntityFramework.Abstractions;
using Testcontainers.MsSql;
using Testcontainers.PostgreSql;

namespace ClientApi.Tests;

public class NoxTestContainerService : IAsyncLifetime
{
    private DockerContainer? _dockerContainer;
    private Func<string> _connectionStringGetter = () => string.Empty;
    private readonly DatabaseServerProvider _dbProvider = DatabaseServerProvider.Postgres;

    public INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurations)
    {
        return _dbProvider switch
        {
            DatabaseServerProvider.Postgres => new PostgreSqlTestProvider(_connectionStringGetter(), configurations),
            DatabaseServerProvider.SqlServer => new MsSqlTestProvider(_connectionStringGetter(), configurations),
            _ => throw new NotImplementedException($"{_dbProvider} is not suported"),
        };
    }

    public Task InitializeAsync()
    {
        switch (_dbProvider)
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

                _connectionStringGetter = () => postgreContainer.GetConnectionString();
                _dockerContainer = postgreContainer;

                break;
            case DatabaseServerProvider.SqlServer:
                var sqlContainer = new MsSqlBuilder()
                  .WithAutoRemove(true)
                  .WithCleanUp(true)
                  .Build();

                _connectionStringGetter = () => sqlContainer.GetConnectionString();
                _dockerContainer = sqlContainer;

                break;
            default:
                throw new NotImplementedException($"{_dbProvider} is not suported");
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
