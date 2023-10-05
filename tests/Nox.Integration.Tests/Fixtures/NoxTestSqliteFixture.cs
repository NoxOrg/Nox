using Nox.Integration.Tests.DataProviders;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestSqliteFixture : NoxTestDataContextFixtureBase
{
    protected override INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators)
    {
        return new SqliteTestProvider(configurators);
    }
}