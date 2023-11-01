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
using Nox.Infrastructure;

using DomainNameSpace = {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};

namespace {{codeGeneratorState.PersistenceNameSpace}};

internal partial class AppDbContext : Nox.Infrastructure.Persistence.EntityDbContextBase
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    private readonly NoxCodeGenConventions _codeGenConventions;

    public AppDbContext(
            DbContextOptions<AppDbContext> options,
            IPublisher publisher,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider,
            IUserProvider userProvider,
            ISystemProvider systemProvider,
            NoxCodeGenConventions codeGeneratorState
        ) : base(publisher, userProvider, systemProvider, options)
        {
            _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
            _codeGenConventions = codeGeneratorState;
        }
    {{ for entity in solution.Domain.Entities -}}
    {{- if (!entity.IsOwnedEntity) }}
    public DbSet<{{codeGeneratorState.DomainNameSpace}}.{{entity.Name}}> {{entity.PluralName}} { get; set; } = null!;
    {{- end }}
    {{- end }}
    {{ for entity in entitiesToLocalize -}}
    public DbSet<{{codeGeneratorState.DomainNameSpace}}.{{GetEntityNameForLocalizedType entity.Name}}> {{GetEntityNameForLocalizedType entity.PluralName}} { get; set; } = null!;
    {{- end }}

    {{- for entityAtt in enumerationAttributes #Setup Entity Enumerations}}
    {{- for enumAtt in entityAtt.Attributes}}
    public DbSet<DomainNameSpace.{{enumAtt.EntityNameForEnumeration}}> {{enumAtt.DbSetNameForEnumeration}} { get; set; } = null!;
    {{- if enumAtt.Attribute.EnumerationTypeOptions.IsLocalized}}
    public DbSet<DomainNameSpace.{{ enumAtt.EntityNameForLocalizedEnumeration}}> {{enumAtt.DbSetNameForLocalizedEnumeration}} { get; set; } = null!;
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

        {{- if  codeGeneratorState.Solution.Infrastructure?.Messaging != null}}
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
        {{- end }}
        foreach (var entity in _noxSolution.Domain!.Entities)
        {
            Console.WriteLine($"{{className}} Configure database for Entity {entity.Name}");
            ConfigureEnumeratedAttributes(modelBuilder, entity);

            // Ignore owned entities configuration as they are configured inside entity constructor
            if (entity.IsOwnedEntity)
            {
                continue;
            }

            var type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityTypeFullName(entity.Name));
            ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(new EntityBuilderAdapter(modelBuilder.Entity(type!)), entity);

            if (entity.IsLocalized)
            {
                type = _clientAssemblyProvider.GetType(_codeGenConventions.GetEntityTypeFullName(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name)));

                ((INoxDatabaseConfigurator)_dbProvider).ConfigureLocalizedEntity(new EntityBuilderAdapter(modelBuilder.Entity(type!)), entity);
            }
        }

        modelBuilder.ForEntitiesOfType<IEntityConcurrent>(
            builder => builder.Property(nameof(IEntityConcurrent.Etag)).IsConcurrencyToken());
    }
    
    private void ConfigureEnumeratedAttributes(ModelBuilder modelBuilder, Entity entity)
    {
        foreach(var enumAttribute in entity.Attributes.Where(attribute => attribute.Type == NoxType.Enumeration))
            {
                ConfigureEnumeration(modelBuilder.Entity($"{{codeGeneratorState.DomainNameSpace}}.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}"), enumAttribute.EnumerationTypeOptions!);
                if (enumAttribute.EnumerationTypeOptions!.IsLocalized)
                {
                    var enumLocalizedType = _clientAssemblyProvider.GetType($"{{codeGeneratorState.DomainNameSpace}}.{_codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, enumAttribute.Name)}")!;
                    var enumType = _clientAssemblyProvider.GetType($"{{codeGeneratorState.DomainNameSpace}}.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}")!;
                    ConfigureEnumerationLocalized(modelBuilder.Entity(enumLocalizedType), enumType, enumLocalizedType, enumAttribute.EnumerationTypeOptions!, _noxSolution.Application?.Localization?.DefaultCulture ?? "en-US"); // TODO check if it is not defined if we want to use en-US or just skip seeding localized data
                }
            }
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