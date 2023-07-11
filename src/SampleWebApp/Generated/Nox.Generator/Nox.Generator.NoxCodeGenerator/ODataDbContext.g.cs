// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;

namespace SampleWebApp.Presentation.Api.OData;

public class ODataDbContext : DbContext
{
    
    
    /// <summary>
    /// The Nox sulution configuration.
    /// </summary>
    protected readonly NoxSolution _noxSolution;
    
    /// <summary>
    /// The database provider.
    /// </summary>
    protected readonly INoxDatabaseProvider _dbProvider;
        public ODataDbContext(
            DbContextOptions<ODataDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
        }
        
        public DbSet<Country> Countries {get; set;} = null!;
        
        public DbSet<Currency> Currencies {get; set;} = null!;
        
        public DbSet<Store> Stores {get; set;} = null!;
        
        public DbSet<CountryLocalNames> CountryLocalNames {get; set;} = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
            {
                _dbProvider.ConfigureDbContext(optionsBuilder, "SampleWebApp", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
            }
        }
        
    }
