using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurators;

namespace Nox.DatabaseProvider.SqlServer;

public class SqlServerDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider 
{
    //We could use the container to manage this
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> TypesConfiguration =
        new()
        {
            { NoxType.Text, new SqlServerTextDatabaseConfigurator() }, //Use MySql Implementation
            { NoxType.Number, new NumberDatabaseConfigurator() }, // use default implementation
            { NoxType.Money, new MoneyDatabaseConfigurator() } // use default implementation
        };
    
    private string _connectionString = string.Empty;

    public string ConnectionString
    {
        get => _connectionString;
        set => SetConnectionString(value);
    }
    
    public SqlServerDatabaseProvider(): base(TypesConfiguration)
    {
        
    }

    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
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

        return optionsBuilder.UseSqlServer(_connectionString, opts =>
        {
            opts.MigrationsHistoryTable("MigrationsHistory", "migrations");
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