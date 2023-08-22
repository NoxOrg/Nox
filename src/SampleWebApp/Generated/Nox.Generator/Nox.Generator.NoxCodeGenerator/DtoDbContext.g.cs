// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Infrastructure.Persistence;

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
        public DtoDbContext(
            DbContextOptions<DtoDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
        }
        
        public DbSet<CountryDto> Countries { get; set; } = null!;
        
        public DbSet<CurrencyDto> Currencies { get; set; } = null!;
        
        public DbSet<StoreDto> Stores { get; set; } = null!;
        
        public DbSet<StoreSecurityPasswordsDto> StoreSecurityPasswords { get; set; } = null!;
        
        public DbSet<AllNoxTypeDto> AllNoxTypes { get; set; } = null!;
        
        public DbSet<CurrencyCashBalanceDto> CurrencyCashBalances { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
            {
                _dbProvider.ConfigureDbContext(optionsBuilder, "SampleWebApp", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
            }
        }
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                var type = typeof(CountryDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
                builder.OwnsMany(typeof(CountryLocalNamesDto), "CountryLocalNames", owned =>
                    {
                         
                        owned.WithOwner().HasForeignKey("CountryId");
                        owned.HasKey("Id");
                        owned.ToTable("CountryLocalNames");
                        owned.Property("Id").ValueGeneratedOnAdd();
                    }
                );
            }
            {
                var type = typeof(CurrencyDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
            }
            {
                var type = typeof(StoreDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
            }
            {
                var type = typeof(StoreSecurityPasswordsDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
            }
            {
                var type = typeof(AllNoxTypeDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
                builder.HasKey("TextId");
            }
            {
                var type = typeof(CurrencyCashBalanceDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("StoreId");
                builder.HasKey("CurrencyId");
            }
        }
    }
