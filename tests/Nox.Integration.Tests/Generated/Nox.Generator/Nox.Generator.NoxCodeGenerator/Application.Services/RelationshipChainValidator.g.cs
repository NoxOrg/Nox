﻿// Generated

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Nox.Application.Commands;
using Nox.Application.Services;
using Nox.Domain;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;

namespace TestWebApp.Application.Services;

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
            { "TestEntityZeroOrOnes", (Repository.Query<TestWebApp.Domain.TestEntityZeroOrOne>(), "Id") },
            { "SecondTestEntityZeroOrOnes", (Repository.Query<TestWebApp.Domain.SecondTestEntityZeroOrOne>(), "Id") },
            { "TestEntityWithNuids", (Repository.Query<TestWebApp.Domain.TestEntityWithNuid>(), "Id") },
            { "TestEntityOneOrManies", (Repository.Query<TestWebApp.Domain.TestEntityOneOrMany>(), "Id") },
            { "SecondTestEntityOneOrManies", (Repository.Query<TestWebApp.Domain.SecondTestEntityOneOrMany>(), "Id") },
            { "TestEntityZeroOrManies", (Repository.Query<TestWebApp.Domain.TestEntityZeroOrMany>(), "Id") },
            { "SecondTestEntityZeroOrManies", (Repository.Query<TestWebApp.Domain.SecondTestEntityZeroOrMany>(), "Id") },
            { "ThirdTestEntityOneOrManies", (Repository.Query<TestWebApp.Domain.ThirdTestEntityOneOrMany>(), "Id") },
            { "ThirdTestEntityZeroOrManies", (Repository.Query<TestWebApp.Domain.ThirdTestEntityZeroOrMany>(), "Id") },
            { "ThirdTestEntityExactlyOnes", (Repository.Query<TestWebApp.Domain.ThirdTestEntityExactlyOne>(), "Id") },
            { "ThirdTestEntityZeroOrOnes", (Repository.Query<TestWebApp.Domain.ThirdTestEntityZeroOrOne>(), "Id") },
            { "TestEntityExactlyOnes", (Repository.Query<TestWebApp.Domain.TestEntityExactlyOne>(), "Id") },
            { "SecondTestEntityExactlyOnes", (Repository.Query<TestWebApp.Domain.SecondTestEntityExactlyOne>(), "Id") },
            { "TestEntityZeroOrOneToZeroOrManies", (Repository.Query<TestWebApp.Domain.TestEntityZeroOrOneToZeroOrMany>(), "Id") },
            { "TestEntityZeroOrManyToZeroOrOnes", (Repository.Query<TestWebApp.Domain.TestEntityZeroOrManyToZeroOrOne>(), "Id") },
            { "TestEntityExactlyOneToOneOrManies", (Repository.Query<TestWebApp.Domain.TestEntityExactlyOneToOneOrMany>(), "Id") },
            { "TestEntityOneOrManyToExactlyOnes", (Repository.Query<TestWebApp.Domain.TestEntityOneOrManyToExactlyOne>(), "Id") },
            { "TestEntityExactlyOneToZeroOrManies", (Repository.Query<TestWebApp.Domain.TestEntityExactlyOneToZeroOrMany>(), "Id") },
            { "TestEntityZeroOrManyToExactlyOnes", (Repository.Query<TestWebApp.Domain.TestEntityZeroOrManyToExactlyOne>(), "Id") },
            { "TestEntityOneOrManyToZeroOrManies", (Repository.Query<TestWebApp.Domain.TestEntityOneOrManyToZeroOrMany>(), "Id") },
            { "TestEntityZeroOrManyToOneOrManies", (Repository.Query<TestWebApp.Domain.TestEntityZeroOrManyToOneOrMany>(), "Id") },
            { "TestEntityZeroOrOneToOneOrManies", (Repository.Query<TestWebApp.Domain.TestEntityZeroOrOneToOneOrMany>(), "Id") },
            { "TestEntityOneOrManyToZeroOrOnes", (Repository.Query<TestWebApp.Domain.TestEntityOneOrManyToZeroOrOne>(), "Id") },
            { "TestEntityZeroOrOneToExactlyOnes", (Repository.Query<TestWebApp.Domain.TestEntityZeroOrOneToExactlyOne>(), "Id") },
            { "TestEntityExactlyOneToZeroOrOnes", (Repository.Query<TestWebApp.Domain.TestEntityExactlyOneToZeroOrOne>(), "Id") },
            { "TestEntityOwnedRelationshipExactlyOnes", (Repository.Query<TestWebApp.Domain.TestEntityOwnedRelationshipExactlyOne>(), "Id") },
            { "TestEntityOwnedRelationshipZeroOrOnes", (Repository.Query<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrOne>(), "Id") },
            { "TestEntityOwnedRelationshipOneOrManies", (Repository.Query<TestWebApp.Domain.TestEntityOwnedRelationshipOneOrMany>(), "Id") },
            { "TestEntityOwnedRelationshipZeroOrManies", (Repository.Query<TestWebApp.Domain.TestEntityOwnedRelationshipZeroOrMany>(), "Id") },
            { "TestEntityTwoRelationshipsOneToOnes", (Repository.Query<TestWebApp.Domain.TestEntityTwoRelationshipsOneToOne>(), "Id") },
            { "SecondTestEntityTwoRelationshipsOneToOnes", (Repository.Query<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToOne>(), "Id") },
            { "TestEntityTwoRelationshipsManyToManies", (Repository.Query<TestWebApp.Domain.TestEntityTwoRelationshipsManyToMany>(), "Id") },
            { "SecondTestEntityTwoRelationshipsManyToManies", (Repository.Query<TestWebApp.Domain.SecondTestEntityTwoRelationshipsManyToMany>(), "Id") },
            { "TestEntityTwoRelationshipsOneToManies", (Repository.Query<TestWebApp.Domain.TestEntityTwoRelationshipsOneToMany>(), "Id") },
            { "SecondTestEntityTwoRelationshipsOneToManies", (Repository.Query<TestWebApp.Domain.SecondTestEntityTwoRelationshipsOneToMany>(), "Id") },
            { "TestEntityForTypes", (Repository.Query<TestWebApp.Domain.TestEntityForTypes>(), "Id") },
            { "TestEntityForUniqueConstraints", (Repository.Query<TestWebApp.Domain.TestEntityForUniqueConstraints>(), "Id") },
            { "EntityUniqueConstraintsWithForeignKeys", (Repository.Query<TestWebApp.Domain.EntityUniqueConstraintsWithForeignKey>(), "Id") },
            { "EntityUniqueConstraintsRelatedForeignKeys", (Repository.Query<TestWebApp.Domain.EntityUniqueConstraintsRelatedForeignKey>(), "Id") },
            { "TestEntityLocalizations", (Repository.Query<TestWebApp.Domain.TestEntityLocalization>(), "Id") },
            { "TestEntityForAutoNumberUsages", (Repository.Query<TestWebApp.Domain.TestEntityForAutoNumberUsages>(), "Id") },
            { "ForReferenceNumbers", (Repository.Query<TestWebApp.Domain.ForReferenceNumber>(), "Id") }
        };

        _navigationNameToEntityPluralName = new(StringComparer.OrdinalIgnoreCase)
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
        if (entityName.Equals("TestEntityZeroOrOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityZeroOrOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("SecondTestEntityZeroOrOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = SecondTestEntityZeroOrOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityWithNuids", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.UInt32.TryParse(key, out var value)) return false;
            parsedKey = TestEntityWithNuidMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("TestEntityOneOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityOneOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("SecondTestEntityOneOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = SecondTestEntityOneOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityZeroOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityZeroOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("SecondTestEntityZeroOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = SecondTestEntityZeroOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("ThirdTestEntityOneOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = ThirdTestEntityOneOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("ThirdTestEntityZeroOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = ThirdTestEntityZeroOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("ThirdTestEntityExactlyOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = ThirdTestEntityExactlyOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("ThirdTestEntityZeroOrOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = ThirdTestEntityZeroOrOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityExactlyOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityExactlyOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("SecondTestEntityExactlyOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = SecondTestEntityExactlyOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityZeroOrOneToZeroOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityZeroOrOneToZeroOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityZeroOrManyToZeroOrOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityZeroOrManyToZeroOrOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityExactlyOneToOneOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityExactlyOneToOneOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityOneOrManyToExactlyOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityOneOrManyToExactlyOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityExactlyOneToZeroOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityExactlyOneToZeroOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityZeroOrManyToExactlyOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityZeroOrManyToExactlyOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityOneOrManyToZeroOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityOneOrManyToZeroOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityZeroOrManyToOneOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityZeroOrManyToOneOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityZeroOrOneToOneOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityZeroOrOneToOneOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityOneOrManyToZeroOrOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityOneOrManyToZeroOrOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityZeroOrOneToExactlyOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityZeroOrOneToExactlyOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityExactlyOneToZeroOrOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityExactlyOneToZeroOrOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityOwnedRelationshipExactlyOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityOwnedRelationshipExactlyOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityOwnedRelationshipZeroOrOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityOwnedRelationshipZeroOrOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityOwnedRelationshipOneOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityOwnedRelationshipOneOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityOwnedRelationshipZeroOrManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityOwnedRelationshipZeroOrManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityTwoRelationshipsOneToOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityTwoRelationshipsOneToOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("SecondTestEntityTwoRelationshipsOneToOnes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = SecondTestEntityTwoRelationshipsOneToOneMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityTwoRelationshipsManyToManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityTwoRelationshipsManyToManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("SecondTestEntityTwoRelationshipsManyToManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = SecondTestEntityTwoRelationshipsManyToManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityTwoRelationshipsOneToManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityTwoRelationshipsOneToManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("SecondTestEntityTwoRelationshipsOneToManies", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = SecondTestEntityTwoRelationshipsOneToManyMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityForTypes", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityForTypesMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityForUniqueConstraints", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityForUniqueConstraintsMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("EntityUniqueConstraintsWithForeignKeys", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Guid.TryParse(key, out var value)) return false;
            parsedKey = EntityUniqueConstraintsWithForeignKeyMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("EntityUniqueConstraintsRelatedForeignKeys", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int32.TryParse(key, out var value)) return false;
            parsedKey = EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("TestEntityLocalizations", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = TestEntityLocalizationMetadata.CreateId(key);
            return true;
        }
        if (entityName.Equals("TestEntityForAutoNumberUsages", StringComparison.OrdinalIgnoreCase))
        {
            if (!System.Int64.TryParse(key, out var value)) return false;
            parsedKey = TestEntityForAutoNumberUsagesMetadata.CreateId(value);
            return true;
        }
        if (entityName.Equals("ForReferenceNumbers", StringComparison.OrdinalIgnoreCase))
        {
            parsedKey = ForReferenceNumberMetadata.CreateId(key);
            return true;
        }
        return false;
    }
}