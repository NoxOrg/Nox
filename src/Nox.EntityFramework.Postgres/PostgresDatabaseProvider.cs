using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Types.EntityFramework.Enums;
using Npgsql;

namespace Nox.EntityFramework.Postgres;

public class PostgresDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider 
{
    public string ConnectionString { get; protected set; } = string.Empty;
    public NoxDataStoreType StoreType { get; }
    
    public PostgresDatabaseProvider(NoxDataStoreType storeType, IEnumerable<INoxTypeDatabaseConfigurator> configurators) : base(configurators, typeof(IPostgresNoxTypeDatabaseConfigurator))
    {
        StoreType = storeType;
    }

    protected override IList<IndexBuilder> ConfigureUniqueAttributeConstraints(IEntityBuilder builder, Entity entity)
    {
        var result = base.ConfigureUniqueAttributeConstraints(builder, entity);
        foreach (var indexBuilder in result)
        {
            indexBuilder.AreNullsDistinct(false);
        }

        return result;
    }

    public virtual DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
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
            .UseNpgsql(ConnectionString, opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
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