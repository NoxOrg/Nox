using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;

namespace Nox.DatabaseProvider.SqlServer;

public class SqlServerDatabaseProvider: INoxDatabaseProvider
{
    private string _connectionString = string.Empty;

    public string ConnectionString
    {
        get => _connectionString;
        set => SetConnectionString(value);
    }

    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
    {
        var csb = new SqlConnectionStringBuilder(dbServer.Options)
        {
            DataSource = $"{dbServer.ServerUri},{dbServer.Port}",
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