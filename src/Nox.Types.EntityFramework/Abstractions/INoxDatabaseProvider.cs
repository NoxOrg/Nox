using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseProvider
{
    NoxDataStoreTypeFlags StoreTypes { get; }
    string ConnectionString { get; }
    DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer);
    string ToTableNameForSql(string table, string schema);
    string ToTableNameForSqlRaw(string table, string schema);
    void SetStoreTypeFlag(NoxDataStoreTypeFlags storeType);
    void UnSetStoreTypeFlag(NoxDataStoreTypeFlags storeTypeFlag);

    /// <summary>
    /// Raw SQL to Select Sequence Next Value
    /// </summary>
    string GetSqlStatementForSequenceNextValue(string sequenceName);
}