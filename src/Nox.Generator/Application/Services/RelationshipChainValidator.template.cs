// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Services;

using {{codeGeneratorState.DtoNameSpace}};
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Services;

internal partial class {{className}} : {{className}}Base
{
    public {{className}}(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class {{className}}Base: I{{className}}
{
    private readonly Dictionary<string, (object DbSet, string KeyName)> _entityContextPerEntityName;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName;

    private readonly Dictionary<(string EntityPluralName, string NavigationName), bool> _isSingleRelationship;

    public DtoDbContext DataDbContext { get; }

#region Constructor
    public  {{className}}Base(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;

        _entityContextPerEntityName = new Dictionary<string, (object DbSet, string KeyName)>(StringComparer.OrdinalIgnoreCase)
        {
            {{- for entity in entities }}
            { "{{entity.PluralName}}", (DataDbContext.{{entity.PluralName}}, "{{entity.Keys[0].Name}}") }{{if !for.last}},{{end}}
            {{- end }}
        };

        _navigationNameToEntityPluralName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {{- for prop in navigationNameToEntityPluralName }}           
            { "{{prop.Key}}", "{{prop.Value}}" }{{if !for.last}},{{end}}
            {{- end }}
        };

        _isSingleRelationship = new()
        {
            {{- for prop in isSingleRelationship }}           
            { ("{{prop.Key.Item1}}", "{{prop.Key.Item2}}"), {{prop.Value}} }{{if !for.last}},{{end}}
            {{- end }}
        };
    }
#endregion Constructor

    public virtual bool IsValid(RelationshipChain relationshipChain)
    {
        if (!_entityContextPerEntityName.TryGetValue(relationshipChain.EntityName, out var context))
            return false;

        var aggregateDbSet = (IQueryable)context.DbSet;

        var query = aggregateDbSet.Where($"{context.KeyName} == {relationshipChain.EntityKey}");

        var previousAggregateRoot = relationshipChain.EntityName;

        foreach (var property in relationshipChain.SortedNavigationProperties)
        {
            if (!_isSingleRelationship.TryGetValue((previousAggregateRoot, property.NavigationName), out var isSingle))
                return false;

            if (isSingle)
                query = query.Select($"{property.NavigationName}");
            else        
                query = query.SelectMany($"{property.NavigationName}");

            if (!_navigationNameToEntityPluralName.TryGetValue(property.NavigationName, out var relatedPluralName))
                return false;

            if (!_entityContextPerEntityName.TryGetValue(relatedPluralName, out var relatedContext))
                return false;
            
            query = query.Where($"{relatedContext.KeyName} == {property.NavigationKey}");
            previousAggregateRoot = relatedPluralName;
        }

        return query.Any();
    }
}