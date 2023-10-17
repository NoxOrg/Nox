// Generated

#nullable enable

using System.Reflection;
using System.Diagnostics;
using System.Net;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
{{- if  codeGeneratorState.Solution.Infrastructure?.Messaging != null}}
using MassTransit;
{{- end }}

using Nox;
using Nox.Abstractions;
using Nox.Domain;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Solution;
using Nox.Configuration;


using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.PersistenceNameSpace}};

internal partial class {{className}} : Nox.Infrastructure.Persistence.EntityDbContextBase
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public {{className}}(
            DbContextOptions<{{className}}> options,
            IPublisher publisher,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider,
            IUserProvider userProvider,
            ISystemProvider systemProvider
        ) : base(publisher, userProvider, systemProvider, options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
        }
{{ for entity in solution.Domain.Entities -}}
{{- if (!entity.IsOwnedEntity) }}
    public DbSet<{{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}> {{entity.PluralName}} { get; set; } = null!;
{{- end }}
{{ end }}

    {{- for entityAtt in enumerationAttributes #Setup Entity Enumerations}}
    {{- for enumAtt in entityAtt.Attributes}}
    public DbSet<{{codeGeneratorState.DomainNameSpace}}.{{entityAtt.Entity.Name}}{{enumAtt.Name}}> {{Pluralize (entityAtt.Entity.Name)}}{{Pluralize (enumAtt.Name)}} { get; set; } = null!;        
        {{- if enumAtt.EnumerationTypeOptions.IsLocalized}}
    public DbSet<{{codeGeneratorState.DomainNameSpace}}.{{entityAtt.Entity.Name}}{{enumAtt.Name}}Localized> {{Pluralize (entityAtt.Entity.Name)}}{{Pluralize (enumAtt.Name)}}Localized { get; set; } = null!;                
        {{- end }}
    {{- end }}
    {{- end }}

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

        ConfigureAuditable(modelBuilder);


        var codeGeneratorState = new NoxSolutionCodeGeneratorState(_noxSolution, _clientAssemblyProvider.ClientAssembly);

        {{- if  codeGeneratorState.Solution.Infrastructure?.Messaging != null}}
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
        {{- end }}
        foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
        {
            Console.WriteLine($"{{className}} Configure database for Entity {entity.Name}");

            // Ignore owned entities configuration as they are configured inside entity constructor
            if (entity.IsOwnedEntity)
            {
                continue;
            }

            var type = codeGeneratorState.GetEntityType(entity.Name);
            if (type != null)
            {
                ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(codeGeneratorState, new EntityBuilderAdapter(modelBuilder.Entity(type)), entity);
            }
        }

        modelBuilder.ForEntitiesOfType<IEntityConcurrent>(
            builder => builder.Property(nameof(IEntityConcurrent.Etag)).IsConcurrencyToken());         
        
        {{- for entityAtt in enumerationAttributes #Setup Entity Enumerations}}
        {{- for enumAtt in entityAtt.Attributes}}
            ConfigureEnumeration(modelBuilder.Entity("{{codeGeneratorState.DomainNameSpace}}.{{entityAtt.Entity.Name}}{{enumAtt.Name}}"));
            {{- if enumAtt.EnumerationTypeOptions.IsLocalized}}
            var enumLocalizedType = codeGeneratorState.GetType("{{codeGeneratorState.DomainNameSpace}}.{{entityAtt.Entity.Name}}{{enumAtt.Name}}Localized")!;
            var enumType = codeGeneratorState.GetType("{{codeGeneratorState.DomainNameSpace}}.{{entityAtt.Entity.Name}}{{enumAtt.Name}}")!;
        ConfigureEnumerationLocalized(modelBuilder.Entity(enumLocalizedType), enumType, enumLocalizedType);
            {{- end }}
        {{- end }}
        {{- end }}
    }

    private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
    {{- for entity in solution.Domain.Entities }}
    {{- if entity.Persistence?.IsAudited }}
        modelBuilder.Entity<{{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}>().HasQueryFilter(p => p.DeletedAtUtc == null);
    {{- end }}
    {{- end }}
    }
}