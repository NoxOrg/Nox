using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Enums;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseProvider
{
    NoxDataStoreType StoreType { get; }
    string ConnectionString { get; }
    DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null);
    string ToTableNameForSql(string table, string schema);
    string ToTableNameForSqlRaw(string table, string schema);

    /// <summary>
    /// Raw SQL to Select Sequence Next Value
    /// </summary>
    string GetSqlStatementForSequenceNextValue(string sequenceName);
}