// Generated

#nullable enable

using System.Reflection;
using System.Diagnostics;
using System.Net;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
{{- if  codeGenConventions.Solution.Infrastructure?.Messaging != null}}
using MassTransit;
{{- end }}

using Nox;
using Nox.Abstractions;
using Nox.Domain;
using Nox.Exceptions;
using Nox.Extensions;
using Nox.Types;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Solution;
using Nox.Configuration;
using Nox.Infrastructure;

using DomainNameSpace = {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.DomainNameSpace}};

namespace {{codeGenConventions.PersistenceNameSpace}};

internal partial class AppDbContext: AppDbContextBase
{
    public AppDbContext(
           DbContextOptions<AppDbContext> options,
           IPublisher publisher,
           NoxSolution noxSolution,
           INoxDatabaseProvider databaseProvider,
           INoxClientAssemblyProvider clientAssemblyProvider,
           IUserProvider userProvider,
           ISystemProvider systemProvider,
           NoxCodeGenConventions codeGenConventions,
           ILogger<AppDbContext> logger
       ) : base(
           options,
           publisher,
           noxSolution,
           databaseProvider,
           clientAssemblyProvider,
           userProvider,
           systemProvider,
           codeGenConventions,
           logger)
    {}
}

internal abstract partial class AppDbContextBase : Nox.Infrastructure.Persistence.EntityDbContextBase, Nox.Domain.IRepository
{
    private readonly NoxSolution _noxSolution;
    private readonly INoxDatabaseProvider _dbProvider;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;
    private readonly NoxCodeGenConventions _codeGenConventions;

    public AppDbContextBase(
            DbContextOptions<AppDbContext> options,
            IPublisher publisher,
            NoxSolution noxSolution,
            INoxDatabaseProvider databaseProvider,
            INoxClientAssemblyProvider clientAssemblyProvider,
            IUserProvider userProvider,
            ISystemProvider systemProvider,
            NoxCodeGenConventions codeGenConventions,
            ILogger<AppDbContext> logger
        ) : base(publisher, userProvider, systemProvider, databaseProvider, logger, options)
    {
        _noxSolution = noxSolution;
            _dbProvider = databaseProvider;
            _clientAssemblyProvider = clientAssemblyProvider;
            _codeGenConventions = codeGenConventions;
        }
    {{ for entity in solution.Domain.Entities -}}
    {{- if (!entity.IsOwnedEntity) }}
    public virtual DbSet<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}> {{entity.PluralName}} { get; set; } = null!;
    {{- end }}
    {{- end }}
    {{ for entity in entitiesToLocalize -}}
    public virtual DbSet<{{codeGenConventions.DomainNameSpace}}.{{GetEntityNameForLocalizedType entity.Name}}> {{GetEntityNameForLocalizedType entity.PluralName}} { get; set; } = null!;
    {{- end }}

    {{- for entityAtt in enumerationAttributes #Setup Entity Enumerations}}
    {{- for enumAtt in entityAtt.Attributes}}
    public virtual DbSet<DomainNameSpace.{{enumAtt.EntityNameForEnumeration}}> {{enumAtt.DbSetNameForEnumeration}} { get; set; } = null!;
    {{- if enumAtt.Attribute.EnumerationTypeOptions.IsLocalized}}
    public virtual DbSet<DomainNameSpace.{{ enumAtt.EntityNameForLocalizedEnumeration}}> {{enumAtt.DbSetNameForLocalizedEnumeration}} { get; set; } = null!;
    {{- end }}
    {{- end }}
    {{- end }}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (_noxSolution.Infrastructure is { Persistence.DatabaseServer: not null })
        {
            _dbProvider.ConfigureDbContext(
                optionsBuilder,
                "{{solution.Name}}",
                _noxSolution.Infrastructure!.Persistence.DatabaseServer,
                _clientAssemblyProvider.ClientAssembly.GetName().Name);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureAuditable(modelBuilder);

        {{- if  codeGenConventions.Solution.Infrastructure?.Messaging != null}}
        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
        {{- end }}
        foreach (var entity in _noxSolution.Domain!.Entities)
        {
#if DEBUG
            Console.WriteLine($"{{className}} Configure database for Entity {entity.Name}");
#endif
            ConfigureEnumeratedAttributes(modelBuilder, entity);

            var type = _clientAssemblyProvider.GetEntityType(_codeGenConventions.GetEntityTypeFullName(entity.Name));
            ((INoxDatabaseConfigurator)_dbProvider).ConfigureEntity(modelBuilder, modelBuilder.Entity(type!).ToTable(entity.Persistence.TableName), entity, _clientAssemblyProvider.DomainAssembly);

            if (entity.IsLocalized)
            {
                type = _clientAssemblyProvider.GetEntityType(_codeGenConventions.GetEntityTypeFullName(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name)));

                ((INoxDatabaseConfigurator)_dbProvider).ConfigureLocalizedEntity(modelBuilder, modelBuilder.Entity(type!), entity);
            }
        }

        modelBuilder.ForEntitiesOfType<IEtag>(
            builder => builder.Property(nameof(IEtag.Etag)).IsConcurrencyToken());
    }
    
    private void ConfigureEnumeratedAttributes(ModelBuilder modelBuilder, Entity entity)
    {
        foreach(var enumAttribute in entity.Attributes.Where(attribute => attribute.Type == NoxType.Enumeration))
            {
                ConfigureEnumeration(modelBuilder.Entity($"{{codeGenConventions.DomainNameSpace}}.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}"), enumAttribute.EnumerationTypeOptions!);
                if (enumAttribute.EnumerationTypeOptions!.IsLocalized)
                {
                    var enumLocalizedType = _clientAssemblyProvider.GetEntityType($"{{codeGenConventions.DomainNameSpace}}.{_codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, enumAttribute.Name)}")!;
                    var enumType = _clientAssemblyProvider.GetEntityType($"{{codeGenConventions.DomainNameSpace}}.{_codeGenConventions.GetEntityNameForEnumeration(entity.Name, enumAttribute.Name)}")!;
                    ConfigureEnumerationLocalized(modelBuilder.Entity(enumLocalizedType), enumType, enumLocalizedType, enumAttribute.EnumerationTypeOptions!, _noxSolution.Application!.Localization!.DefaultCulture);
                }
            }
    }

    private void ConfigureAuditable(ModelBuilder modelBuilder)
    {
    {{- for entity in solution.Domain.Entities }}
    {{- if entity.Persistence?.IsAudited }}
        modelBuilder.Entity<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}>().HasQueryFilter(p => p.DeletedAtUtc == null);
    {{- end }}
    {{- end }}
    }
}