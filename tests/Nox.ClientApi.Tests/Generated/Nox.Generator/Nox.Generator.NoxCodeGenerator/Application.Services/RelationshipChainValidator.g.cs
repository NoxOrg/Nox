// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Services;
using Nox.Domain;

using ClientApi.Application.Dto;
using ClientApi.Domain;

namespace ClientApi.Application.Services;

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
            { "Countries", (Repository.Query<ClientApi.Domain.Country>(), "Id") },
            { "RatingPrograms", (Repository.Query<ClientApi.Domain.RatingProgram>(), "StoreId") },
            { "CountryQualityOfLifeIndices", (Repository.Query<ClientApi.Domain.CountryQualityOfLifeIndex>(), "CountryId") },
            { "Stores", (Repository.Query<ClientApi.Domain.Store>(), "Id") },
            { "Workplaces", (Repository.Query<ClientApi.Domain.Workplace>(), "Id") },
            { "StoreOwners", (Repository.Query<ClientApi.Domain.StoreOwner>(), "Id") },
            { "StoreLicenses", (Repository.Query<ClientApi.Domain.StoreLicense>(), "Id") },
            { "Currencies", (Repository.Query<ClientApi.Domain.Currency>(), "Id") },
            { "Tenants", (Repository.Query<ClientApi.Domain.Tenant>(), "Id") },
            { "Clients", (Repository.Query<ClientApi.Domain.Client>(), "Id") },
            { "ReferenceNumberEntities", (Repository.Query<ClientApi.Domain.ReferenceNumberEntity>(), "Id") },
            { "People", (Repository.Query<ClientApi.Domain.Person>(), "Id") }
        };

        _navigationNameToEntityPluralName = new(StringComparer.OrdinalIgnoreCase)
        {           
            { "workplaces", "workplaces" },           
            { "stores", "stores" },           
            { "country", "countries" },           
            { "storeowner", "storeowners" },           
            { "storelicense", "storelicenses" },           
            { "clients", "clients" },           
            { "parentofstore", "stores" },           
            { "franchisesofstore", "stores" },           
            { "tenants", "tenants" },           
            { "store", "stores" },           
            { "defaultcurrency", "currencies" },           
            { "soldincurrency", "currencies" },           
            { "storelicensedefault", "storelicenses" },           
            { "storelicensesoldin", "storelicenses" }
        };

        _isSingleRelationship = new()
        {           
            { ("countries", "workplaces"), false },           
            { ("countries", "stores"), false },           
            { ("stores", "country"), true },           
            { ("stores", "storeowner"), true },           
            { ("stores", "storelicense"), true },           
            { ("stores", "clients"), false },           
            { ("stores", "parentofstore"), true },           
            { ("stores", "franchisesofstore"), false },           
            { ("workplaces", "country"), true },           
            { ("workplaces", "tenants"), false },           
            { ("storeowners", "stores"), false },           
            { ("storelicenses", "store"), true },           
            { ("storelicenses", "defaultcurrency"), true },           
            { ("storelicenses", "soldincurrency"), true },           
            { ("currencies", "storelicensedefault"), false },           
            { ("currencies", "storelicensesoldin"), false },           
            { ("tenants", "workplaces"), false },           
            { ("clients", "stores"), false }
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
        if (entityName.Equals("Countries", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int64.TryParse(key, out var value)) return false;
            parsedKey = CountryMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("RatingPrograms", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = RatingProgramMetadata.CreateStoreId(value);
            return true;
        }
        if (entityName.Equals("CountryQualityOfLifeIndices", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int64.TryParse(key, out var value)) return false;
            parsedKey = CountryQualityOfLifeIndexMetadata.CreateCountryId(value);
            return true;
        }
        if (entityName.Equals("Stores", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = StoreMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("Workplaces", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int64.TryParse(key, out var value)) return false;
            parsedKey = WorkplaceMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("StoreOwners", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = StoreOwnerMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("StoreLicenses", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int64.TryParse(key, out var value)) return false;
            parsedKey = StoreLicenseMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("Currencies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = CurrencyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("Tenants", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.UInt32.TryParse(key, out var value)) return false;
            parsedKey = TenantMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("Clients", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = ClientMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("ReferenceNumberEntities", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = ReferenceNumberEntityMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("People", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = PersonMetadata.CreateId(value);
            return true;
        }
        return false;
    }
}