using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.EntityFramework.SqlServer;

public class SqlServerDatabaseProvider: NoxDatabaseConfigurator, INoxDatabaseProvider
{
    public string ConnectionString { get; protected set; } = string.Empty;
    
    public SqlServerDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators, 
        NoxCodeGenConventions noxSolutionCodeGeneratorState):
        base(configurators, noxSolutionCodeGeneratorState, typeof(ISqlServerNoxTypeDatabaseConfigurator))
    {
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
       
    public virtual DbContextOptionsBuilder ConfigureDbContext(DbContextOptionsBuilder optionsBuilder, string applicationName, DatabaseServer dbServer)
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
                });
    }

    public string GetSqlStatementForSequenceNextValue(string sequenceName)
    {
       return $"SELECT NEXT VALUE FOR {sequenceName}"; 
    }
}