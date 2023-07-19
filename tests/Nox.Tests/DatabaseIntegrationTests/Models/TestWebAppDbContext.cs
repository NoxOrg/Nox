// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Generator.Common;
using Nox.Types.EntityFramework.Abstractions;
using TestWebApp.Domain;

namespace TestWebApp.Infrastructure.Persistence;

public partial class TestWebAppDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;

    public TestWebAppDbContext(
        DbContextOptions<TestWebAppDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
    }

    public DbSet<TestEntity> TestEntities { get; set; } = null!;

    public DbSet<SecondTestEntity> SecondTestEntities { get; set; } = null!;

    public DbSet<TestEntityForTypes> TestEntityForTypes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "TestWebApp", _noxSolution.Infrastructure!.Persistence.DatabaseServer);
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
                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity, _noxSolution.GetRelationshipsToCreate(codeGeneratorState.GetEntityType));
                }
            }

        }
    }
}

