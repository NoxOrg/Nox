// Generated

#nullable enable

using Nox;
using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Solution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;
using System.Diagnostics;

using Cryptocash.Domain;

namespace Cryptocash.Infrastructure.Persistence;

public partial class CryptocashDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    private readonly IUserProvider _userProvider;
    private readonly ISystemProvider _systemProvider;

    public CryptocashDbContext(
            DbContextOptions<CryptocashDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider, 
            IUserProvider userProvider,
            ISystemProvider systemProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
            _userProvider = userProvider;
            _systemProvider = systemProvider;
        }

    public DbSet<Booking> Bookings { get; set; } = null!;

    public DbSet<Commission> Commissions { get; set; } = null!;

    public DbSet<Country> Countries { get; set; } = null!;



    public DbSet<Currency> Currencies { get; set; } = null!;


    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<PaymentDetail> PaymentDetails { get; set; } = null!;

    public DbSet<Transaction> Transactions { get; set; } = null!;

    public DbSet<Employee> Employees { get; set; } = null!;



    public DbSet<LandLord> LandLords { get; set; } = null!;

    public DbSet<MinimumCashStock> MinimumCashStocks { get; set; } = null!;

    public DbSet<PaymentProvider> PaymentProviders { get; set; } = null!;

    public DbSet<VendingMachine> VendingMachines { get; set; } = null!;

    public DbSet<CashStockOrder> CashStockOrders { get; set; } = null!;

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
        }
    }

    /// <inheritdoc/>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AuditEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AuditEntities()
    {
        ChangeTracker.DetectChanges();

        foreach (var entry in ChangeTracker.Entries<AuditableEntityBase>())
        {
            AuditEntity(entry);
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
                ReattachCompoundTypes(entry);
                break;
        }
    }

    private void ReattachCompoundTypes(EntityEntry<AuditableEntityBase> parentEntry)
    {
        foreach (var navigationEntry in parentEntry.Navigations)
        {
            foreach (var typeEntry in ChangeTracker.Entries<INoxType>())
            {
                if (typeEntry.Metadata.IsOwned() && typeEntry.State == EntityState.Deleted && typeEntry.Entity == navigationEntry.CurrentValue)
                {
                    typeEntry.State = EntityState.Unchanged;
                }
            }
        }
    }
}