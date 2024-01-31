// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Services;
using Nox.Domain;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Domain;

namespace CryptocashIntegration.Application.Services;

internal partial class RelationshipChainValidator : RelationshipChainValidatorBase
{
    public RelationshipChainValidator(IRepository repository): base(repository)
    {
    
    }
}

internal abstract class RelationshipChainValidatorBase: IRelationshipChainValidator
{
    private readonly Dictionary<string, (IQueryable Query, string KeyName)> _entityContextPerEntityName;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName;

    private readonly Dictionary<(string EntityPluralName, string NavigationName), bool> _isSingleRelationship;

    protected IRepository Repository { get; }

#region Constructor
    public  RelationshipChainValidatorBase(IRepository repository)
    {
        Repository = repository;

        _entityContextPerEntityName = new(StringComparer.OrdinalIgnoreCase)
        {
            { "CountryQueryToTables", (Repository.Query<CountryQueryToTable>(), "Id") },
            { "CountryQueryToCustomTables", (Repository.Query<CountryQueryToCustomTable>(), "Id") },
            { "CountryJsonToTables", (Repository.Query<CountryJsonToTable>(), "Id") }
        };

        _navigationNameToEntityPluralName = new(StringComparer.OrdinalIgnoreCase)
        {
        };

        _isSingleRelationship = new()
        {
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
        if (entityName.Equals("CountryQueryToTables", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int32.TryParse(key, out var value)) return false;
            parsedKey = CountryQueryToTableMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("CountryQueryToCustomTables", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int32.TryParse(key, out var value)) return false;
            parsedKey = CountryQueryToCustomTableMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("CountryJsonToTables", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int32.TryParse(key, out var value)) return false;
            parsedKey = CountryJsonToTableMetadata.CreateId(value);
            return true;
        }
        return false;
    }
}