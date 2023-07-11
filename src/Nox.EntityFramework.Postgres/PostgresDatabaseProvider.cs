using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Npgsql;

namespace Nox.EntityFramework.Postgres;

public class PostgresDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider 
{
    private string _connectionString = string.Empty;
    
    public PostgresDatabaseProvider()
    {
        // Override Text Configurator
        TypesDatabaseConfigurations[NoxType.Text] = new PostgresTextDatabaseConfiguration();
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