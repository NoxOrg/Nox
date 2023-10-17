using Nox.Types.EntityFramework.Abstractions;
using Xunit.Abstractions;

namespace ClientApi.Tests
{
    public interface ITestDatabaseService
    {
        INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurations);
        NoxTestApplicationFactory GetTestApplicationFactory(ITestOutputHelper testOutput, bool enableMessagingTests, string? environment = null);
    }
}
