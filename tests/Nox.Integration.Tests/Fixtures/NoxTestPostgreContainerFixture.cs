using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.Postgres;
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
        return new PostgresDatabaseProvider(configurators);
    }

    protected override DbContextOptions<TestWebAppDbContext> CreateDbOptions<TestWebAppDbContext>(string connectionString)
    {
        return new DbContextOptionsBuilder<TestWebAppDbContext>()
                .UseNpgsql(connectionString)
                .Options;
    }

    protected override string GetConnectionString(PostgreSqlContainer container)
        => container.GetConnectionString();
}