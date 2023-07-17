using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.EntityFramework.Sqlite;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using System.Reflection;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Tests.DatabaseIntegrationTests;

public abstract class SqliteTestBase : IDisposable
{
    private const string _inMemoryConnectionStringTemplate = "DataSource=:memory:";
    //private const string _inMemoryConnectionStringTemplate = @"DataSource=test_database_{0}.db";
    private static string _inMemoryConnectionString = string.Empty;
    private const string _relativeTestSolutionFile = @"./DatabaseIntegrationTests/Design/test.solution.nox.yaml";
    private static string _absoluteTestSolutionFile = string.Empty;
    private readonly SqliteConnection _connection;

    protected TestWebAppDbContext DbContext;
    private readonly ServiceProvider _serviceProvider;

    protected SqliteTestBase()
    {
        ServiceCollection services = new ServiceCollection();
        // TODO  add ...BuilderExtension.cs generated class and call AddNox when Nox supports dynamic db db providers
        // This will build dbcontext etc..
        services.AddNoxLib(Assembly.GetExecutingAssembly()!);

        _serviceProvider = services.BuildServiceProvider();

        // Save absolute path one time so during re-creation
        // path won't change
        _absoluteTestSolutionFile = Path.GetFullPath(_relativeTestSolutionFile);

#pragma warning disable S3457 // Composite format strings should be used correctly
        _inMemoryConnectionString = string.Format(_inMemoryConnectionStringTemplate, DateTime.UtcNow.Ticks);
#pragma warning restore S3457 // Composite format strings should be used correctly
        _connection = new SqliteConnection(_inMemoryConnectionString);
        _connection.Open();
        DbContext = CreateDbContext(_connection,_serviceProvider);
    }

    private static TestWebAppDbContext CreateDbContext(SqliteConnection connection, IServiceProvider serviceProvider)
    {
        var databaseConfigurator = new SqliteDatabaseProvider(serviceProvider.GetServices<INoxTypeDatabaseConfigurator>());
        var solution = new NoxSolutionBuilder()
            .UseYamlFile(_absoluteTestSolutionFile)
            .Build();
        var options = new DbContextOptionsBuilder<TestWebAppDbContext>()
            .UseSqlite(connection)
            .Options;
        var dbContext = new TestWebAppDbContext(options, solution, databaseConfigurator);
        dbContext.Database.EnsureCreated();
        return dbContext;
    }

    internal void RecreateDbContext()
    {
        var previousDbContext = DbContext;
        DbContext = CreateDbContext(_connection, _serviceProvider);
        previousDbContext.Dispose();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        DbContext?.Dispose();
        _connection.Dispose();
        _serviceProvider?.Dispose();
    }
}