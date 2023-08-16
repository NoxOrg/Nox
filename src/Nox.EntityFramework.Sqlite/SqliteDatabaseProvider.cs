using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.EntityFramework.Sqlite;

public sealed class SqliteDatabaseProvider : NoxDatabaseConfigurator, INoxDatabaseProvider
{
    public string ConnectionString { get; set; } = string.Empty;
    
    private readonly NoxDataStoreType _storeType;

    public NoxDataStoreType StoreType => _storeType;

    public SqliteDatabaseProvider(NoxDataStoreType storeType, IEnumerable<INoxTypeDatabaseConfigurator> configurators) 
        : base(configurators, typeof(ISqliteNoxTypeDatabaseConfigurator))
    {
        _storeType = storeType;
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