using Nox;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Xunit.Abstractions;

namespace ClientApi.Tests
{
    public interface ITestDatabaseService
    {
        DatabaseServerProvider GetDatabaseServerProvider();
        INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurations, NoxCodeGenConventions noxSolutionCodeGeneratorState, INoxClientAssemblyProvider noxClientAssemblyProvider);
        NoxTestApplicationFactory GetTestApplicationFactory(ITestOutputHelper testOutput, bool enableMessagingTests, string? environment = null);
    }
}
