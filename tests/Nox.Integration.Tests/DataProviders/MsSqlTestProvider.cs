using Microsoft.EntityFrameworkCore;
using Nox.EntityFramework.SqlServer;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Integration.Tests.DataProviders;

internal class MsSqlTestProvider : SqlServerDatabaseProvider
{
    public MsSqlTestProvider(
        string connectionString,
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(NoxDataStoreTypeFlags.EntityStore, configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider)
    {
        ConnectionString = connectionString;
    }

    public override DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null)
    {
        return optionsBuilder
            .UseSqlServer(ConnectionString,
             opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
    }
}