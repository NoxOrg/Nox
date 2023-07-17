// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Generator.Common;
using Nox.Types.EntityFramework.Abstractions;
using {{domainNamespace}};

namespace {{persistenceNamespace}};

public partial class {{dbContextName}} : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    
    public {{dbContextName}}(
        DbContextOptions<{{dbContextName}}> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider
    ) : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
    }

{{ for dbSet in dbSets }}
    public DbSet<{{dbSet.Name}}> {{dbSet.PropertyName}} { get; set; } = null!;
{{ end }}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "{{solutionName}}", _noxSolution.Infrastructure!.Persistence.DatabaseServer); 
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
                var type = Type.GetType("{{domainNamespace}}." + entity.Name);
                
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity);
                }
            }
        }
    }
}