using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.Application.Providers;
using Nox.Configuration;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public abstract class NoxTestDataContextFixtureBase : INoxTestDataContextFixture
{
    private const string _solutionSetupFileName = @"Nox.Integration.Tests.DatabaseIntegrationTests.Design.test.solution.nox.yaml";
    private readonly IServiceProvider _serviceProvider;
    protected TestWebAppDbContext _dbContext = default!;

    protected NoxTestDataContextFixtureBase()
    {
        var services = new ServiceCollection();
        services.AddNoxLib(configure => configure.WithClientAssembly(Assembly.GetExecutingAssembly()));

        _serviceProvider = services.BuildServiceProvider();
    }

    public TestWebAppDbContext DataContext
    {
        get
        {
            if (_dbContext == null)
            {
                RefreshDbContext();
            }
            return _dbContext!;
        }
    }

    public void RefreshDbContext()
    {
        var solutionFileSetup = GetSolutionSetup();
        var solution = new NoxSolutionBuilder()
                        .UseYamlFilesAndContent(solutionFileSetup)
                        .Build();

        var assemblyProvider = new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly());
        var databaseProvider = GetDatabaseProvider(_serviceProvider.GetServices<INoxTypeDatabaseConfigurator>());

        var options = CreateDbOptions();

        _dbContext = new TestWebAppDbContext(
                options,
                solution,
                databaseProvider,
                assemblyProvider,
                new DefaultUserProvider(),
                new DefaultSystemProvider());
    }

    protected abstract INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators);

    protected abstract DbContextOptions<TestWebAppDbContext> CreateDbOptions();

    private static Dictionary<string, Func<TextReader>> GetSolutionSetup()
    {
        return new Dictionary<string, Func<TextReader>>
        {
            [_solutionSetupFileName] = () =>
            {
                var assembly = Assembly.GetExecutingAssembly();
                using Stream stream = assembly.GetManifestResourceStream(_solutionSetupFileName)!;
                using StreamReader reader = new(stream!);
                string result = reader.ReadToEnd();
                return new StringReader(result);
            }
        };
    }
}