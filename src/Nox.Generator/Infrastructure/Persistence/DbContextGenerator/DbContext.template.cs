// Generated

#nullable enable

using Nox;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Diagnostics;
using {{codeGeneratorState.DomainNameSpace}};
{{ if solution.Application != null &&  solution.Application.Localization != null }}
using Nox.Localization;
{{ end }}

namespace {{codeGeneratorState.PersistenceNameSpace}};

public partial class {{className}} : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public {{className}}(
            DbContextOptions<{{className}}> options,
            NoxSolution noxSolution,
            IEnumerable<INoxDatabaseProvider> databaseProviders,
            INoxClientAssemblyProvider clientAssemblyProvider
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProviders.Single(p => p.StoreType == NoxDataStoreType.EntityStore);
            _clientAssemblyProvider = clientAssemblyProvider;
        }

{{ for entity in solution.Domain.Entities }}
    public DbSet<{{entity.Name}}> {{entity.PluralName}} { get; set; } = null!;
{{ end }}

{{ if solution.Application != null &&  solution.Application.Localization != null }}
    // Schema: 'l10n'
    public DbSet<Translation> Translations { get; set; } = default!;
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
{{ if solution.Application != null &&  solution.Application.Localization != null }}
        ConfigureLocalization(modelBuilder); 
{{ end }}
        
        base.OnModelCreating(modelBuilder);
        if (_noxSolution.Domain != null)
        {
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);
            foreach (var entity in _noxSolution.Domain.Entities)
            {
                Console.WriteLine($"{{className}} Configure database for Entity {entity.Name}");
                var type = codeGeneratorState.GetEntityType(entity.Name);
                if (type != null)
                {
                    ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, modelBuilder.Entity(type), entity, _noxSolution.GetRelationshipsToCreate(codeGeneratorState.GetEntityType, entity));
                }
            }
        }
    }

{{ if solution.Application != null &&  solution.Application.Localization != null }}
    private void ConfigureLocalization(ModelBuilder builder)
    {
        builder.Entity<Translation>().ToTable("Translations", "l10n");
        builder.Entity<Translation>().HasKey(m => m.Id);
        builder.Entity<Translation>().HasAlternateKey(c => new { c.Key, c.CultureCode, c.ResourceKey });
    }
{{ end }}
}