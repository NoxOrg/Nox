﻿// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Services;
using Nox.Domain;

using {{codeGenConventions.DtoNameSpace}};
using {{codeGenConventions.DomainNameSpace}};

namespace {{codeGenConventions.ApplicationNameSpace}}.Services;

internal partial class {{className}} : {{className}}Base
{
    public {{className}}(IRepository repository): base(repository)
    {
    
    }
}

internal abstract class {{className}}Base: I{{className}}
{
    private readonly Dictionary<string, (IQueryable Query, string KeyName)> _entityContextPerEntityName;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName;

    private readonly Dictionary<(string EntityPluralName, string NavigationName), bool> _isSingleRelationship;

    protected IRepository Repository { get; }

#region Constructor
    public  {{className}}Base(IRepository repository)
    {
        Repository = repository;

        _entityContextPerEntityName = new(StringComparer.OrdinalIgnoreCase)
        {
            {{- for entity in entities }}
            { "{{entity.PluralName}}", (Repository.Query<{{codeGenConventions.DomainNameSpace}}.{{entity.Name}}>(), "{{entity.Keys[0].Name}}") }{{if !for.last}},{{end}}
            {{- end }}
        };

        _navigationNameToEntityPluralName = new(StringComparer.OrdinalIgnoreCase)
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

        if (!TryParseKey(relationshipChain.EntityName, relationshipChain.EntityKey, out var aggregateParsedKey))
            return false;

        var query = context.Query.Where($"{context.KeyName} == @0", aggregateParsedKey);

        var previousAggregateRoot = relationshipChain.EntityName;
        var previousKeyName = context.KeyName;

        foreach (var property in relationshipChain.SortedNavigationProperties)
        {
            if (!_isSingleRelationship.TryGetValue((previousAggregateRoot, property.NavigationName), out var isSingle))
                return false;

            query = query.Select($"new ({previousKeyName}, {property.NavigationName})");
            if (isSingle)
                query = query.Select($"{property.NavigationName}");
            else        
                query = query.SelectMany($"{property.NavigationName}");

            if (!_navigationNameToEntityPluralName.TryGetValue(property.NavigationName, out var relatedPluralName))
                return false;

            if (!_entityContextPerEntityName.TryGetValue(relatedPluralName, out var relatedContext))
                return false;
            
            if (!TryParseKey(relatedPluralName, property.NavigationKey, out var navigationParsedKey))
                return false;

            query = query.Where($"{relatedContext.KeyName} == @0", navigationParsedKey);
            previousAggregateRoot = relatedPluralName;
            previousKeyName = relatedContext.KeyName;
        }

        return query.Select($"{previousKeyName}").Any();
    }

    private bool TryParseKey(string entityName, string key, out Nox.Types.INoxType parsedKey)
    {
        parsedKey = null;
        {{- for entity in entities }}
        {{- key = entity.Keys[0] }}
        {{- keySimpleType = (key.Type == "EntityId") ?  (SingleKeyPrimitiveTypeForEntity key.EntityIdTypeOptions.Entity) : (SinglePrimitiveTypeForKey key) }}
        if (entityName.Equals("{{entity.PluralName}}", StringComparison.OrdinalIgnoreCase))
        {
            {{- if keySimpleType == "System.String" }}
            parsedKey = {{entity.Name}}Metadata.Create{{key.Name}}(key);
            {{- else }}
            if (!{{keySimpleType}}.TryParse(key, out var value)) return false;
            parsedKey = {{entity.Name}}Metadata.Create{{key.Name}}(value);
            {{- end }}
            return true;
        }
        {{- end }}
        return false;
    }
}