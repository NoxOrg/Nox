// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Solution;
using Nox.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Configuration;
using Nox.Infrastructure;

using {{codeGeneratorState.RootNameSpace}}.Application.Dto;

namespace {{codeGeneratorState.RootNameSpace}}.Infrastructure.Persistence;

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
    private readonly NoxCodeGenConventions _codeGeneratorState;

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
        _codeGeneratorState = codeGeneratorState;
    }

    {{ for entity in entities }}
    public DbSet<{{ entity.Name }}Dto> {{ entity.PluralName }} { get; set; } = null!;
    {{ end }}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "{{codeGeneratorState.RootNameSpace}}", _noxSolution.Infrastructure!.Persistence.DatabaseServer);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureAuditable(modelBuilder);

        if (_noxSolution.Domain != null)
        {            
            foreach (var entity in _codeGeneratorState.Solution.Domain!.Entities)
            {
                // Ignore owned entities configuration as they are configured inside entity constructor
                if (entity.IsOwnedEntity)
                {
                    continue;
                }

                var type = _clientAssemblyProvider.GetType(_codeGeneratorState.GetEntityDtoTypeFullName(entity.Name + "Dto"));
                if (type != null)
                {
                    _noxDtoDatabaseConfigurator.ConfigureDto(
                        new Nox.Types.EntityFramework.EntityBuilderAdapter.EntityBuilderAdapter(modelBuilder.Entity(type)),
                        entity);
                }
                else
                {
                    throw new Exception($"Could not resolve type for {entity.Name}Dto");
                }
            }
        }
    }

    private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
    {{- for entity in entities }}
    {{- if entity.Persistence?.IsAudited }}
        modelBuilder.Entity<{{entity.Name}}Dto>().HasQueryFilter(e => e.DeletedAtUtc == null);
    {{- end }}
    {{- end }}
    }
}