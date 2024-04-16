using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Solution;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerIntegrationDatabaseProvider: INoxIntegrationDatabaseProvider
{
    public string ConnectionString { get; protected set; } = string.Empty;

    
    public DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string migrationsAssembly)
    {
        var csb = new SqlConnectionStringBuilder(dbServer.Options)
        {
            DataSource = $"{dbServer.ServerUri},{dbServer.Port ?? 1433}",
            UserID = dbServer.User,
            Password = dbServer.Password,
            InitialCatalog = dbServer.Name,
            ApplicationName = applicationName
        };
        ConnectionString = csb.ConnectionString;

        return optionsBuilder
            .UseSqlServer(ConnectionString,
                opts =>
                {
                    opts.MigrationsHistoryTable("MigrationsHistory", "migrations");
                    opts.MigrationsAssembly(migrationsAssembly);
                });
    }
}