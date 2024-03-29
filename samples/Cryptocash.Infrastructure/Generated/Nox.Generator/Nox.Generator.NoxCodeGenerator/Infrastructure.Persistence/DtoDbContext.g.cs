﻿// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Nox;
using Nox.Solution;
using Nox.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Infrastructure;
using Nox.Infrastructure.Persistence;
using Cryptocash.Application.Dto;
using DtoNameSpace = Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure.Persistence;

public partial class DtoDbContext : DtoDbContextBase
{
    public DtoDbContext(
      DbContextOptions<DtoDbContext> options,
      NoxSolution noxSolution,
      INoxDatabaseProvider databaseProvider,
      INoxClientAssemblyProvider clientAssemblyProvider,
      INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator,
      NoxCodeGenConventions codeGenConventions,
      IEnumerable<IInterceptor> interceptors)
      : base(
          options,
          noxSolution,
          databaseProvider,
          clientAssemblyProvider,
          noxDtoDatabaseConfigurator,
          codeGenConventions,
          interceptors)
    { }
}
public abstract partial class DtoDbContextBase : DbContext, Nox.Application.Repositories.IReadOnlyRepository
{
    /// <summary>
    /// The Nox solution configuration.
    /// </summary>
    protected readonly NoxSolution _noxSolution;

    /// <summary>
    /// The database provider.
    /// </summary>
    protected readonly INoxDatabaseProvider _dbProvider;

    protected readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    protected readonly INoxDtoDatabaseConfigurator _noxDtoDatabaseConfigurator;
    private readonly NoxCodeGenConventions _codeGenConventions;

    private readonly IEnumerable<IInterceptor> _interceptors;

    public DtoDbContextBase(
        DbContextOptions<DtoDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider,
        INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator,
        NoxCodeGenConventions codeGenConventions,
        IEnumerable<IInterceptor> interceptors) 
        : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;
        _codeGenConventions = codeGenConventions;
        _interceptors = interceptors;
    }

    
        public virtual DbSet<BookingDto> Bookings { get; set; } = null!;
        public virtual DbSet<CommissionDto> Commissions { get; set; } = null!;
        public virtual DbSet<CountryDto> Countries { get; set; } = null!;
        public virtual DbSet<CurrencyDto> Currencies { get; set; } = null!;
        public virtual DbSet<CustomerDto> Customers { get; set; } = null!;
        public virtual DbSet<PaymentDetailDto> PaymentDetails { get; set; } = null!;
        public virtual DbSet<TransactionDto> Transactions { get; set; } = null!;
        public virtual DbSet<EmployeeDto> Employees { get; set; } = null!;
        public virtual DbSet<LandLordDto> LandLords { get; set; } = null!;
        public virtual DbSet<MinimumCashStockDto> MinimumCashStocks { get; set; } = null!;
        public virtual DbSet<PaymentProviderDto> PaymentProviders { get; set; } = null!;
        public virtual DbSet<VendingMachineDto> VendingMachines { get; set; } = null!;
        public virtual DbSet<CashStockOrderDto> CashStockOrders { get; set; } = null!;

    public IQueryable<T> Query<T>() where T : class
    {
        return this.Set<T>().AsNoTracking();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(
                optionsBuilder, 
                "Cryptocash",
                _noxSolution.Infrastructure!.Persistence.DatabaseServer,
                _clientAssemblyProvider.DtoAssembly.GetName().Name);
            optionsBuilder.AddInterceptors(_interceptors);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureAuditable(modelBuilder);

        if (_noxSolution.Domain != null)
        {            
            foreach (var entity in _codeGenConventions.Solution.Domain!.Entities)
            {
                var dtoName = entity.Name + "Dto";

                var type = _clientAssemblyProvider.GetEntityDtoType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                    ?? throw new TypeNotFoundException(dtoName);

                _noxDtoDatabaseConfigurator.ConfigureDto(modelBuilder.Entity(type).ToTable(entity.Persistence.TableName), entity, _clientAssemblyProvider.DtoAssembly);

                if (entity.IsLocalized)
                {
                    dtoName = NoxCodeGenConventions.GetEntityDtoNameForLocalizedType(entity.Name);
                    
                    type = _clientAssemblyProvider.GetEntityDtoType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                        ?? throw new TypeNotFoundException(dtoName);

                    _noxDtoDatabaseConfigurator.ConfigureLocalizedDto(modelBuilder.Entity(type!), entity);
                }
            }
        }
    }

private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<CommissionDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<CountryDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<CurrencyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<CustomerDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<PaymentDetailDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TransactionDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<EmployeeDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<LandLordDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<MinimumCashStockDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<PaymentProviderDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<VendingMachineDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<CashStockOrderDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
    }
}