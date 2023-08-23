// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using CryptocashApi.Application.Dto;

namespace CryptocashApi.Infrastructure.Persistence;

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
        
        public DbSet<CustomerDto> Customers { get; set; } = null!;
        
        public DbSet<EmployeeDto> Employees { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
            {
                _dbProvider.ConfigureDbContext(optionsBuilder, "CryptocashApi", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
            }
        }
        
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            {
                var type = typeof(CustomerDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
            }
            {
                var type = typeof(EmployeeDto);
                var builder = modelBuilder.Entity(type!);
                
                builder.HasKey("Id");
            }
        }
    }
