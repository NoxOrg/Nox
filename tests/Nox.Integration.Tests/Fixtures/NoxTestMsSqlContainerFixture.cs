using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestMsSqlContainerFixture : NoxTestContainerFixtureBase<MsSqlContainer>
{
    public NoxTestMsSqlContainerFixture()
    {
        _container = new MsSqlBuilder()
            .WithAutoRemove(true)
            .WithCleanUp(true)
            .Build();
    }

    protected override DbContextOptions<TestWebAppDbContext> CreateDbOptions(string connectionString)
    {
        return new DbContextOptionsBuilder<TestWebAppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
    }

    protected override string GetConnectionString(MsSqlContainer container)
        => container.GetConnectionString();
}
