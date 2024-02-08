using Nox;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Xunit.Abstractions;

namespace ClientApi.Tests
{
    public interface ITestDatabaseService
    {
        string ConnectionString { get; }

        DatabaseServerProvider GetDatabaseServerProvider();
        INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurations, NoxCodeGenConventions noxSolutionCodeGeneratorState, INoxClientAssemblyProvider noxClientAssemblyProvider);
        NoxAppClient GetNoxClient(ITestOutputHelper testOutput, bool enableMessagingTests, string? environment = null);
    }
}
