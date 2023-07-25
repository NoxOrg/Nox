using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nox.EntityFramework.SqlServer;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Tests.Fixtures
{
    public class DataContextTestFixture
    {
        private const string TestSolutionFile = @"./DatabaseIntegrationTests/Design/test.solution.nox.yaml";

        public DataContextTestFixture()
        {
            ServiceCollection services = new();
            services.AddNoxLib(Assembly.GetExecutingAssembly()!);

            using var serviceProvider = services.BuildServiceProvider();

            var databaseConfigurator = new SqlServerDatabaseProvider(serviceProvider.GetServices<INoxTypeDatabaseConfigurator>());
            var solution = new NoxSolutionBuilder()
                .UseYamlFile(TestSolutionFile)
                .Build();

            var options = new DbContextOptionsBuilder<TestWebAppDbContext>()
                .UseInMemoryDatabase("Nox")
                .Options;

            DbContext = new TestWebAppDbContext(options, solution, databaseConfigurator, Assembly.GetExecutingAssembly());
        }

        public TestWebAppDbContext DbContext { get; }
    }
}