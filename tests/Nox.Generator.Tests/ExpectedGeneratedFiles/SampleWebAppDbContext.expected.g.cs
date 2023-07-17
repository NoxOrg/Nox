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
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "SampleWebApp", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
        }
    }
    
    public static Type? GetTypeByEntityName(string entityName)
    {
        return Type.GetType("SampleWebApp.Domain." + entityName);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (_noxSolution.Domain != null)
        {
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution);
            
            var relationships = ((INoxDatabaseConfigurator)_dbProvider).GetRelationshipsToCreate(codeGeneratorState, _noxSolution.Domain.Entities, modelBuilder);
            relationships = relationships
                .OrderBy(x => x.Entity.Name)
                .ToList();
            
            foreach (var relationship in relationships)
            {
                relationship.RelationshipEntityType = GetTypeByEntityName(relationship.Relationship.Entity)!;
            }
            
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                var type = GetTypeByEntityName(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity, relationships);
                }
            }
            
        }
    }
}

