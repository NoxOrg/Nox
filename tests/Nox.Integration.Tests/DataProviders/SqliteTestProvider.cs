using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.Sqlite;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Integration.Tests.DataProviders;

internal class SqliteTestProvider : SqliteDatabaseProvider
{
    private const string InMemoryConnectionString = $"DataSource=testdb;mode=memory;cache=shared";

    public SqliteTestProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider) : base(configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider)
    {
        ConnectionString = InMemoryConnectionString;
    }

    public override DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null)
    {
        var keepAliveConnection = new SqliteConnection(InMemoryConnectionString);

        //The database ceases to exist as soon as the database connection is closed.
        //Every :memory: database is distinct from every other.
        keepAliveConnection.Open();

        return optionsBuilder
           .UseSqlite(keepAliveConnection,
               opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
    }
}