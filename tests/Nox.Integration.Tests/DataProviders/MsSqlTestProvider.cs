using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.SqlServer;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Integration.Tests.DataProviders;

internal class MsSqlTestProvider : SqlServerDatabaseProvider
{
    public MsSqlTestProvider(string connectionString, IEnumerable<INoxTypeDatabaseConfigurator> configurators) : base(configurators)
    {
        ConnectionString = connectionString;
    }

    public override DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
    {
        return optionsBuilder
            .UseSqlServer(ConnectionString,
             opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
    }
}