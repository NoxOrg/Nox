// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Configuration;

using TestWebApp.Application.Dto;

namespace TestWebApp.Infrastructure.Persistence;

internal class DtoDbContext : DbContext
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
    protected readonly INoxDtoDatabaseConfigurator _noxDtoDatabaseConfigurator;

    public DtoDbContext(
        DbContextOptions<DtoDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider,
        INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;
    }

    
        public DbSet<TestEntityZeroOrOneDto> TestEntityZeroOrOnes { get; set; } = null!;
        
        public DbSet<SecondTestEntityZeroOrOneDto> SecondTestEntityZeroOrOnes { get; set; } = null!;
        
        public DbSet<TestEntityWithNuidDto> TestEntityWithNuids { get; set; } = null!;
        
        public DbSet<TestEntityOneOrManyDto> TestEntityOneOrManies { get; set; } = null!;
        
        public DbSet<SecondTestEntityOneOrManyDto> SecondTestEntityOneOrManies { get; set; } = null!;
        
        public DbSet<TestEntityZeroOrManyDto> TestEntityZeroOrManies { get; set; } = null!;
        
        public DbSet<SecondTestEntityZeroOrManyDto> SecondTestEntityZeroOrManies { get; set; } = null!;
        
        public DbSet<ThirdTestEntityOneOrManyDto> ThirdTestEntityOneOrManies { get; set; } = null!;
        
        public DbSet<ThirdTestEntityZeroOrManyDto> ThirdTestEntityZeroOrManies { get; set; } = null!;
        
        public DbSet<ThirdTestEntityExactlyOneDto> ThirdTestEntityExactlyOnes { get; set; } = null!;
        
        public DbSet<ThirdTestEntityZeroOrOneDto> ThirdTestEntityZeroOrOnes { get; set; } = null!;
        
        public DbSet<TestEntityExactlyOneDto> TestEntityExactlyOnes { get; set; } = null!;
        
        public DbSet<SecondTestEntityExactlyOneDto> SecondTestEntityExactlyOnes { get; set; } = null!;
        
        public DbSet<TestEntityZeroOrOneToZeroOrManyDto> TestEntityZeroOrOneToZeroOrManies { get; set; } = null!;
        
        public DbSet<TestEntityZeroOrManyToZeroOrOneDto> TestEntityZeroOrManyToZeroOrOnes { get; set; } = null!;
        
        public DbSet<TestEntityExactlyOneToOneOrManyDto> TestEntityExactlyOneToOneOrManies { get; set; } = null!;
        
        public DbSet<TestEntityOneOrManyToExactlyOneDto> TestEntityOneOrManyToExactlyOnes { get; set; } = null!;
        
        public DbSet<TestEntityExactlyOneToZeroOrManyDto> TestEntityExactlyOneToZeroOrManies { get; set; } = null!;
        
        public DbSet<TestEntityZeroOrManyToExactlyOneDto> TestEntityZeroOrManyToExactlyOnes { get; set; } = null!;
        
        public DbSet<TestEntityOneOrManyToZeroOrManyDto> TestEntityOneOrManyToZeroOrManies { get; set; } = null!;
        
        public DbSet<TestEntityZeroOrManyToOneOrManyDto> TestEntityZeroOrManyToOneOrManies { get; set; } = null!;
        
        public DbSet<TestEntityZeroOrOneToOneOrManyDto> TestEntityZeroOrOneToOneOrManies { get; set; } = null!;
        
        public DbSet<TestEntityOneOrManyToZeroOrOneDto> TestEntityOneOrManyToZeroOrOnes { get; set; } = null!;
        
        public DbSet<TestEntityZeroOrOneToExactlyOneDto> TestEntityZeroOrOneToExactlyOnes { get; set; } = null!;
        
        public DbSet<TestEntityExactlyOneToZeroOrOneDto> TestEntityExactlyOneToZeroOrOnes { get; set; } = null!;
        
        public DbSet<TestEntityOwnedRelationshipExactlyOneDto> TestEntityOwnedRelationshipExactlyOnes { get; set; } = null!;
        
        public DbSet<TestEntityOwnedRelationshipZeroOrOneDto> TestEntityOwnedRelationshipZeroOrOnes { get; set; } = null!;
        
        public DbSet<TestEntityOwnedRelationshipOneOrManyDto> TestEntityOwnedRelationshipOneOrManies { get; set; } = null!;
        
        public DbSet<TestEntityOwnedRelationshipZeroOrManyDto> TestEntityOwnedRelationshipZeroOrManies { get; set; } = null!;
        
        public DbSet<TestEntityTwoRelationshipsOneToOneDto> TestEntityTwoRelationshipsOneToOnes { get; set; } = null!;
        
        public DbSet<SecondTestEntityTwoRelationshipsOneToOneDto> SecondTestEntityTwoRelationshipsOneToOnes { get; set; } = null!;
        
        public DbSet<TestEntityTwoRelationshipsManyToManyDto> TestEntityTwoRelationshipsManyToManies { get; set; } = null!;
        
        public DbSet<SecondTestEntityTwoRelationshipsManyToManyDto> SecondTestEntityTwoRelationshipsManyToManies { get; set; } = null!;
        
        public DbSet<TestEntityTwoRelationshipsOneToManyDto> TestEntityTwoRelationshipsOneToManies { get; set; } = null!;
        
        public DbSet<SecondTestEntityTwoRelationshipsOneToManyDto> SecondTestEntityTwoRelationshipsOneToManies { get; set; } = null!;
        
        public DbSet<TestEntityForTypesDto> TestEntityForTypes { get; set; } = null!;
        
        public DbSet<TestEntityForUniqueConstraintsDto> TestEntityForUniqueConstraints { get; set; } = null!;
        

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
            var codeGeneratorState =
                new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
            {
                // Ignore owned entities configuration as they are configured inside entity constructor
                if (entity.IsOwnedEntity)
                {
                    continue;
                }

                var type = codeGeneratorState.GetEntityDtoType(entity.Name + "Dto");
                if (type != null)
                {
                    _noxDtoDatabaseConfigurator.ConfigureDto(codeGeneratorState,
                        new Nox.Types.EntityFramework.EntityBuilderAdapter.EntityBuilderAdapter(
                            modelBuilder.Entity(type)), entity);
                }
                else
                {
                    throw new Exception($"Could not resolve type for {entity.Name}Dto");
                }
            }
        }
    }
}