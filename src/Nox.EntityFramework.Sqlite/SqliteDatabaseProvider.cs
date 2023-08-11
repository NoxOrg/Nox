using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;

using Nox.Types.EntityFramework.Abstractions;

namespace Nox.EntityFramework.Sqlite;

public sealed class SqliteDatabaseProvider : NoxDatabaseConfigurator, INoxDatabaseProvider
{

    public string ConnectionString { get; set; } = string.Empty;

    public SqliteDatabaseProvider(IEnumerable<INoxTypeDatabaseConfigurator> configurators) 
        : base(configurators, typeof(ISqliteNoxTypeDatabaseConfigurator))
    {

    }
    
    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null)
    {
        var csb = new SqliteConnectionStringBuilder(dbServer.Options)
        {
            DataSource = dbServer.ServerUri,
            Password = dbServer.Password,
            
        };
        ConnectionString = csb.ConnectionString;

        return optionsBuilder
            .UseSqlite(csb.ConnectionString, dbOpt =>
            {
                if (!string.IsNullOrWhiteSpace(migrationsAssembly))
                {
                    dbOpt.MigrationsAssembly(migrationsAssembly);
                }
            });
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