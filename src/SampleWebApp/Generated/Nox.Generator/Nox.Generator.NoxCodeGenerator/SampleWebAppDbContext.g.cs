// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.vNext;
using SampleWebApp.Domain;

namespace SampleWebApp.Infrastructure.Persistence;

public partial class SampleWebAppDbContext : DbContext
{
    private NoxSolution _noxSolution { get; set; }
    private INoxDatabaseConfigurator _databaseConfigurator { get; set; }
    
    public SampleWebAppDbContext(
        DbContextOptions<SampleWebAppDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseConfigurator databaseConfigurator
        ) : base(options)
    {
        _noxSolution = noxSolution;
        _databaseConfigurator = databaseConfigurator;
    }
    
    public DbSet<Country> Countries {get; set;} = null!;
    
    public DbSet<Currency> Currencies {get; set;} = null!;
    
    public DbSet<Store> Stores {get; set;} = null!;
    
    public DbSet<CountryLocalNames> CountryLocalNames {get; set;} = null!;
    
    
    public static void RegisterDbContext(IServiceCollection services)
    {
        services.AddDbContext<SampleWebAppDbContext>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        base.OnModelCreating(modelBuilder);
    }
}

