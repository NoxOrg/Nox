// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Services;

using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Services;

internal partial class RelationshipChainValidator : RelationshipChainValidatorBase
{
    public RelationshipChainValidator(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class RelationshipChainValidatorBase: IRelationshipChainValidator
{
    private readonly Dictionary<string, (object DbSet, string KeyName)> _entityContextPerEntityName;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName;

    private readonly Dictionary<(string EntityPluralName, string NavigationName), bool> _isSingleRelationship;

    public DtoDbContext DataDbContext { get; }

#region Constructor
    public  RelationshipChainValidatorBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;

        _entityContextPerEntityName = new Dictionary<string, (object DbSet, string KeyName)>(StringComparer.OrdinalIgnoreCase)
        {
            { "Countries", (DataDbContext.Countries, "Id") },
            { "RatingPrograms", (DataDbContext.RatingPrograms, "StoreId") },
            { "CountryQualityOfLifeIndices", (DataDbContext.CountryQualityOfLifeIndices, "CountryId") },
            { "Stores", (DataDbContext.Stores, "Id") },
            { "Workplaces", (DataDbContext.Workplaces, "Id") },
            { "StoreOwners", (DataDbContext.StoreOwners, "Id") },
            { "StoreLicenses", (DataDbContext.StoreLicenses, "Id") },
            { "Currencies", (DataDbContext.Currencies, "Id") },
            { "Tenants", (DataDbContext.Tenants, "Id") },
            { "Clients", (DataDbContext.Clients, "Id") },
            { "ReferenceNumberEntities", (DataDbContext.ReferenceNumberEntities, "Id") }
        };

        _navigationNameToEntityPluralName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {           
            { "workplaces", "workplaces" },           
            { "storeowner", "storeowners" },           
            { "storelicense", "storelicenses" },           
            { "clients", "clients" },           
            { "country", "countries" },           
            { "tenants", "tenants" },           
            { "stores", "stores" },           
            { "store", "stores" },           
            { "defaultcurrency", "currencies" },           
            { "soldincurrency", "currencies" },           
            { "storelicensedefault", "storelicenses" },           
            { "storelicensesoldin", "storelicenses" }
        };

        _isSingleRelationship = new()
        {           
            { ("countries", "workplaces"), false },           
            { ("stores", "storeowner"), true },           
            { ("stores", "storelicense"), true },           
            { ("stores", "clients"), false },           
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