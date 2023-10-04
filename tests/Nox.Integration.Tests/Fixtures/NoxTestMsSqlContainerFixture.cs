using Nox.Integration.Tests.DataProviders;
using Nox.Types.EntityFramework.Abstractions;
using Testcontainers.MsSql;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestMsSqlContainerFixture : NoxTestContainerFixtureBase<MsSqlContainer>
{
    private const string MasterDbName = "master";

    public NoxTestMsSqlContainerFixture()
    {
        _container = new MsSqlBuilder()
            .WithAutoRemove(true)
            .WithCleanUp(true)
            .Build();
    }

    protected override INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators)
    {
        return new MsSqlTestProvider(GetConnectionString(), configurators);
    }

    private string GetConnectionString()
    {
        var connectionString = _container.GetConnectionString();
        if (connectionString.Contains(MasterDbName))
        {
            return connectionString.Replace(MasterDbName, nameof(TestWebAppDbContext));
        }

        return connectionString;
    }
}