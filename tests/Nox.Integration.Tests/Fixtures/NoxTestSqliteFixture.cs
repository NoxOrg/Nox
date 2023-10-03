using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.Sqlite;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Integration.Tests.Fixtures;

public class NoxTestSqliteFixture : NoxTestDataContextFixtureBase
{
    private const string _inMemoryConnectionString = $"DataSource=testdb;mode=memory;cache=shared";

    protected override DbContextOptions<TestWebAppDbContext> CreateDbOptions<TestWebAppDbContext>()
    {
        var keepAliveConnection = new SqliteConnection(_inMemoryConnectionString);

        //The database ceases to exist as soon as the database connection is closed.
        //Every :memory: database is distinct from every other.
        keepAliveConnection.Open();

        return new DbContextOptionsBuilder<TestWebAppDbContext>()
           .UseSqlite(keepAliveConnection)
           .Options;
    }

    protected override INoxDatabaseProvider GetDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators)
    {
        return new SqliteDatabaseProvider(configurators);
    }
}