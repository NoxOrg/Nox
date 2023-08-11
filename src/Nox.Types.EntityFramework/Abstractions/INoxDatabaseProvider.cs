using Microsoft.EntityFrameworkCore;
using Nox.Solution;

namespace Nox.Types.EntityFramework.Abstractions
{
    public interface INoxDatabaseProvider
    {
        string ConnectionString { get; set; }
        DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null);
        string ToTableNameForSql(string table, string schema);
        string ToTableNameForSqlRaw(string table, string schema);
    }
}