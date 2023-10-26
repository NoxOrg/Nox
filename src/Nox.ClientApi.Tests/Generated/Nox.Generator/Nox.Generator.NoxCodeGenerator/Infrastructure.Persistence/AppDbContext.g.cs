// Generated

#nullable enable

using System.Reflection;
using System.Diagnostics;
using System.Net;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MassTransit;

using Nox;
using Nox.Abstractions;
using Nox.Domain;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Solution;
using Nox.Configuration;
using Nox.Infrastructure;


using ClientApi.Domain;

namespace ClientApi.Infrastructure.Persistence;

internal partial class AppDbContext : Nox.Infrastructure.Persistence.EntityDbContextBase
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    private readonly NoxCodeGenConventions _codeGenConventions;

    public AppDbContext(
            DbContextOptions<AppDbContext> options,
            IPublisher publisher,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider,
            IUserProvider userProvider,
            ISystemProvider systemProvider,
            NoxCodeGenConventions codeGeneratorState
        ) : base(publisher, userProvider, systemProvider, options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
            _codeGenConventions = codeGeneratorState;
        }

    public DbSet<ClientApi.Domain.Country> Countries { get; set; } = null!;



    public DbSet<ClientApi.Domain.RatingProgram> RatingPrograms { get; set; } = null!;

    public DbSet<ClientApi.Domain.CountryQualityOfLifeIndex> CountryQualityOfLifeIndices { get; set; } = null!;

    public DbSet<ClientApi.Domain.Store> Stores { get; set; } = null!;

    public DbSet<ClientApi.Domain.Workplace> Workplaces { get; set; } = null!;

    public DbSet<ClientApi.Domain.StoreOwner> StoreOwners { get; set; } = null!;

    public DbSet<ClientApi.Domain.StoreLicense> StoreLicenses { get; set; } = null!;



    public DbSet<ClientApi.Domain.CountryContinent> CountriesContinents { get; set; } = null!;
    public DbSet<ClientApi.Domain.CountryContinentLocalized> CountriesContinentsLocalized { get; set; } = null!;
    public DbSet<ClientApi.Domain.StoreStatus> StoresStatuses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "ClientApi", _noxSolution.Infrastructure!.Persistence.DatabaseServer);
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
            Console.WriteLine($"AppDbContext Configure database for Entity {entity.Name}");

            // Ignore owned entities configuration as they are configured inside entity constructor
            if (entity.IsOwnedEntity)
            {
                continue;
            }

            var type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityTypeFullName(entity.Name));
            ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(modelBuilder, new EntityBuilderAdapter(modelBuilder.Entity(type!)), entity);

            if (entity.ShouldBeLocalized)
            {
                type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityTypeFullName(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name)));

                ((INoxDatabaseConfigurator)_dbProvider).ConfigureLocalizedEntity(new EntityBuilderAdapter(modelBuilder.Entity(type!)), entity);
            }
        }

        modelBuilder.ForEntitiesOfType<IEntityConcurrent>(
            builder => builder.Property(nameof(IEntityConcurrent.Etag)).IsConcurrencyToken());
            ConfigureEnumeration(modelBuilder.Entity("ClientApi.Domain.CountryContinent"));
            var enumLocalizedType = _clientAssemblyProvider.GetType("ClientApi.Domain.CountryContinentLocalized")!;
            var enumType = _clientAssemblyProvider.GetType("ClientApi.Domain.CountryContinent")!;
            ConfigureEnumerationLocalized(modelBuilder.Entity(enumLocalizedType), enumType, enumLocalizedType);
            ConfigureEnumeration(modelBuilder.Entity("ClientApi.Domain.StoreStatus"));
    }

    private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientApi.Domain.Country>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.Store>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.StoreOwner>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<ClientApi.Domain.StoreLicense>().HasQueryFilter(p => p.DeletedAtUtc == null);
    }
}