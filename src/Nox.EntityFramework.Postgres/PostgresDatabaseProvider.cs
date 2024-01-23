using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Npgsql;

namespace Nox.EntityFramework.Postgres;

public class PostgresDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider 
{
    public string ConnectionString { get; protected set; } = string.Empty;
    
    public PostgresDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators,
        NoxCodeGenConventions noxSolutionCodeGeneratorState
        ) : base(configurators, noxSolutionCodeGeneratorState, typeof(IPostgresNoxTypeDatabaseConfigurator))
    {
    }

    protected override IList<IndexBuilder> ConfigureUniqueAttributeConstraints(EntityTypeBuilder builder, Entity entity)
    {
        var result = base.ConfigureUniqueAttributeConstraints(builder, entity);
        foreach (var indexBuilder in result)
        {
            indexBuilder.AreNullsDistinct(false);
        }

        return result;
    }

    public virtual DbContextOptionsBuilder ConfigureDbContext(
        DbContextOptionsBuilder optionsBuilder,
        string applicationName,
        DatabaseServer dbServer,
        string? migrationAssemblyName = null)
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
        ConnectionString = csb.ConnectionString;

        return optionsBuilder
            //.UseLazyLoadingProxies()
            .UseNpgsql(ConnectionString, opts => { 
                opts.MigrationsHistoryTable("MigrationsHistory", "migrations");
                if (migrationAssemblyName is not null)
                {
                    opts.MigrationsAssembly(migrationAssemblyName);
                }
            });
    }


    public string GetSqlStatementForSequenceNextValue(string sequenceName)
    {
        return $"SELECT nextval('{sequenceName}')";
    }
}