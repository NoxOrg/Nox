using Nox.Infrastructure;
using Nox.Integration.Tests.DataProviders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestSqliteFixture : NoxTestDataContextFixtureBase
{
    protected override INoxDatabaseProvider GetDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState)
    {
        return new SqliteTestProvider(configurators, noxSolutionCodeGeneratorState);
    }
}