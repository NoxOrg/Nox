// Generated
#nullable enable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Nox;
using Nox.Solution;
using Nox.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Configuration;
using Nox.Infrastructure;
using Nox.Infrastructure.Persistence;

using {{codeGeneratorState.RootNameSpace}}.Application.Dto;
using DtoNameSpace = {{codeGeneratorState.DtoNameSpace}};

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
    private readonly NoxCodeGenConventions _codeGenConventions;

    private readonly IEnumerable<IInterceptor> _interceptors;

    public DtoDbContext(
        DbContextOptions<DtoDbContext> options,
        NoxSolution noxSolution,
        INoxDatabaseProvider databaseProvider,
        INoxClientAssemblyProvider clientAssemblyProvider,
        INoxDtoDatabaseConfigurator noxDtoDatabaseConfigurator,
        NoxCodeGenConventions codeGeneratorState,
        IEnumerable<IInterceptor> interceptors) 
        : base(options)
    {
        _noxSolution = noxSolution;
        _dbProvider = databaseProvider;
        _clientAssemblyProvider = clientAssemblyProvider;
        _noxDtoDatabaseConfigurator = noxDtoDatabaseConfigurator;
        _codeGenConventions = codeGeneratorState;
        _interceptors = interceptors;
    }

    {{ for entity in entities }}
    public virtual DbSet<{{ entity.Name }}Dto> {{ entity.PluralName }} { get; set; } = null!;
    {{- end }}
    {{- for entity in entitiesToLocalize }}
    public virtual DbSet<{{GetEntityDtoNameForLocalizedType entity.Name}}> {{GetEntityNameForLocalizedType entity.PluralName}} { get; set; } = null!;
    {{- end }}

    {{- for entityAtt in enumerationAttributes #Setup Entity Enumerations}}
    {{- for enumAtt in entityAtt.Attributes}}
    public virtual DbSet<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}> {{enumAtt.DbSetNameForEnumeration}} { get; set; } = null!;
    {{- if enumAtt.Attribute.EnumerationTypeOptions.IsLocalized}}
    public virtual DbSet<DtoNameSpace.{{ enumAtt.EntityNameForLocalizedEnumeration}}> {{enumAtt.DbSetNameForLocalizedEnumeration}} { get; set; } = null!;
    {{- end }}
    {{- end }}
    {{- end }}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(optionsBuilder, "{{codeGeneratorState.RootNameSpace}}", _noxSolution.Infrastructure!.Persistence.DatabaseServer);
            optionsBuilder.AddInterceptors(_interceptors);
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
    {{- for entity in entities }}
    {{- if entity.Persistence?.IsAudited }}
        modelBuilder.Entity<{{entity.Name}}Dto>().HasQueryFilter(e => e.DeletedAtUtc == null);
    {{- end }}
    {{- end }}
    }
}