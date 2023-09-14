using DotNet.Testcontainers.Containers;
using Nox;
using Testcontainers.MsSql;
using Testcontainers.PostgreSql;

namespace ClientApi.Tests;

public class NoxTestContainerService : IAsyncLifetime
{
    private DockerContainer? _dockerContainer;
    private Func<string> ConnectionStringGetter = () => string.Empty;
    private readonly DatabaseServerProvider _dbProvider = DatabaseServerProvider.Postgres;


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

                ConnectionStringGetter = () => postgreContainer.GetConnectionString();
                _dockerContainer = postgreContainer;

                break;
            case DatabaseServerProvider.SqlServer:
                var sqlContainer = new MsSqlBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithEnvironment("ACCEPT_EULA", "Y")
                .WithAutoRemove(true)
                .Build();

                ConnectionStringGetter = () => sqlContainer.GetConnectionString();
                _dockerContainer = sqlContainer;

                break;
            default:
                throw new ArgumentOutOfRangeException($"{_dbProvider} is not suported");
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

    public string ConnectionString  => ConnectionStringGetter();

}
