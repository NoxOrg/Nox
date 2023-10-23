using Nox.Configuration;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Xunit.Abstractions;

namespace ClientApi.Tests
{
    public interface ITestDatabaseService
    {
        INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurations, NoxCodeGenConventions noxSolutionCodeGeneratorState, INoxClientAssemblyProvider noxClientAssemblyProvider);
        NoxTestApplicationFactory GetTestApplicationFactory(ITestOutputHelper testOutput, bool enableMessagingTests, string? environment = null);
    }
}
