using Microsoft.EntityFrameworkCore;
using Nox.Solution;

using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.EntityFramework.Sqlite;

public sealed class SqliteDatabaseProvider : NoxDatabaseConfigurator, INoxDatabaseProvider
{
    public string ConnectionString { get; } = string.Empty;

    public SqliteDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators) 
        : base(configurators, typeof(ISqliteNoxTypeDatabaseConfigurator))
    {

    }
    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
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
}