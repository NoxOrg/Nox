using Humanizer.Configuration;
using Microsoft.EntityFrameworkCore;
using Nox.Infrastructure;
using Nox.Solution;

using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.Enums;

namespace Nox.EntityFramework.Sqlite;

public class SqliteDatabaseProvider : NoxDatabaseConfigurator, INoxDatabaseProvider
{
    public string ConnectionString { get; protected set; } = string.Empty;
    public NoxDataStoreType StoreType { get; }

    public SqliteDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider
    ) : this(NoxDataStoreType.EntityStore, configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider)
    {
    }
    
    public SqliteDatabaseProvider(
        NoxDataStoreType storeType,
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider, typeof(ISqliteNoxTypeDatabaseConfigurator))
    {
        StoreType = storeType;
    }

    public virtual DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null)
    {
        return optionsBuilder
            .UseSqlite(dbServer.Options,
                opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
    }

    public string ToTableNameForSql(string table, string schema)
    {
        throw new NotImplementedException();
    }

    public string ToTableNameForSqlRaw(string table, string schema)
    {
        throw new NotImplementedException();
    }

    public string GetSqlStatementForSequenceNextValue(string sequenceName)
    {
        throw new NotSupportedException();
    }
}