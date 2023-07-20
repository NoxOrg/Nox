// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Generator.Common;
using Nox.Types.EntityFramework.Abstractions;
using SampleWebApp.Domain;

namespace SampleWebApp.Infrastructure.Persistence;

public partial class SampleWebAppDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    
    public SampleWebAppDbContext(
        DbContextOptions<SampleWebAppDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
    }
    
    public DbSet<Country> Countries { get; set; } = null!;
    
    public DbSet<Currency> Currencies { get; set; } = null!;
    
    public DbSet<Store> Stores { get; set; } = null!;
    
    public DbSet<CountryLocalNames> CountryLocalNames { get; set; } = null!;
    
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
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution);
            
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                var type = Type.GetType("SampleWebApp.Domain." + entity.Name);
                
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity);
                }
            }
            
        }
    }
}

