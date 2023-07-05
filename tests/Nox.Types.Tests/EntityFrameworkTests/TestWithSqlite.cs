using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Nox.Types.Tests.EntityFrameworkTests;

public abstract class TestWithSqlite : IDisposable
{
    private const string InMemoryConnectionString = "DataSource=:memory:";
    //private const string InMemoryConnectionString = @"DataSource=test.db";
    private readonly SqliteConnection _connection;

    protected SampleDbContext DbContext;

    protected TestWithSqlite()
    {
        _connection = new SqliteConnection(InMemoryConnectionString);
        _connection.Open();
        DbContext = CreateDbContext(_connection);
    }

    private static SampleDbContext CreateDbContext(SqliteConnection connection)
    {
        var options = new DbContextOptionsBuilder<SampleDbContext>()
            .UseSqlite(connection)
            .Options;
        var dbContext = new SampleDbContext(options);
        dbContext.Database.EnsureCreated();
        return dbContext;
    }

    internal void RecreateDbContext()
    {
        var previousDbContext = DbContext;
        DbContext = CreateDbContext(_connection);
        previousDbContext.Dispose();
    }

    public void Dispose()
    {
        DbContext?.Dispose();
        _connection.Dispose();
    }
}