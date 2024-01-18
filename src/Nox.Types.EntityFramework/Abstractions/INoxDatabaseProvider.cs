using Microsoft.EntityFrameworkCore;
using Nox.Solution;

namespace Nox.Types.EntityFramework.Abstractions;

public interface INoxDatabaseProvider
{
    string ConnectionString { get; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    /// <param name="applicationName"></param>
    /// <param name="dbServer"></param>
    /// <param name="migrationAssemblyName">If using migrations , set the assembyname if the DbContext is in other assembly </param>
    /// <returns></returns>
    DbContextOptionsBuilder ConfigureDbContext(
        DbContextOptionsBuilder optionsBuilder,
        string applicationName,
        DatabaseServer dbServer,
        string? migrationAssemblyName = null);

    /// <summary>
    /// Raw SQL to Select Sequence Next Value
    /// </summary>
    string GetSqlStatementForSequenceNextValue(string sequenceName);
}