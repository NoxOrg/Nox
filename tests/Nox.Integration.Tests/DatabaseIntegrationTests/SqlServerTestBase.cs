using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Application.Providers;
using Nox.EntityFramework.SqlServer;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using System.Reflection;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.DatabaseIntegrationTests;

public abstract class SqlServerTestBase : IDisposable
{
    // TODO: currently works in manually set up database in docker
    // include database setup into repository (mybae use localdb or express)
    private const string _databaseNameTemplate = @"test_database_{0}";
    private const string _databasePassword = @"Developer*123";
    private static string _inMemoryConnectionString = @"Server=localhost;User Id=SA;Password=" + _databasePassword + ";TrustServerCertificate=True;";
    private static string _databaseName = string.Empty;
    private const string _solutionFileAsEmbeddedResourceName = @"Nox.Integration.Tests.DatabaseIntegrationTests.Design.test.solution.nox.yaml";
    private readonly SqlConnection _connection;

    protected TestWebAppDbContext DbContext;

    protected SqlServerTestBase()
    {
        _connection = new SqlConnection(_inMemoryConnectionString);
        _connection.Open();

        _databaseName = string.Format(_databaseNameTemplate, DateTime.UtcNow.Ticks);
        var databaseCreation = $"CREATE DATABASE {_databaseName}";
        var createDatabaseCommand = new SqlCommand(databaseCreation, _connection);
        createDatabaseCommand.ExecuteNonQuery();

        _connection.Close();
        _connection = new SqlConnection(_inMemoryConnectionString + $"Database={_databaseName};");
        _connection.Open();

        DbContext = CreateDbContext(_connection);
    }

    private static TestWebAppDbContext CreateDbContext(SqlConnection connection)
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

        var databaseConfigurator = new SqlServerDatabaseProvider(serviceProvider.GetServices<INoxTypeDatabaseConfigurator>());
        var solution = new NoxSolutionBuilder()
            .UseYamlFilesAndContent(solutionFileDictionary)
            .Build();

        var options = new DbContextOptionsBuilder<TestWebAppDbContext>()
            .UseSqlServer(connection)
            .Options;

        var dbContext = new TestWebAppDbContext(
            options,
            solution,
            databaseConfigurator,
            new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()),
            new DefaultUserProvider(),
            new DefaultSystemProvider());

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