// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using TestDatabaseWebApp.Domain;

namespace TestDatabaseWebApp.Infrastructure.Persistence;

public partial class TestDatabaseWebAppDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    
    public TestDatabaseWebAppDbContext(
        DbContextOptions<TestDatabaseWebAppDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
    }
    
    public DbSet<TestEntity> TestEntities { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "TestDatabaseWebApp", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (_noxSolution.Domain != null)
        {
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                var type = Type.GetType("TestDatabaseWebApp.Domain." + entity.Name);
                
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(modelBuilder.Entity(type), entity);
                }
            }
            
        }
    }
}

