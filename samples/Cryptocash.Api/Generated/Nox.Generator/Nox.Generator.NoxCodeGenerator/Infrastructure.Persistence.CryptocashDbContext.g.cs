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


using Cryptocash.Domain;

namespace Cryptocash.Infrastructure.Persistence;

internal partial class CryptocashDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;
    private readonly IPublisher _publisher;

    public CryptocashDbContext(
            DbContextOptions<CryptocashDbContext> options,
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

    public DbSet<Cryptocash.Domain.Booking> Bookings { get; set; } = null!;

    public DbSet<Cryptocash.Domain.Commission> Commissions { get; set; } = null!;

    public DbSet<Cryptocash.Domain.Country> Countries { get; set; } = null!;



    public DbSet<Cryptocash.Domain.Currency> Currencies { get; set; } = null!;


    public DbSet<Cryptocash.Domain.Customer> Customers { get; set; } = null!;

    public DbSet<Cryptocash.Domain.PaymentDetail> PaymentDetails { get; set; } = null!;

    public DbSet<Cryptocash.Domain.Transaction> Transactions { get; set; } = null!;

    public DbSet<Cryptocash.Domain.Employee> Employees { get; set; } = null!;



    public DbSet<Cryptocash.Domain.LandLord> LandLords { get; set; } = null!;

    public DbSet<Cryptocash.Domain.MinimumCashStock> MinimumCashStocks { get; set; } = null!;

    public DbSet<Cryptocash.Domain.PaymentProvider> PaymentProviders { get; set; } = null!;

    public DbSet<Cryptocash.Domain.VendingMachine> VendingMachines { get; set; } = null!;

    public DbSet<Cryptocash.Domain.CashStockOrder> CashStockOrders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "Cryptocash", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
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
                Console.WriteLine($"CryptocashDbContext Configure database for Entity {entity.Name}");

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
        modelBuilder.Entity<Cryptocash.Domain.Booking>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.Commission>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.Country>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.Currency>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.Customer>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.PaymentDetail>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.Transaction>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.Employee>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.LandLord>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.MinimumCashStock>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.PaymentProvider>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.VendingMachine>().HasQueryFilter(p => p.DeletedAtUtc == null);
        modelBuilder.Entity<Cryptocash.Domain.CashStockOrder>().HasQueryFilter(p => p.DeletedAtUtc == null);
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