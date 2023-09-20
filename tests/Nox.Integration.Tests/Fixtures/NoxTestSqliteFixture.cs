using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.Sqlite;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestSqliteFixture : INoxTestContainer
{
    private const string _inMemoryConnectionString = "DataSource=:memory:";

    public DbContextOptions<TestWebAppDbContext> CreateDbOptions()
    {
        return new DbContextOptionsBuilder<TestWebAppDbContext>()
           .UseSqlite(_inMemoryConnectionString)
           .Options;
    }

    public INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators)
    {
        return new SqliteDatabaseProvider(configurators);
    }
}