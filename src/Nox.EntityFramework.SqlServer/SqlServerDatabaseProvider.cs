using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider 
{
    private string _connectionString = string.Empty;

    private readonly NoxDataStoreType _storeType;

    public NoxDataStoreType StoreType => _storeType;

    public string ConnectionString
    {
        get => _connectionString;
        set => SetConnectionString(value);
    }
    
    public SqlServerDatabaseProvider(NoxDataStoreType storeType, IEnumerable<INoxTypeDatabaseConfigurator> configurators): base(configurators, typeof(ISqlServerNoxTypeDatabaseConfigurator))
    {
        _storeType = storeType;
    }
    

    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null)
    {
        var csb = new SqlConnectionStringBuilder(dbServer.Options)
        {
            DataSource = $"{dbServer.ServerUri},{dbServer.Port ?? 1433}",
            UserID = dbServer.User,
            Password = dbServer.Password,
            InitialCatalog = dbServer.Name,
            ApplicationName = applicationName
        };
        SetConnectionString(csb.ConnectionString);

        return optionsBuilder
            //.UseLazyLoadingProxies()
            .UseSqlServer(_connectionString,
                opts =>
                {
                    opts.MigrationsHistoryTable("MigrationsHistory", "migrations");
                    if (!string.IsNullOrWhiteSpace(migrationsAssembly))
                    {
                        opts.MigrationsAssembly(migrationsAssembly);
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

    private void SetConnectionString(string connectionString)
    {
        _connectionString = connectionString;
    }
}