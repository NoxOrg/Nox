// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Generator.Common;
using Nox.Types.EntityFramework.Abstractions;
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.PersistenceNameSpace}};

public partial class {{className}} : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    
    public {{className}}(
        DbContextOptions<{{className}}> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
    }

{{ for entity in solution.Domain.Entities }}
    public DbSet<{{entity.Name}}> {{entity.PluralName}} { get; set; } = null!;
{{ end }}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "{{solution.Name}}", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
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