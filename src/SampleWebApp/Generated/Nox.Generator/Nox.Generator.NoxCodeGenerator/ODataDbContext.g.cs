// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Presentation.Api.OData;

public class ODataDbContext : DbContext
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
        public ODataDbContext(
            DbContextOptions<ODataDbContext> options,
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
        
        public DbSet<CountryLocalNamesDto> CountryLocalNames { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
            {
                _dbProvider.ConfigureDbContext(optionsBuilder, "SampleWebApp", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
            }
        }
        
    }
