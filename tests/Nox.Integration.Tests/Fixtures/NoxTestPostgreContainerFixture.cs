using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestPostgreContainerFixture : NoxTestContainerFixtureBase<PostgreSqlContainer>
{
    public NoxTestPostgreContainerFixture()
    {
        _container = new PostgreSqlBuilder()
          .WithImage("postgres:14.7")
          .WithDatabase("db")
          .WithUsername("postgres")
          .WithPassword("postgres")
          .WithAutoRemove(true)
          .WithCleanUp(true)
          .Build();
    }

    protected override DbContextOptions<TestWebAppDbContext> CreateDbOptions(string connectionString)
    {
        return new DbContextOptionsBuilder<TestWebAppDbContext>()
                .UseNpgsql(connectionString)
                .Options;
    }

    protected override string GetConnectionString(PostgreSqlContainer container)
        => container.GetConnectionString();
}
