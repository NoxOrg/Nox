// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Queries;

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Infrastructure.Persistence;

namespace CryptocashIntegration.Application.Queries;

internal partial class ValidateEntityChainQueryHandler : ValidateEntityChainQueryHandlerBase
{
    public ValidateEntityChainQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class ValidateEntityChainQueryHandlerBase: IValidateEntityChainQueryHandler
{
    private readonly Dictionary<string, (object DbSet, string KeyName)> _entityContextPerEntityName;

    private readonly Dictionary<string, string> _navigationNameToEntityPluralName;

    private readonly Dictionary<(string EntityPluralName, string NavigationName), bool> _isSingleRelationship;

    public DtoDbContext DataDbContext { get; }

#region Constructor
    public  ValidateEntityChainQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;

        _entityContextPerEntityName = new Dictionary<string, (object DbSet, string KeyName)>(StringComparer.OrdinalIgnoreCase)
        {
            { "CountryQueryToTables", (DataDbContext.CountryQueryToTables, "Id") },
            { "CountryQueryToCustomTables", (DataDbContext.CountryQueryToCustomTables, "Id") },
            { "CountryJsonToTables", (DataDbContext.CountryJsonToTables, "Id") }
        };

        _navigationNameToEntityPluralName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
        };

        _isSingleRelationship = new()
        {
        };
    }
#endregion Constructor

    public virtual bool Handle(ValidateEntityChainQuery request)
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