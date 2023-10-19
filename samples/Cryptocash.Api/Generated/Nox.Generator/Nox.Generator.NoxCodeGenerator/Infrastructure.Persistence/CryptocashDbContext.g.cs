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


using Cryptocash.Domain;

namespace Cryptocash.Infrastructure.Persistence;

internal partial class CryptocashDbContext : Nox.Infrastructure.Persistence.EntityDbContextBase
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public CryptocashDbContext(
            DbContextOptions<CryptocashDbContext> options,
            IPublisher publisher,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider,
            IUserProvider userProvider,
            ISystemProvider systemProvider
        ) : base(publisher, userProvider, systemProvider, options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
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


        var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
        foreach (var entity in _noxSolution.Domain!.Entities)
        {
            Console.WriteLine($"CryptocashDbContext Configure database for Entity {entity.Name}");

            // Ignore owned entities configuration as they are configured inside entity constructor
            if (entity.IsOwnedEntity)
            {
                continue;
            }

            var type = _clientAssemblyProvider.GetType(codeGeneratorState.GetEntityTypeFullName(entity.Name));
            if (type != null)
            {
                ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, new EntityBuilderAdapter(modelBuilder.Entity(type)), entity);
            }
        }

        modelBuilder.ForEntitiesOfType<IEntityConcurrent>(
            builder => builder.Property(nameof(IEntityConcurrent.Etag)).IsConcurrencyToken());
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
}