﻿using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class CreateOwnedCommandGenerator : ApplicationGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.CreateOwnedCommand";
        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            foreach (var ownedRelationship in entity.OwnedRelationships)
            {
                var ownedEntity = entities.Single(entity => entity.Name == ownedRelationship.Entity);

                var parentKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
                var primaryKeysReturnQuery = string.Join(", ", ownedEntity.Keys.Select(k => $"entity.{k.Name}.Value"));

                new TemplateCodeBuilder(context, codeGeneratorState)
                    .WithClassName($"Create{ownedEntity.Name}For{entity.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("relationship", ownedRelationship)
                    .WithObject("entity", ownedEntity)
                    .WithObject("parent", entity)
                    .WithObject("isSingleRelationship", ownedRelationship.WithSingleEntity)
                    .WithObject("parentKeysFindQuery", parentKeysFindQuery)
                    .WithObject("primaryKeysReturnQuery", primaryKeysReturnQuery)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }
    }
}