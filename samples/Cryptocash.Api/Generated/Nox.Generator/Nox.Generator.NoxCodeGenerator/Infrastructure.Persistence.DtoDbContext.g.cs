// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Cryptocash.Application.Dto;

namespace Cryptocash.Infrastructure.Persistence;

public class DtoDbContext : DbContext
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

    public DtoDbContext(
        DbContextOptions<DtoDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider,
        INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;
    }

    
        public DbSet<BookingDto> Bookings { get; set; } = null!;
        
        public DbSet<CommissionDto> Commissions { get; set; } = null!;
        
        public DbSet<CountryDto> Countries { get; set; } = null!;
        
        public DbSet<CurrencyDto> Currencies { get; set; } = null!;
        
        public DbSet<CustomerDto> Customers { get; set; } = null!;
        
        public DbSet<PaymentDetailDto> PaymentDetails { get; set; } = null!;
        
        public DbSet<TransactionDto> Transactions { get; set; } = null!;
        
        public DbSet<EmployeeDto> Employees { get; set; } = null!;
        
        public DbSet<LandLordDto> LandLords { get; set; } = null!;
        
        public DbSet<MinimumCashStockDto> MinimumCashStocks { get; set; } = null!;
        
        public DbSet<PaymentProviderDto> PaymentProviders { get; set; } = null!;
        
        public DbSet<VendingMachineDto> VendingMachines { get; set; } = null!;
        
        public DbSet<CashStockOrderDto> CashStockOrders { get; set; } = null!;
        

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
            var codeGeneratorState =
                new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
            {
                // Ignore owned entities configuration as they are configured inside entity constructor
                if (entity.IsOwnedEntity)
                {
                    continue;
                }

                var type = codeGeneratorState.GetEntityDtoType(entity.Name + "Dto");
                if (type != null)
                {
                    _noxDtoDatabaseConfigurator.ConfigureDto(codeGeneratorState,
                        new Nox.Types.EntityFramework.EntityBuilderAdapter.EntityBuilderAdapter(
                            modelBuilder.Entity(type)), entity);
                }
                else
                {
                    throw new Exception($"Could not resolve type for {entity.Name}Dto");
                }
            }
        }
    }
}