// Generated

#nullable enable

using System.Reflection;
using System.Diagnostics;
using System.Net;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

using Nox;
using Nox.Abstractions;
using Nox.Domain;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Solution;
using Nox.Infrastructure;

using DomainNameSpace = CryptocashIntegration.Domain;
using CryptocashIntegration.Domain;

namespace CryptocashIntegration.Infrastructure.Persistence;

public partial class AppDbContext: AppDbContextBase
{
    public AppDbContext(
           DbContextOptions<AppDbContext> options,
           IPublisher publisher,
           NoxSolution noxSolution,
           INoxDatabaseProvider databaseProvider,
           INoxClientAssemblyProvider clientAssemblyProvider,
           IUserProvider userProvider,
           ISystemProvider systemProvider,
           NoxCodeGenConventions codeGenConventions,
           ILogger<AppDbContext> logger
       ) : base(
           options,
           publisher,
           noxSolution,
           databaseProvider,
           clientAssemblyProvider,
           userProvider,
           systemProvider,
           codeGenConventions,
           logger)
    {}
}

public abstract partial class AppDbContextBase : Nox.Infrastructure.Persistence.EntityDbContextBase, Nox.Domain.IRepository
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    private readonly NoxCodeGenConventions _codeGenConventions;

    public AppDbContextBase(
            DbContextOptions<AppDbContext> options,
            IPublisher publisher,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider,
            IUserProvider userProvider,
            ISystemProvider systemProvider,
            NoxCodeGenConventions codeGenConventions,
            ILogger<AppDbContext> logger
        ) : base(publisher, userProvider, systemProvider, databaseProvider, logger, options)
    {
        _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
            _codeGenConventions = codeGenConventions;
        }
    
    public virtual DbSet<CryptocashIntegration.Domain.CountryQueryToTable> CountryQueryToTables { get; set; } = null!;
    public virtual DbSet<CryptocashIntegration.Domain.CountryJsonToTable> CountryJsonToTables { get; set; } = null!;
    public virtual DbSet<CryptocashIntegration.Domain.CountryProcToTable> CountryProcToTables { get; set; } = null!;
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(
                optionsBuilder,
                "CryptocashIntegration",
                _noxSolution.Infrastructure!.Persistence.DatabaseServer,
                _clientAssemblyProvider.ClientAssembly.GetName().Name);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureAuditable(modelBuilder);
        foreach (var entity in _noxSolution.Domain!.Entities)
        {
#if DEBUG
            Console.WriteLine($"AppDbContext Configure database for Entity {entity.Name}");
#endif
            ConfigureEnumeratedAttributes(modelBuilder, entity);

            var type = _clientAssemblyProvider.GetEntityType(_codeGenConventions.GetEntityTypeFullName(entity.Name));
            ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(modelBuilder, modelBuilder.Entity(type!).ToTable(entity.Persistence.TableName), entity, _clientAssemblyProvider.DomainAssembly);

            if (entity.IsLocalized)
            {
                type = _clientAssemblyProvider.GetEntityType(_codeGenConventions.GetEntityTypeFullName(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name)));

                ((INoxDatabaseConfigurator)_dbProvider).ConfigureLocalizedEntity(modelBuilder, modelBuilder.Entity(type!), entity);
            }
        }

        modelBuilder.ForEntitiesOfType<IEtag>(
            builder => builder.Property(nameof(IEtag.Etag)).IsConcurrencyToken());
    }
    
    private void ConfigureEnumeratedAttributes(ModelBuilder modelBuilder, Entity entity)
    {
        foreach(var enumAttribute in entity.Attributes.Where(attribute => attribute.Type == NoxType.Enumeration))
            {
                ConfigureEnumeration(modelBuilder.Entity($"CryptocashIntegration.Domain.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}"), enumAttribute.EnumerationTypeOptions!);
                if (enumAttribute.EnumerationTypeOptions!.IsLocalized)
                {
                    var enumLocalizedType = _clientAssemblyProvider.GetEntityType($"CryptocashIntegration.Domain.{_codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, enumAttribute.Name)}")!;
                    var enumType = _clientAssemblyProvider.GetEntityType($"CryptocashIntegration.Domain.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}")!;
                    ConfigureEnumerationLocalized(modelBuilder.Entity(enumLocalizedType), enumType, enumLocalizedType, enumAttribute.EnumerationTypeOptions!, _noxSolution.Application!.Localization!.DefaultCulture);
                }
            }
    }

    private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
    }
}