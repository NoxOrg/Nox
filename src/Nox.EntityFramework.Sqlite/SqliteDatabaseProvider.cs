using Microsoft.EntityFrameworkCore;
using Nox.Solution;

using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.Enums;

namespace Nox.EntityFramework.Sqlite;

public class SqliteDatabaseProvider : NoxDatabaseConfigurator, INoxDatabaseProvider
{
    public string ConnectionString { get; protected set; } = string.Empty;
    public NoxDataStoreTypeFlags StoreTypes { get; private set; }

    public SqliteDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators)
        : base(configurators, typeof(ISqliteNoxTypeDatabaseConfigurator))
    {
    }

    public virtual DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
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

    public void SetStoreTypeFlag(NoxDataStoreTypeFlags storeType)
    {
        StoreTypes |= storeType;
    }

    public void UnSetStoreTypeFlag(NoxDataStoreTypeFlags storeTypeFlag)
    {
        StoreTypes &= storeTypeFlag;
    }
}