// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.DatabaseProvider;
using Nox.Solution;
using Nox.Types.EntityFramework.vNext;
using SampleWebApp.Domain;

namespace SampleWebApp.Infrastructure.Persistence;

public partial class SampleWebAppDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseConfigurator _databaseConfigurator;
    private readonly INoxDatabaseProvider _dbProvider;
    
    public SampleWebAppDbContext(
        DbContextOptions<SampleWebAppDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseConfigurator databaseConfigurator,
        INoxDatabaseProvider databaseProvider
    ) : base(options)
    {
            _noxSolution = noxSolution;
            _databaseConfigurator = databaseConfigurator;
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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (_noxSolution.Domain != null)
        {
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                var type = Type.GetType("SampleWebApp.Domain." + entity.Name);
                
                if (type != null)
                {
                    _databaseConfigurator.ConfigureEntity(modelBuilder.Entity(type), entity);
                }
            }
            
        }
    }
}

