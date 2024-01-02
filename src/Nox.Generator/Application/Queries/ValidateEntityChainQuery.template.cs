// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Queries;

using {{codeGeneratorState.DtoNameSpace}};
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationQueriesNameSpace}};

internal partial class {{className}}Handler : {{className}}HandlerBase
{
    public {{className}}Handler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class {{className}}HandlerBase: IValidateEntityChainQueryHandler
{
    private readonly Dictionary<string, (object DbSet, string KeyName)> _entityContextPerEntityName;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName;

    private readonly Dictionary<(string EntityPluralName, string NavigationName), bool> _isSingleRelationship;

    public DtoDbContext DataDbContext { get; }

#region Constructor
    public  {{className}}HandlerBase(DtoDbContext dataDbContext)
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

    public virtual bool Handle({{className}} request)
    {
        if (!_entityContextPerEntityName.TryGetValue(request.EntityName, out var context))
            return false;

        var aggregateDbSet = (IQueryable)context.DbSet;

        var query = aggregateDbSet.Where($"{context.KeyName} == {request.EntityKey}");

        var previousAggregateRoot = request.EntityName;

        foreach (var property in request.NavigationProperties)
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

        return query.Count() > 0;
    }
}