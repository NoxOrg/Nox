// Generated

#nullable enable

using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Diagnostics;
using TestWebApp.Domain;

namespace TestWebApp.Infrastructure.Persistence;

public partial class TestWebAppDbContext : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public TestWebAppDbContext(
            DbContextOptions<TestWebAppDbContext> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
        }


    public DbSet<TestEntityZeroOrOne> TestEntityZeroOrOnes { get; set; } = null!;

    public DbSet<SecondTestEntityZeroOrOne> SecondTestEntityZeroOrOnes { get; set; } = null!;

    public DbSet<TestEntityWithNuid> TestEntityWithNuids { get; set; } = null!;

    public DbSet<TestEntityOneOrMany> TestEntityOneOrManies { get; set; } = null!;

    public DbSet<SecondTestEntityOneOrMany> SecondTestEntityOneOrManies { get; set; } = null!;

    public DbSet<TestEntityZeroOrMany> TestEntityZeroOrManies { get; set; } = null!;

    public DbSet<SecondTestEntityZeroOrMany> SecondTestEntityZeroOrManies { get; set; } = null!;

    public DbSet<ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManies { get; set; } = null!;

    public DbSet<ThirdTestEntityZeroOrMany> ThirdTestEntityZeroOrManies { get; set; } = null!;

    public DbSet<ThirdTestEntityExactlyOne> ThirdTestEntityExactlyOnes { get; set; } = null!;

    public DbSet<ThirdTestEntityZeroOrOne> ThirdTestEntityZeroOrOnes { get; set; } = null!;

    public DbSet<TestEntityExactlyOne> TestEntityExactlyOnes { get; set; } = null!;

    public DbSet<SecondTestEntityExactlyOne> SecondTestEntityExactlyOnes { get; set; } = null!;

    public DbSet<TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrManies { get; set; } = null!;

    public DbSet<TestEntityZeroOrManyToZeroOrOne> TestEntityZeroOrManyToZeroOrOnes { get; set; } = null!;

    public DbSet<TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrManies { get; set; } = null!;

    public DbSet<TestEntityOneOrManyToExactlyOne> TestEntityOneOrManyToExactlyOnes { get; set; } = null!;

    public DbSet<TestEntityExactlyOneToZeroOrMany> TestEntityExactlyOneToZeroOrManies { get; set; } = null!;

    public DbSet<TestEntityZeroOrManyToExactlyOne> TestEntityZeroOrManyToExactlyOnes { get; set; } = null!;

    public DbSet<TestEntityOneOrManyToZeroOrMany> TestEntityOneOrManyToZeroOrManies { get; set; } = null!;

    public DbSet<TestEntityZeroOrManyToOneOrMany> TestEntityZeroOrManyToOneOrManies { get; set; } = null!;

    public DbSet<TestEntityZeroOrOneToOneOrMany> TestEntityZeroOrOneToOneOrManies { get; set; } = null!;

    public DbSet<TestEntityOneOrManyToZeroOrOne> TestEntityOneOrManyToZeroOrOnes { get; set; } = null!;

    public DbSet<TestEntityZeroOrOneToExactlyOne> TestEntityZeroOrOneToExactlyOnes { get; set; } = null!;

    public DbSet<TestEntityExactlyOneToZeroOrOne> TestEntityExactlyOneToZeroOrOnes { get; set; } = null!;

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
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity, _noxSolution.GetRelationshipsToCreate(codeGeneratorState.GetEntityType, entity));
                }
            }
        }
    }
}