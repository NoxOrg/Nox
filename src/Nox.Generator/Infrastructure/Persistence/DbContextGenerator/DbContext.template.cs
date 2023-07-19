﻿// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types.EntityFramework.Abstractions;
using System.Reflection;
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.PersistenceNameSpace}};

public partial class {{className}} : DbContext
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly Assembly _clientAssembly;

    public {{className}}(
            DbContextOptions<{{className}}> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider
        ) : this(options, noxSolution, databaseProvider, Assembly.GetEntryAssembly()!) { }

    public {{className}}(
            DbContextOptions<{{className}}> options,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            Assembly clientAssembly
        ) : base(options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssembly = clientAssembly;
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
            var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssembly);
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