using Nox.Integration.Tests.DataProviders;
using Nox.Types.EntityFramework.Abstractions;
using Testcontainers.PostgreSql;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestPostgreContainerFixture : NoxTestContainerFixtureBase<PostgreSqlContainer>
{
    public NoxTestPostgreContainerFixture()
    {
        _container = new PostgreSqlBuilder()
          .WithImage("postgres:15.4")
          .WithDatabase("db")
          .WithUsername("postgres")
          .WithPassword("postgres")
          .WithAutoRemove(true)
          .WithCleanUp(true)
          .Build();
    }

    protected override INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators)
    {
        return new PostgreSqlTestProvider(_container.GetConnectionString(), configurators);
    }
}