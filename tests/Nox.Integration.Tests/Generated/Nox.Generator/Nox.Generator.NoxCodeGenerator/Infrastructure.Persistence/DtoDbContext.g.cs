// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Configuration;
using Nox.Infrastructure;
using Nox.Infrastructure.Persistence;

using TestWebApp.Application.Dto;
using DtoNameSpace = TestWebApp.Application.Dto;

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
    private readonly NoxCodeGenConventions _codeGenConventions;

    public DtoDbContext(
        DbContextOptions<DtoDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider,
        INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator,
        NoxCodeGenConventions codeGeneratorState
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;
        _codeGenConventions = codeGeneratorState;
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
        public DbSet<TestEntityLocalizationDto> TestEntityLocalizations { get; set; } = null!;
    public DbSet<TestEntityLocalizationLocalizedDto> TestEntityLocalizationsLocalized { get; set; } = null!;

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

        ConfigureAuditable(modelBuilder);

        if (_noxSolution.Domain != null)
        {            
            foreach (var entity in _codeGenConventions.Solution.Domain!.Entities)
            {
                // Ignore owned entities configuration as they are configured inside entity constructor
                if (entity.IsOwnedEntity)
                {
                    continue;
                }

                var dtoName = entity.Name + "Dto";

                var type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                    ?? throw new TypeNotFoundException(dtoName);

                _noxDtoDatabaseConfigurator.ConfigureDto(new EntityBuilderAdapter(modelBuilder.Entity(type)), entity);

                if (entity.IsLocalized)
                {
                    dtoName = NoxCodeGenConventions.GetEntityDtoNameForLocalizedType(entity.Name);
                    
                    type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                        ?? throw new TypeNotFoundException(dtoName);

                    _noxDtoDatabaseConfigurator.ConfigureLocalizedDto(new EntityBuilderAdapter(modelBuilder.Entity(type!)), entity);
                }
            }
        }
    }

private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestEntityZeroOrOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<SecondTestEntityZeroOrOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityWithNuidDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityOneOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<SecondTestEntityOneOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityZeroOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<SecondTestEntityZeroOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<ThirdTestEntityOneOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<ThirdTestEntityZeroOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<ThirdTestEntityExactlyOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<ThirdTestEntityZeroOrOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityExactlyOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<SecondTestEntityExactlyOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityZeroOrOneToZeroOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityZeroOrManyToZeroOrOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityExactlyOneToOneOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityOneOrManyToExactlyOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityExactlyOneToZeroOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityZeroOrManyToExactlyOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityOneOrManyToZeroOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityZeroOrManyToOneOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityZeroOrOneToOneOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityOneOrManyToZeroOrOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityZeroOrOneToExactlyOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityExactlyOneToZeroOrOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityOwnedRelationshipExactlyOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityOwnedRelationshipZeroOrOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityOwnedRelationshipOneOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityOwnedRelationshipZeroOrManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityTwoRelationshipsOneToOneDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityTwoRelationshipsManyToManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityTwoRelationshipsOneToManyDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityForTypesDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
        modelBuilder.Entity<TestEntityLocalizationDto>().HasQueryFilter(e => e.DeletedAtUtc == null);
    }
}