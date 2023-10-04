// Generated

#nullable enable

using System.Reflection;
using System.Diagnostics;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

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


using TestWebApp.Domain;

namespace TestWebApp.Infrastructure.Persistence;

public partial class TestWebAppDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;
    private readonly IPublisher _publisher;

    public TestWebAppDbContext(
            DbContextOptions<TestWebAppDbContext> options,
            IPublisher publisher,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider, 
            IUserProvider userProvider,
            ISystemProvider systemProvider
        ) : base(options)
        {
            _publisher = publisher;
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
            _userProvider = userProvider;
            _systemProvider = systemProvider;
        }

    internal DbSet<TestWebApp.Domain.TestEntityZeroOrOne> TestEntityZeroOrOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.SecondTestEntityZeroOrOne> SecondTestEntityZeroOrOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityWithNuid> TestEntityWithNuids { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityOneOrMany> TestEntityOneOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.SecondTestEntityOneOrMany> SecondTestEntityOneOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityZeroOrMany> TestEntityZeroOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.SecondTestEntityZeroOrMany> SecondTestEntityZeroOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.ThirdTestEntityZeroOrMany> ThirdTestEntityZeroOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.ThirdTestEntityExactlyOne> ThirdTestEntityExactlyOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.ThirdTestEntityZeroOrOne> ThirdTestEntityZeroOrOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityExactlyOne> TestEntityExactlyOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.SecondTestEntityExactlyOne> SecondTestEntityExactlyOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne> TestEntityZeroOrManyToZeroOrOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne> TestEntityOneOrManyToExactlyOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany> TestEntityExactlyOneToZeroOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne> TestEntityZeroOrManyToExactlyOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany> TestEntityOneOrManyToZeroOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany> TestEntityZeroOrManyToOneOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany> TestEntityZeroOrOneToOneOrManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne> TestEntityOneOrManyToZeroOrOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne> TestEntityZeroOrOneToExactlyOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne> TestEntityExactlyOneToZeroOrOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne> TestEntityOwnedRelationshipExactlyOnes { get; set; } = null!;


    internal DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne> TestEntityOwnedRelationshipZeroOrOnes { get; set; } = null!;


    internal DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany> TestEntityOwnedRelationshipOneOrManies { get; set; } = null!;


    internal DbSet<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany> TestEntityOwnedRelationshipZeroOrManies { get; set; } = null!;


    internal DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne> TestEntityTwoRelationshipsOneToOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne> SecondTestEntityTwoRelationshipsOneToOnes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany> TestEntityTwoRelationshipsManyToManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany> SecondTestEntityTwoRelationshipsManyToManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany> TestEntityTwoRelationshipsOneToManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany> SecondTestEntityTwoRelationshipsOneToManies { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityForTypes> TestEntityForTypes { get; set; } = null!;

    internal DbSet<TestWebApp.Domain.TestEntityForUniqueConstraints> TestEntityForUniqueConstraints { get; set; } = null!;

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

        if (_noxSolution.Domain != null)
        {
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);                            
            foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
            {
                Console.WriteLine($"TestWebAppDbContext Configure database for Entity {entity.Name}");

                // Ignore owned entities configuration as they are configured inside entity constructor
                if (entity.IsOwnedEntity)
                {
                    continue;
                }

                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, new EntityBuilderAdapter(modelBuilder.Entity(type)), entity);
                }
            }

            modelBuilder.ForEntitiesOfType<IEntityConcurrent>(
                builder => builder.Property(nameof(IEntityConcurrent.Etag)).IsConcurrencyToken());
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
    }

    /// <inheritdoc/>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            HandleSystemFields();
            await HandleDomainEvents();
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch(DbUpdateConcurrencyException)
        {
            throw new Nox.Exceptions.ConcurrencyException($"Latest value of {nameof(IEntityConcurrent.Etag)} must be provided");
        }
    }

    private async Task HandleDomainEvents()
    {
        var entriesWithDomainEvents = GetEntriesWithDomainEvents();
        RaiseDomainEventsFor(entriesWithDomainEvents); 
        await DispatchEvents(entriesWithDomainEvents.SelectMany(e=>e.Entity.DomainEvents));
        ClearDomainEvents(entriesWithDomainEvents.ToList());
    }
    public IEnumerable<EntityEntry<IEntityHaveDomainEvents>> GetEntriesWithDomainEvents()
    {
        return ChangeTracker.Entries<IEntityHaveDomainEvents>();
    }

    public void RaiseDomainEventsFor(IEnumerable<EntityEntry<IEntityHaveDomainEvents>> entriesWithDomainEvents)
    {
        foreach (var entry in entriesWithDomainEvents)
        {
            RaiseDomainEvent(entry);
        }
    }

    private void RaiseDomainEvent(EntityEntry<IEntityHaveDomainEvents> entry)
    {
        switch (entry.State)
        {
            case EntityState.Added:
                entry.Entity.RaiseCreateEvent();
                break;

            case EntityState.Modified:
                entry.Entity.RaiseUpdateEvent();
                break;

            case EntityState.Deleted:
                entry.Entity.RaiseDeleteEvent();
                break;
        }
    }
        
    private async Task DispatchEvents(IEnumerable<IDomainEvent> selectMany)
    {
        var tasks = selectMany.Select(domainEvent => _publisher.Publish(domainEvent));
        await Task.WhenAll(tasks);
    }
        
    private void ClearDomainEvents(List<EntityEntry<IEntityHaveDomainEvents>> entriesWithDomainEvents)
    {
        entriesWithDomainEvents.ForEach(e=>e.Entity.ClearDomainEvents());
    }

    private void HandleSystemFields()
    {
        ChangeTracker.DetectChanges();

        foreach (var entry in ChangeTracker.Entries<AuditableEntityBase>())
        {
            AuditEntity(entry);
        }

        foreach (var entry in ChangeTracker.Entries<IEntityConcurrent>())
        {
            TrackConcurrency(entry);
        }
    }

    private void AuditEntity(EntityEntry<AuditableEntityBase> entry)
    {
        var user = _userProvider.GetUser();
        var system = _systemProvider.GetSystem();

        switch (entry.State)
        {
            case EntityState.Added:
                entry.Entity.Created(user, system);
                break;

            case EntityState.Modified:
                entry.Entity.Updated(user, system);
                break;

            case EntityState.Deleted:
                entry.State = EntityState.Modified;
                entry.Entity.Deleted(user, system);
                ReattachOwnedEntries<IOwnedEntity>(entry);
                ReattachOwnedEntries<INoxType>(entry);
                break;
        }
    }

    private void ReattachOwnedEntries<T>(EntityEntry<AuditableEntityBase> parentEntry)
        where T : class
    {
        foreach (var navigationEntry in parentEntry.Navigations)
        {
            foreach (var ownedEntry in ChangeTracker.Entries<T>())
            {
                var isOwnedAndDeltetedEntry = ownedEntry.Metadata.IsOwned() && ownedEntry.State == EntityState.Deleted;
                var isOwnedByCurrentParentEntry = ownedEntry.Entity == navigationEntry.CurrentValue || (navigationEntry.CurrentValue as IEnumerable<T>)?.Contains(ownedEntry.Entity) == true;

                if (isOwnedAndDeltetedEntry && isOwnedByCurrentParentEntry)
                {
                    ownedEntry.State = EntityState.Unchanged;
                }
            }
        }
    }

    private void TrackConcurrency(EntityEntry<IEntityConcurrent> entry)
    {
        switch (entry.State)
        {
            case EntityState.Added:
                entry.Property(e => e.Etag).CurrentValue = System.Guid.NewGuid();
                break;

            case EntityState.Modified:
            case EntityState.Deleted:
                entry.Property(e => e.Etag).OriginalValue = entry.Property(p => p.Etag).CurrentValue;
                entry.Property(e => e.Etag).CurrentValue = System.Guid.NewGuid();
                break;
        }
    }
}