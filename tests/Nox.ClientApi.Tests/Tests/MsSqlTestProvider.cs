using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.SqlServer;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace ClientApi.Tests;

public class MsSqlTestProvider : SqlServerDatabaseProvider
{
    public MsSqlTestProvider(
        string connectionString,
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState
        ) : base(configurators, noxSolutionCodeGeneratorState)
    {
        ConnectionString = connectionString;
    }

    public override DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
    {
        return optionsBuilder
            //.UseLazyLoadingProxies()
            .UseSqlServer(ConnectionString,
                opts =>
                {
                    opts.MigrationsHistoryTable("MigrationsHistory", "migrations");
                });
    }
}