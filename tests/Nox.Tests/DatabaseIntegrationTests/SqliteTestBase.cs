using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.Sqlite;
using Nox.Solution;
using TestDatabaseWebApp.Infrastructure.Persistence;

namespace Nox.Tests.DatabaseIntegrationTests;

public abstract class SqliteTestBase : IDisposable
{
    //private const string _inMemoryConnectionStringTemplate = "DataSource=:memory:";
    private const string _inMemoryConnectionStringTemplate = @"DataSource=test_database_{0}.db";
    private static string _inMemoryConnectionString = string.Empty;
    private const string _relativeTestSolutionFile = @"./DatabaseIntegrationTests/Design/test.solution.nox.yaml";
    private static string _absoluteTestSolutionFile = string.Empty;
    private readonly SqliteConnection _connection;

    protected TestDatabaseWebAppDbContext DbContext;

    protected SqliteTestBase()
    {
        // Save absolute path one time so during re-creation
        // path won't change
        _absoluteTestSolutionFile = Path.GetFullPath(_relativeTestSolutionFile);

        _inMemoryConnectionString = string.Format(_inMemoryConnectionStringTemplate, DateTime.UtcNow.Ticks);
        _connection = new SqliteConnection(_inMemoryConnectionString);
        _connection.Open();
        DbContext = CreateDbContext(_connection);
    }

    private static TestDatabaseWebAppDbContext CreateDbContext(SqliteConnection connection)
    {
        var databaseConfigurator = new SqliteDatabaseProvider();
        var solution = new NoxSolutionBuilder()
            .UseYamlFile(_absoluteTestSolutionFile)
            .Build();
        var options = new DbContextOptionsBuilder<TestDatabaseWebAppDbContext>()
            .UseSqlite(connection)
            .Options;
        var dbContext = new TestDatabaseWebAppDbContext(options, solution, databaseConfigurator);
        dbContext.Database.EnsureCreated();
        return dbContext;
    }

    internal void RecreateDbContext()
    {
        var previousDbContext = DbContext;
        DbContext = CreateDbContext(_connection);
        previousDbContext.Dispose();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        DbContext?.Dispose();
        _connection.Dispose();
    }
}