using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Nox.Infrastructure;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.Enums;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider
{
    public NoxDataStoreType StoreType { get; }

    public string ConnectionString { get; protected set; } = string.Empty;
    
    public SqlServerDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators, 
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider): this(NoxDataStoreType.EntityStore, configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider)
    {
        
    }
    
    public SqlServerDatabaseProvider(
        NoxDataStoreType storeType,
        IEnumerable<INoxTypeDatabaseConfigurator> configurators, 
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider): base(configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider, typeof(ISqlServerNoxTypeDatabaseConfigurator))
    {
        StoreType = storeType;
    }

    protected override IList<IndexBuilder> ConfigureUniqueAttributeConstraints(EntityTypeBuilder builder, Entity entity)
    {
        var result = base.ConfigureUniqueAttributeConstraints(builder, entity);

        foreach (var indexBuilder in result)
        {
            indexBuilder.HasFilter(null);
        }

        return result;
    }
       
    public virtual DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer, string? migrationsAssembly = null)
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
            //.UseLazyLoadingProxies()
            .UseSqlServer(ConnectionString,
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

    public string GetSqlStatementForSequenceNextValue(string sequenceName)
    {
       return $"SELECT NEXT VALUE FOR {sequenceName}"; 
    }
}