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

using DomainNameSpace = TestWebApp.Domain;
using TestWebApp.Domain;

namespace TestWebApp.Infrastructure.Persistence;

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
    
    public virtual DbSet<TestWebApp.Domain.TestEntityZeroOrOne> TestEntityZeroOrOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.SecondTestEntityZeroOrOne> SecondTestEntityZeroOrOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityWithNuid> TestEntityWithNuids { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityOneOrMany> TestEntityOneOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.SecondTestEntityOneOrMany> SecondTestEntityOneOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityZeroOrMany> TestEntityZeroOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.SecondTestEntityZeroOrMany> SecondTestEntityZeroOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.ThirdTestEntityZeroOrMany> ThirdTestEntityZeroOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.ThirdTestEntityExactlyOne> ThirdTestEntityExactlyOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.ThirdTestEntityZeroOrOne> ThirdTestEntityZeroOrOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityExactlyOne> TestEntityExactlyOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.SecondTestEntityExactlyOne> SecondTestEntityExactlyOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne> TestEntityZeroOrManyToZeroOrOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne> TestEntityOneOrManyToExactlyOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany> TestEntityExactlyOneToZeroOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne> TestEntityZeroOrManyToExactlyOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany> TestEntityOneOrManyToZeroOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany> TestEntityZeroOrManyToOneOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany> TestEntityZeroOrOneToOneOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne> TestEntityOneOrManyToZeroOrOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne> TestEntityZeroOrOneToExactlyOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne> TestEntityExactlyOneToZeroOrOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne> TestEntityOwnedRelationshipExactlyOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne> TestEntityOwnedRelationshipZeroOrOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany> TestEntityOwnedRelationshipOneOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany> TestEntityOwnedRelationshipZeroOrManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne> TestEntityTwoRelationshipsOneToOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne> SecondTestEntityTwoRelationshipsOneToOnes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany> TestEntityTwoRelationshipsManyToManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany> SecondTestEntityTwoRelationshipsManyToManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany> TestEntityTwoRelationshipsOneToManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany> SecondTestEntityTwoRelationshipsOneToManies { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityForTypes> TestEntityForTypes { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityForUniqueConstraints> TestEntityForUniqueConstraints { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey> EntityUniqueConstraintsWithForeignKeys { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey> EntityUniqueConstraintsRelatedForeignKeys { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityLocalization> TestEntityLocalizations { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityForAutoNumberUsages> TestEntityForAutoNumberUsages { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.ForReferenceNumber> ForReferenceNumbers { get; set; } = null!;
    public virtual DbSet<TestWebApp.Domain.TestEntityLocalizationLocalized> TestEntityLocalizationsLocalized { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.TestEntityForTypesEnumerationTestField> TestEntityForTypesEnumerationTestFields { get; set; } = null!;
    public virtual DbSet<DomainNameSpace.TestEntityForTypesEnumerationTestFieldLocalized> TestEntityForTypesEnumerationTestFieldsLocalized { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(
                optionsBuilder,
                "TestWebApp",
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
                ConfigureEnumeration(modelBuilder.Entity($"TestWebApp.Domain.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}"), enumAttribute.EnumerationTypeOptions!);
                if (enumAttribute.EnumerationTypeOptions!.IsLocalized)
                {
                    var enumLocalizedType = _clientAssemblyProvider.GetEntityType($"TestWebApp.Domain.{_codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, enumAttribute.Name)}")!;
                    var enumType = _clientAssemblyProvider.GetEntityType($"TestWebApp.Domain.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}")!;
                    ConfigureEnumerationLocalized(modelBuilder.Entity(enumLocalizedType), enumType, enumLocalizedType, enumAttribute.EnumerationTypeOptions!, _noxSolution.Application!.Localization!.DefaultCulture);
                }
            }
    }

    private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestWebApp.Domain.TestEntityZeroOrOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.SecondTestEntityZeroOrOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityWithNuid>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityOneOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.SecondTestEntityOneOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityZeroOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.SecondTestEntityZeroOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.ThirdTestEntityOneOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.ThirdTestEntityZeroOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.ThirdTestEntityExactlyOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.ThirdTestEntityZeroOrOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityExactlyOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.SecondTestEntityExactlyOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityForTypes>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<TestWebApp.Domain.TestEntityLocalization>().HasQueryFilter(p => p.DeletedAtUtc == null);
    }
}