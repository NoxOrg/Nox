using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurators;
using Npgsql;

namespace Nox.DatabaseProvider.Postgres;

public class PostgresDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider 
{
    private string _connectionString = string.Empty;
    
    private static readonly Dictionary<NoxType, INoxTypeDatabaseConfigurator> TypesConfiguration =
        new()
        {
            { NoxType.Text, new PostgresTextDatabaseConfiguration() }, //Use Postgres Implementation
            { NoxType.Number, new NumberDatabaseConfigurator() }, // use default implementation
            { NoxType.Money, new MoneyDatabaseConfigurator() } // use default implementation
        };

    public PostgresDatabaseProvider(): base(TypesConfiguration)
    {
        
    }

    public string ConnectionString
    {
        get => _connectionString;
        set => SetConnectionString(value);
    }

    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
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

        return optionsBuilder.UseNpgsql(_connectionString, opts =>
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