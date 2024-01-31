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
using MassTransit;

using Nox;
using Nox.Abstractions;
using Nox.Domain;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Solution;
using Nox.Configuration;
using Nox.Infrastructure;

using DomainNameSpace = ClientApi.Domain;
using ClientApi.Domain;

namespace ClientApi.Infrastructure.Persistence;

internal partial class AppDbContext: AppDbContextBase
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

internal abstract partial class AppDbContextBase : Nox.Infrastructure.Persistence.EntityDbContextBase, Nox.Domain.IRepository
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
    
    public virtual DbSet<ClientApi.Domain.Country> Countries { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.RatingProgram> RatingPrograms { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.CountryQualityOfLifeIndex> CountryQualityOfLifeIndices { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.Store> Stores { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.Workplace> Workplaces { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.StoreOwner> StoreOwners { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.StoreLicense> StoreLicenses { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.Currency> Currencies { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.Tenant> Tenants { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.Client> Clients { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.ReferenceNumberEntity> ReferenceNumberEntities { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.Person> People { get; set; } = null!;
    public virtual DbSet<ClientApi.Domain.WorkplaceLocalized> WorkplacesLocalized { get; set; } = null!;public virtual DbSet<ClientApi.Domain.TenantBrandLocalized> TenantBrandsLocalized { get; set; } = null!;public virtual DbSet<ClientApi.Domain.TenantContactLocalized> TenantContactsLocalized { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.CountryContinent> CountriesContinents { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.CountryContinentLocalized> CountriesContinentsLocalized { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.StoreStatus> StoresStatuses { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.WorkplaceOwnership> WorkplacesOwnerships { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.WorkplaceOwnershipLocalized> WorkplacesOwnershipsLocalized { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.WorkplaceType> WorkplacesTypes { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.TenantStatus> TenantsStatuses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(
                optionsBuilder,
                "ClientApi",
                _noxSolution.Infrastructure!.Persistence.DatabaseServer,
                _clientAssemblyProvider.ClientAssembly.GetName().Name);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureAuditable(modelBuilder);
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
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
                ConfigureEnumeration(modelBuilder.Entity($"ClientApi.Domain.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}"), enumAttribute.EnumerationTypeOptions!);
                if (enumAttribute.EnumerationTypeOptions!.IsLocalized)
                {
                    var enumLocalizedType = _clientAssemblyProvider.GetEntityType($"ClientApi.Domain.{_codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, enumAttribute.Name)}")!;
                    var enumType = _clientAssemblyProvider.GetEntityType($"ClientApi.Domain.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}")!;
                    ConfigureEnumerationLocalized(modelBuilder.Entity(enumLocalizedType), enumType, enumLocalizedType, enumAttribute.EnumerationTypeOptions!, _noxSolution.Application!.Localization!.DefaultCulture);
                }
            }
    }

    private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientApi.Domain.Country>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.Store>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.Workplace>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.StoreOwner>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.StoreLicense>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.Currency>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.Client>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.ReferenceNumberEntity>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.Person>().HasQueryFilter(p => p.DeletedAtUtc == null);
    }
}