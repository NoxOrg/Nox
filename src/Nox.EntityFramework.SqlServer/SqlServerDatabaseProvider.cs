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
    public NoxDataStoreTypeFlags StoreTypes { get; private set; }

    public string ConnectionString { get; protected set; } = string.Empty;
    
    public SqlServerDatabaseProvider(
        IEnumerable<INoxTypeDatabaseConfigurator> configurators, 
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        INoxClientAssemblyProvider clientAssemblyProvider): base(configurators, noxSolutionCodeGeneratorState, clientAssemblyProvider, typeof(ISqlServerNoxTypeDatabaseConfigurator))
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
    
    protected override void ConfigureAutoNumberAttributeSequences(ModelBuilder modelBuilder, Entity entity)
    {
        if (entity.Attributes is not { Count: > 0 }) return;
        foreach (var property in entity.Attributes.Where(e=>e.Type == NoxType.AutoNumber))
        {
            var typeOptions = property.AutoNumberTypeOptions ?? new AutoNumberTypeOptions();
                
            var seqName = $"Seq{entity.Name}{property.Name}";
                
            modelBuilder.HasSequence<long>(seqName)
                .StartsAt(typeOptions.StartsAt)
                .IncrementsBy(typeOptions.IncrementsBy);
        }
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
                opts => { opts.MigrationsHistoryTable("MigrationsHistory", "migrations"); });
    }

    public string ToTableNameForSql(string table, string schema)
    {
        throw new NotImplementedException();
    }

    public string ToTableNameForSqlRaw(string table, string schema)
    {
        throw new NotImplementedException();
    }

    public void SetStoreTypeFlag(NoxDataStoreTypeFlags storeType)
    {
        StoreTypes |= storeType;
    }

    public void UnSetStoreTypeFlag(NoxDataStoreTypeFlags storeTypeFlag)
    {
        StoreTypes &= storeTypeFlag;
    }
}