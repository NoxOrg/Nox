using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;
using Npgsql;

namespace Nox.EntityFramework.Postgres;

public class PostgresDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider 
{
    private string _connectionString = string.Empty;
    
    private readonly NoxDataStoreType _storeType;

    public NoxDataStoreType StoreType => _storeType;

    public PostgresDatabaseProvider(NoxDataStoreType storeType, IEnumerable<INoxTypeDatabaseConfigurator> configurators) : base(configurators, typeof(IPostgresNoxTypeDatabaseConfigurator))
    {
        _storeType = storeType;
    }

    public string ConnectionString
    {
        get => _connectionString;
        set => SetConnectionString(value);
    }

    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null)
    {
        var csb = new NpgsqlConnectionStringBuilder(dbServer.Options)
        {
            Host = dbServer.ServerUri,
            Port = dbServer.Port ?? 5432,
            Username = dbServer.User,
            Password = dbServer.Password,
            Database = dbServer.Name,
            ApplicationName = applicationName,
        };
        SetConnectionString(csb.ConnectionString);

        return optionsBuilder
            //.UseLazyLoadingProxies()
            .UseNpgsql(_connectionString, opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
    }

    public string ToTableNameForSql(string table, string schema)
    {
        throw new NotImplementedException();
    }

    public string ToTableNameForSqlRaw(string table, string schema)
    {
        throw new NotImplementedException();
    }

    private void SetConnectionString(string connectionString)
    {
        _connectionString = connectionString;
    }
}