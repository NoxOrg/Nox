using DotNet.Testcontainers.Containers;
using Nox;
using Nox.Types.EntityFramework.Abstractions;
using Testcontainers.MsSql;
using Testcontainers.PostgreSql;
using Xunit.Abstractions;

namespace ClientApi.Tests;

/// <summary>
/// Containerized Database instance for testing 
/// </summary>
public class TestDatabaseContainerService : IAsyncLifetime, ITestDatabaseService
{
#if DEBUG
    //To change DatabaseProvider just replace DbProviderKind.
    public static readonly DatabaseServerProvider DbProviderKind = DatabaseServerProvider.Postgres;
#else
    public static readonly DatabaseServerProvider DbProviderKind = DatabaseServerProvider.SqlServer;
#endif

    private Func<string> _connectionStringGetter = () => string.Empty;
    private DockerContainer? _dockerContainer;

    private NoxTestApplicationFactory _applicationFactory = null!;

    public NoxTestApplicationFactory GetTestApplicationFactory(ITestOutputHelper testOutput, bool enableMessagingTests, string? environment = null)
    {
        if (_applicationFactory == null)
        {
            _applicationFactory = new NoxTestApplicationFactory(testOutput, this, enableMessagingTests, environment);
        }

        return _applicationFactory;
    }

    public INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurations)
    {
        string connectionString = _connectionStringGetter();
        if (DbProviderKind == DatabaseServerProvider.SqlServer)
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

    public async Task InitializeAsync()
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

        await _dockerContainer.StartAsync();
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