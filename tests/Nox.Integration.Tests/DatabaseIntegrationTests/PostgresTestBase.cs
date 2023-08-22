using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Nox.EntityFramework.Postgres;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

using Npgsql;

using System.Reflection;

using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

public abstract class PostgresTestBase : IDisposable
{
    // TODO: currently works in manually set up database in docker
    // include database setup into repository (mybae use localdb or express)
    private const string _databaseNameTemplate = @"test_database_{0}";
    private const string _databasePassword = @"Developer*123";
    private static string _inMemoryConnectionString = @"Host=localhost;Username=sa;Password=" + _databasePassword + ";";
    private static string _databaseName = string.Empty;
    private const string _solutionFileAsEmbeddedResourceName = @"Nox.Integration.Tests.DatabaseIntegrationTests.Design.test.solution.nox.yaml";
    private readonly NpgsqlConnection _connection;

    protected TestWebAppDbContext DbContext;

    protected PostgresTestBase()
    {
        _connection = new NpgsqlConnection(_inMemoryConnectionString);
        _connection.Open();

        _databaseName = string.Format(_databaseNameTemplate, DateTime.UtcNow.Ticks);
        var databaseCreation = $"CREATE DATABASE {_databaseName}";
        var createDatabaseCommand = new NpgsqlCommand(databaseCreation, _connection);
        createDatabaseCommand.ExecuteNonQuery();

        _connection.Close();
        _connection = new NpgsqlConnection(_inMemoryConnectionString + $"Database={_databaseName};");
        _connection.Open();

        DbContext = CreateDbContext(_connection);
    }

    private static TestWebAppDbContext CreateDbContext(NpgsqlConnection connection)
    {
        var solutionFileDictionary = new Dictionary<string, Func<TextReader>>
        {
            [_solutionFileAsEmbeddedResourceName] = () =>
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream(_solutionFileAsEmbeddedResourceName)!)
                using (StreamReader reader = new StreamReader(stream!))
                {
                    string result = reader.ReadToEnd();
                    return new StringReader(result);
                }
            }
        };

        var services = new ServiceCollection();
        // TODO  add ...BuilderExtension.cs generated class and call AddNox when Nox supports dynamic db providers
        // This will build dbcontext etc..
        services.AddNoxLib(Assembly.GetExecutingAssembly());
        using var serviceProvider = services.BuildServiceProvider();

        var databaseConfigurator = new PostgresDatabaseProvider(serviceProvider.GetServices<INoxTypeDatabaseConfigurator>());
        var solution = new NoxSolutionBuilder()
            .UseYamlFilesAndContent(solutionFileDictionary)
            .Build();

        var options = new DbContextOptionsBuilder<TestWebAppDbContext>()
            .UseNpgsql(connection)
            .Options;

        var dbContext = new TestWebAppDbContext(options, solution, databaseConfigurator, new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
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