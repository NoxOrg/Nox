// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using {{RootNameSpace}}.Application.Dto;

namespace {{RootNameSpace}}.Infrastructure.Persistence;

public class DtoDbContext : DbContext
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

    {{ for entity in entities }}
    public DbSet<{{ entity.Name }}Dto> {{ entity.PluralName }} { get; set; } = null!;
    {{ end }}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "{{RootNameSpace}}", _noxSolution.Infrastructure!.Persistence.DatabaseServer);
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