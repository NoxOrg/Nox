using FluentValidation;
using Nox.Solution.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution;

public class NoxSolution : Solution
{
    private List<EntityRelationshipWithType> _relationshipsToCreate = new List<EntityRelationshipWithType>();
    private readonly object _relationshipsToCreateLock = new object();

    public string? RootYamlFile { get; internal set; }

    internal void Validate()
    {
        var validator = new SolutionValidator();
        validator.ValidateAndThrow(this);
    }

    public List<EntityRelationshipWithType> GetRelationshipsToCreate(Func<string, Type?> getTypeByNameFunc)
    {
        var fullRelationshipModels = new List<EntityRelationshipWithType>();

        lock (_relationshipsToCreateLock)
        {
            if (_relationshipsToCreate.Any())
            {
                return _relationshipsToCreate;
            }

            if (Domain?.Entities == null)
            {
                return fullRelationshipModels;
            }

            var totalRelationships = Domain
                .Entities
                .Where(x => x.Relationships != null)
                .SelectMany(x => x.Relationships!)
                .ToList();

            foreach (var relationship in totalRelationships)
            {
                var isIgnored = false;
                var fullModel = new EntityRelationshipWithType
                {
                    Relationship = relationship,
                    RelationshipEntityType = getTypeByNameFunc(relationship.Entity)!,
                    ShouldBeMapped = true
                };

                var pairRelationship = relationship.Related.EntityRelationship;
                if (pairRelationship != null)
                {
                    // If zeroOrMany vs OneOrMany handle on oneOrMany side
                    if (pairRelationship.Relationship == EntityRelationshipType.OneOrMany &&
                        relationship.Relationship == EntityRelationshipType.ZeroOrMany)
                    {
                        isIgnored = true;
                    }
                    // If same type on both sides cover on first by ascending alphabetical sort
                    else if (pairRelationship.Relationship == relationship.Relationship &&
                             // Ascending alphabetical sort
                             string.Compare(relationship.Entity, pairRelationship.Entity, StringComparison.InvariantCulture) > 0)
                    {
                        isIgnored = true;
                    }
                }

                fullModel.ShouldBeMapped = !isIgnored;
                fullRelationshipModels.Add(fullModel);
            }
            _relationshipsToCreate = fullRelationshipModels;

            return fullRelationshipModels;
        }
    }
}