// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Extensions;
using Nox.Types.EntityFramework.Abstractions;
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
    
        public virtual DbSet<TestEntityZeroOrOneDto> TestEntityZeroOrOnes { get; set; } = null!;
        public virtual DbSet<SecondTestEntityZeroOrOneDto> SecondTestEntityZeroOrOnes { get; set; } = null!;
        public virtual DbSet<TestEntityWithNuidDto> TestEntityWithNuids { get; set; } = null!;
        public virtual DbSet<TestEntityOneOrManyDto> TestEntityOneOrManies { get; set; } = null!;
        public virtual DbSet<SecondTestEntityOneOrManyDto> SecondTestEntityOneOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityZeroOrManyDto> TestEntityZeroOrManies { get; set; } = null!;
        public virtual DbSet<SecondTestEntityZeroOrManyDto> SecondTestEntityZeroOrManies { get; set; } = null!;
        public virtual DbSet<ThirdTestEntityOneOrManyDto> ThirdTestEntityOneOrManies { get; set; } = null!;
        public virtual DbSet<ThirdTestEntityZeroOrManyDto> ThirdTestEntityZeroOrManies { get; set; } = null!;
        public virtual DbSet<ThirdTestEntityExactlyOneDto> ThirdTestEntityExactlyOnes { get; set; } = null!;
        public virtual DbSet<ThirdTestEntityZeroOrOneDto> ThirdTestEntityZeroOrOnes { get; set; } = null!;
        public virtual DbSet<TestEntityExactlyOneDto> TestEntityExactlyOnes { get; set; } = null!;
        public virtual DbSet<SecondTestEntityExactlyOneDto> SecondTestEntityExactlyOnes { get; set; } = null!;
        public virtual DbSet<TestEntityZeroOrOneToZeroOrManyDto> TestEntityZeroOrOneToZeroOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityZeroOrManyToZeroOrOneDto> TestEntityZeroOrManyToZeroOrOnes { get; set; } = null!;
        public virtual DbSet<TestEntityExactlyOneToOneOrManyDto> TestEntityExactlyOneToOneOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityOneOrManyToExactlyOneDto> TestEntityOneOrManyToExactlyOnes { get; set; } = null!;
        public virtual DbSet<TestEntityExactlyOneToZeroOrManyDto> TestEntityExactlyOneToZeroOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityZeroOrManyToExactlyOneDto> TestEntityZeroOrManyToExactlyOnes { get; set; } = null!;
        public virtual DbSet<TestEntityOneOrManyToZeroOrManyDto> TestEntityOneOrManyToZeroOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityZeroOrManyToOneOrManyDto> TestEntityZeroOrManyToOneOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityZeroOrOneToOneOrManyDto> TestEntityZeroOrOneToOneOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityOneOrManyToZeroOrOneDto> TestEntityOneOrManyToZeroOrOnes { get; set; } = null!;
        public virtual DbSet<TestEntityZeroOrOneToExactlyOneDto> TestEntityZeroOrOneToExactlyOnes { get; set; } = null!;
        public virtual DbSet<TestEntityExactlyOneToZeroOrOneDto> TestEntityExactlyOneToZeroOrOnes { get; set; } = null!;
        public virtual DbSet<TestEntityOwnedRelationshipExactlyOneDto> TestEntityOwnedRelationshipExactlyOnes { get; set; } = null!;
        public virtual DbSet<TestEntityOwnedRelationshipZeroOrOneDto> TestEntityOwnedRelationshipZeroOrOnes { get; set; } = null!;
        public virtual DbSet<TestEntityOwnedRelationshipOneOrManyDto> TestEntityOwnedRelationshipOneOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityOwnedRelationshipZeroOrManyDto> TestEntityOwnedRelationshipZeroOrManies { get; set; } = null!;
        public virtual DbSet<TestEntityTwoRelationshipsOneToOneDto> TestEntityTwoRelationshipsOneToOnes { get; set; } = null!;
        public virtual DbSet<SecondTestEntityTwoRelationshipsOneToOneDto> SecondTestEntityTwoRelationshipsOneToOnes { get; set; } = null!;
        public virtual DbSet<TestEntityTwoRelationshipsManyToManyDto> TestEntityTwoRelationshipsManyToManies { get; set; } = null!;
        public virtual DbSet<SecondTestEntityTwoRelationshipsManyToManyDto> SecondTestEntityTwoRelationshipsManyToManies { get; set; } = null!;
        public virtual DbSet<TestEntityTwoRelationshipsOneToManyDto> TestEntityTwoRelationshipsOneToManies { get; set; } = null!;
        public virtual DbSet<SecondTestEntityTwoRelationshipsOneToManyDto> SecondTestEntityTwoRelationshipsOneToManies { get; set; } = null!;
        public virtual DbSet<TestEntityForTypesDto> TestEntityForTypes { get; set; } = null!;
        public virtual DbSet<TestEntityForUniqueConstraintsDto> TestEntityForUniqueConstraints { get; set; } = null!;
        public virtual DbSet<EntityUniqueConstraintsWithForeignKeyDto> EntityUniqueConstraintsWithForeignKeys { get; set; } = null!;
        public virtual DbSet<EntityUniqueConstraintsRelatedForeignKeyDto> EntityUniqueConstraintsRelatedForeignKeys { get; set; } = null!;
        public virtual DbSet<TestEntityLocalizationDto> TestEntityLocalizations { get; set; } = null!;
        public virtual DbSet<TestEntityForAutoNumberUsagesDto> TestEntityForAutoNumberUsages { get; set; } = null!;
    public virtual DbSet<TestEntityLocalizationLocalizedDto> TestEntityLocalizationsLocalized { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto> TestEntityForTypesEnumerationTestFields { get; set; } = null!;
    public virtual DbSet<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto> TestEntityForTypesEnumerationTestFieldsLocalized { get; set; } = null!;

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
                var dtoName = entity.Name + "Dto";

                var type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                    ?? throw new TypeNotFoundException(dtoName);

                _noxDtoDatabaseConfigurator.ConfigureDto(modelBuilder.Entity(type).ToTable(entity.Persistence.TableName), entity);

                if (entity.IsLocalized)
                {
                    dtoName = NoxCodeGenConventions.GetEntityDtoNameForLocalizedType(entity.Name);
                    
                    type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityDtoTypeFullName(dtoName))
                        ?? throw new TypeNotFoundException(dtoName);

                    _noxDtoDatabaseConfigurator.ConfigureLocalizedDto(modelBuilder.Entity(type!), entity);
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