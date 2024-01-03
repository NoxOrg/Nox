// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Services;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Services;

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
            { "TestEntityZeroOrOnes", (DataDbContext.TestEntityZeroOrOnes, "Id") },
            { "SecondTestEntityZeroOrOnes", (DataDbContext.SecondTestEntityZeroOrOnes, "Id") },
            { "TestEntityWithNuids", (DataDbContext.TestEntityWithNuids, "Id") },
            { "TestEntityOneOrManies", (DataDbContext.TestEntityOneOrManies, "Id") },
            { "SecondTestEntityOneOrManies", (DataDbContext.SecondTestEntityOneOrManies, "Id") },
            { "TestEntityZeroOrManies", (DataDbContext.TestEntityZeroOrManies, "Id") },
            { "SecondTestEntityZeroOrManies", (DataDbContext.SecondTestEntityZeroOrManies, "Id") },
            { "ThirdTestEntityOneOrManies", (DataDbContext.ThirdTestEntityOneOrManies, "Id") },
            { "ThirdTestEntityZeroOrManies", (DataDbContext.ThirdTestEntityZeroOrManies, "Id") },
            { "ThirdTestEntityExactlyOnes", (DataDbContext.ThirdTestEntityExactlyOnes, "Id") },
            { "ThirdTestEntityZeroOrOnes", (DataDbContext.ThirdTestEntityZeroOrOnes, "Id") },
            { "TestEntityExactlyOnes", (DataDbContext.TestEntityExactlyOnes, "Id") },
            { "SecondTestEntityExactlyOnes", (DataDbContext.SecondTestEntityExactlyOnes, "Id") },
            { "TestEntityZeroOrOneToZeroOrManies", (DataDbContext.TestEntityZeroOrOneToZeroOrManies, "Id") },
            { "TestEntityZeroOrManyToZeroOrOnes", (DataDbContext.TestEntityZeroOrManyToZeroOrOnes, "Id") },
            { "TestEntityExactlyOneToOneOrManies", (DataDbContext.TestEntityExactlyOneToOneOrManies, "Id") },
            { "TestEntityOneOrManyToExactlyOnes", (DataDbContext.TestEntityOneOrManyToExactlyOnes, "Id") },
            { "TestEntityExactlyOneToZeroOrManies", (DataDbContext.TestEntityExactlyOneToZeroOrManies, "Id") },
            { "TestEntityZeroOrManyToExactlyOnes", (DataDbContext.TestEntityZeroOrManyToExactlyOnes, "Id") },
            { "TestEntityOneOrManyToZeroOrManies", (DataDbContext.TestEntityOneOrManyToZeroOrManies, "Id") },
            { "TestEntityZeroOrManyToOneOrManies", (DataDbContext.TestEntityZeroOrManyToOneOrManies, "Id") },
            { "TestEntityZeroOrOneToOneOrManies", (DataDbContext.TestEntityZeroOrOneToOneOrManies, "Id") },
            { "TestEntityOneOrManyToZeroOrOnes", (DataDbContext.TestEntityOneOrManyToZeroOrOnes, "Id") },
            { "TestEntityZeroOrOneToExactlyOnes", (DataDbContext.TestEntityZeroOrOneToExactlyOnes, "Id") },
            { "TestEntityExactlyOneToZeroOrOnes", (DataDbContext.TestEntityExactlyOneToZeroOrOnes, "Id") },
            { "TestEntityOwnedRelationshipExactlyOnes", (DataDbContext.TestEntityOwnedRelationshipExactlyOnes, "Id") },
            { "TestEntityOwnedRelationshipZeroOrOnes", (DataDbContext.TestEntityOwnedRelationshipZeroOrOnes, "Id") },
            { "TestEntityOwnedRelationshipOneOrManies", (DataDbContext.TestEntityOwnedRelationshipOneOrManies, "Id") },
            { "TestEntityOwnedRelationshipZeroOrManies", (DataDbContext.TestEntityOwnedRelationshipZeroOrManies, "Id") },
            { "TestEntityTwoRelationshipsOneToOnes", (DataDbContext.TestEntityTwoRelationshipsOneToOnes, "Id") },
            { "SecondTestEntityTwoRelationshipsOneToOnes", (DataDbContext.SecondTestEntityTwoRelationshipsOneToOnes, "Id") },
            { "TestEntityTwoRelationshipsManyToManies", (DataDbContext.TestEntityTwoRelationshipsManyToManies, "Id") },
            { "SecondTestEntityTwoRelationshipsManyToManies", (DataDbContext.SecondTestEntityTwoRelationshipsManyToManies, "Id") },
            { "TestEntityTwoRelationshipsOneToManies", (DataDbContext.TestEntityTwoRelationshipsOneToManies, "Id") },
            { "SecondTestEntityTwoRelationshipsOneToManies", (DataDbContext.SecondTestEntityTwoRelationshipsOneToManies, "Id") },
            { "TestEntityForTypes", (DataDbContext.TestEntityForTypes, "Id") },
            { "TestEntityForUniqueConstraints", (DataDbContext.TestEntityForUniqueConstraints, "Id") },
            { "EntityUniqueConstraintsWithForeignKeys", (DataDbContext.EntityUniqueConstraintsWithForeignKeys, "Id") },
            { "EntityUniqueConstraintsRelatedForeignKeys", (DataDbContext.EntityUniqueConstraintsRelatedForeignKeys, "Id") },
            { "TestEntityLocalizations", (DataDbContext.TestEntityLocalizations, "Id") },
            { "TestEntityForAutoNumberUsages", (DataDbContext.TestEntityForAutoNumberUsages, "Id") },
            { "ForReferenceNumbers", (DataDbContext.ForReferenceNumbers, "Id") }
        };

        _navigationNameToEntityPluralName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {           
            { "secondtestentityzeroorone", "secondtestentityzeroorones" },           
            { "testentityzeroorone", "testentityzeroorones" },           
            { "secondtestentityoneormanies", "secondtestentityoneormanies" },           
            { "testentityoneormanies", "testentityoneormanies" },           
            { "secondtestentityzeroormanies", "secondtestentityzeroormanies" },           
            { "testentityzeroormanies", "testentityzeroormanies" },           
            { "thirdtestentityzeroormanies", "thirdtestentityzeroormanies" },           
            { "thirdtestentityoneormanies", "thirdtestentityoneormanies" },           
            { "thirdtestentityzeroorone", "thirdtestentityzeroorones" },           
            { "thirdtestentityexactlyone", "thirdtestentityexactlyones" },           
            { "secondtestentityexactlyone", "secondtestentityexactlyones" },           
            { "testentityexactlyone", "testentityexactlyones" },           
            { "testentityzeroormanytozeroorone", "testentityzeroormanytozeroorones" },           
            { "testentityzerooronetozeroormanies", "testentityzerooronetozeroormanies" },           
            { "testentityoneormanytoexactlyone", "testentityoneormanytoexactlyones" },           
            { "testentityexactlyonetooneormanies", "testentityexactlyonetooneormanies" },           
            { "testentityzeroormanytoexactlyone", "testentityzeroormanytoexactlyones" },           
            { "testentityexactlyonetozeroormanies", "testentityexactlyonetozeroormanies" },           
            { "testentityzeroormanytooneormanies", "testentityzeroormanytooneormanies" },           
            { "testentityoneormanytozeroormanies", "testentityoneormanytozeroormanies" },           
            { "testentityoneormanytozeroorone", "testentityoneormanytozeroorones" },           
            { "testentityzerooronetooneormanies", "testentityzerooronetooneormanies" },           
            { "testentityexactlyonetozeroorone", "testentityexactlyonetozeroorones" },           
            { "testentityzerooronetoexactlyone", "testentityzerooronetoexactlyones" },           
            { "testrelationshipone", "secondtestentitytworelationshipsonetoones" },           
            { "testrelationshiptwo", "secondtestentitytworelationshipsonetoones" },           
            { "testrelationshiponeonotherside", "testentitytworelationshipsonetoones" },           
            { "testrelationshiptwoonotherside", "testentitytworelationshipsonetoones" },           
            { "entityuniqueconstraintsrelatedforeignkey", "entityuniqueconstraintsrelatedforeignkeys" },           
            { "entityuniqueconstraintswithforeignkeys", "entityuniqueconstraintswithforeignkeys" }
        };

        _isSingleRelationship = new()
        {           
            { ("testentityzeroorones", "secondtestentityzeroorone"), true },           
            { ("secondtestentityzeroorones", "testentityzeroorone"), true },           
            { ("testentityoneormanies", "secondtestentityoneormanies"), false },           
            { ("secondtestentityoneormanies", "testentityoneormanies"), false },           
            { ("testentityzeroormanies", "secondtestentityzeroormanies"), false },           
            { ("secondtestentityzeroormanies", "testentityzeroormanies"), false },           
            { ("thirdtestentityoneormanies", "thirdtestentityzeroormanies"), false },           
            { ("thirdtestentityzeroormanies", "thirdtestentityoneormanies"), false },           
            { ("thirdtestentityexactlyones", "thirdtestentityzeroorone"), true },           
            { ("thirdtestentityzeroorones", "thirdtestentityexactlyone"), true },           
            { ("testentityexactlyones", "secondtestentityexactlyone"), true },           
            { ("secondtestentityexactlyones", "testentityexactlyone"), true },           
            { ("testentityzerooronetozeroormanies", "testentityzeroormanytozeroorone"), true },           
            { ("testentityzeroormanytozeroorones", "testentityzerooronetozeroormanies"), false },           
            { ("testentityexactlyonetooneormanies", "testentityoneormanytoexactlyone"), true },           
            { ("testentityoneormanytoexactlyones", "testentityexactlyonetooneormanies"), false },           
            { ("testentityexactlyonetozeroormanies", "testentityzeroormanytoexactlyone"), true },           
            { ("testentityzeroormanytoexactlyones", "testentityexactlyonetozeroormanies"), false },           
            { ("testentityoneormanytozeroormanies", "testentityzeroormanytooneormanies"), false },           
            { ("testentityzeroormanytooneormanies", "testentityoneormanytozeroormanies"), false },           
            { ("testentityzerooronetooneormanies", "testentityoneormanytozeroorone"), true },           
            { ("testentityoneormanytozeroorones", "testentityzerooronetooneormanies"), false },           
            { ("testentityzerooronetoexactlyones", "testentityexactlyonetozeroorone"), true },           
            { ("testentityexactlyonetozeroorones", "testentityzerooronetoexactlyone"), true },           
            { ("testentitytworelationshipsonetoones", "testrelationshipone"), true },           
            { ("testentitytworelationshipsonetoones", "testrelationshiptwo"), true },           
            { ("secondtestentitytworelationshipsonetoones", "testrelationshiponeonotherside"), true },           
            { ("secondtestentitytworelationshipsonetoones", "testrelationshiptwoonotherside"), true },           
            { ("testentitytworelationshipsmanytomanies", "testrelationshipone"), false },           
            { ("testentitytworelationshipsmanytomanies", "testrelationshiptwo"), false },           
            { ("secondtestentitytworelationshipsmanytomanies", "testrelationshiponeonotherside"), false },           
            { ("secondtestentitytworelationshipsmanytomanies", "testrelationshiptwoonotherside"), false },           
            { ("testentitytworelationshipsonetomanies", "testrelationshipone"), false },           
            { ("testentitytworelationshipsonetomanies", "testrelationshiptwo"), false },           
            { ("secondtestentitytworelationshipsonetomanies", "testrelationshiponeonotherside"), true },           
            { ("secondtestentitytworelationshipsonetomanies", "testrelationshiptwoonotherside"), true },           
            { ("entityuniqueconstraintswithforeignkeys", "entityuniqueconstraintsrelatedforeignkey"), true },           
            { ("entityuniqueconstraintsrelatedforeignkeys", "entityuniqueconstraintswithforeignkeys"), false }
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