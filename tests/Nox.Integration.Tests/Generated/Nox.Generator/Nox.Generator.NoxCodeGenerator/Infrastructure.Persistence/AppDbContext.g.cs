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

using DomainNameSpace = TestWebApp.Domain;
using TestWebApp.Domain;

namespace TestWebApp.Infrastructure.Persistence;

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
    
    public DbSet<TestWebApp.Domain.TestEntityZeroOrOne> TestEntityZeroOrOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.SecondTestEntityZeroOrOne> SecondTestEntityZeroOrOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityWithNuid> TestEntityWithNuids { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityOneOrMany> TestEntityOneOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.SecondTestEntityOneOrMany> SecondTestEntityOneOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityZeroOrMany> TestEntityZeroOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.SecondTestEntityZeroOrMany> SecondTestEntityZeroOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.ThirdTestEntityZeroOrMany> ThirdTestEntityZeroOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.ThirdTestEntityExactlyOne> ThirdTestEntityExactlyOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.ThirdTestEntityZeroOrOne> ThirdTestEntityZeroOrOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityExactlyOne> TestEntityExactlyOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.SecondTestEntityExactlyOne> SecondTestEntityExactlyOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne> TestEntityZeroOrManyToZeroOrOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne> TestEntityOneOrManyToExactlyOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany> TestEntityExactlyOneToZeroOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne> TestEntityZeroOrManyToExactlyOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany> TestEntityOneOrManyToZeroOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany> TestEntityZeroOrManyToOneOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany> TestEntityZeroOrOneToOneOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne> TestEntityOneOrManyToZeroOrOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne> TestEntityZeroOrOneToExactlyOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne> TestEntityExactlyOneToZeroOrOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne> TestEntityOwnedRelationshipExactlyOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne> TestEntityOwnedRelationshipZeroOrOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany> TestEntityOwnedRelationshipOneOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany> TestEntityOwnedRelationshipZeroOrManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne> TestEntityTwoRelationshipsOneToOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne> SecondTestEntityTwoRelationshipsOneToOnes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany> TestEntityTwoRelationshipsManyToManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany> SecondTestEntityTwoRelationshipsManyToManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany> TestEntityTwoRelationshipsOneToManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany> SecondTestEntityTwoRelationshipsOneToManies { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityForTypes> TestEntityForTypes { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityForUniqueConstraints> TestEntityForUniqueConstraints { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityLocalization> TestEntityLocalizations { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityForAutoNumberUsages> TestEntityForAutoNumberUsages { get; set; } = null!;
    public DbSet<TestWebApp.Domain.TestEntityLocalizationLocalized> TestEntityLocalizationsLocalized { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "TestWebApp", _noxSolution.Infrastructure!.Persistence.DatabaseServer);
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

            if (entity.IsLocalized)
            {
                type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityTypeFullName(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name)));

                ((INoxDatabaseConfigurator)_dbProvider).ConfigureLocalizedEntity(new EntityBuilderAdapter(modelBuilder.Entity(type!)), entity);
            }
        }

        modelBuilder.ForEntitiesOfType<IEntityConcurrent>(
            builder => builder.Property(nameof(IEntityConcurrent.Etag)).IsConcurrencyToken());
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