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

using DomainNameSpace = Cryptocash.Domain;
using Cryptocash.Domain;

namespace Cryptocash.Infrastructure.Persistence;

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

internal abstract partial class AppDbContextBase : Nox.Infrastructure.Persistence.EntityDbContextBase
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
    
    public virtual DbSet<Cryptocash.Domain.Booking> Bookings { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.Commission> Commissions { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.Country> Countries { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.Currency> Currencies { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.Customer> Customers { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.PaymentDetail> PaymentDetails { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.Transaction> Transactions { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.Employee> Employees { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.LandLord> LandLords { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.MinimumCashStock> MinimumCashStocks { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.PaymentProvider> PaymentProviders { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.VendingMachine> VendingMachines { get; set; } = null!;
    public virtual DbSet<Cryptocash.Domain.CashStockOrder> CashStockOrders { get; set; } = null!;
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(
                optionsBuilder,
                "Cryptocash",
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
                ConfigureEnumeration(modelBuilder.Entity($"Cryptocash.Domain.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}"), enumAttribute.EnumerationTypeOptions!);
                if (enumAttribute.EnumerationTypeOptions!.IsLocalized)
                {
                    var enumLocalizedType = _clientAssemblyProvider.GetEntityType($"Cryptocash.Domain.{_codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, enumAttribute.Name)}")!;
                    var enumType = _clientAssemblyProvider.GetEntityType($"Cryptocash.Domain.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}")!;
                    ConfigureEnumerationLocalized(modelBuilder.Entity(enumLocalizedType), enumType, enumLocalizedType, enumAttribute.EnumerationTypeOptions!, _noxSolution.Application!.Localization!.DefaultCulture);
                }
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
}