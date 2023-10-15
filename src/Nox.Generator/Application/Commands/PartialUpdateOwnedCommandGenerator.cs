using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class PartialUpdateOwnedCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.PartialUpdateOwnedCommand";

        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            foreach (var ownedRelationship in entity.OwnedRelationships)
            {
                var ownedEntity = entities.Single(entity => entity.Name == ownedRelationship.Entity);

                var primaryKeysReturnQuery = string.Join(", ", ownedEntity.Keys.Select(k => $"entity.{k.Name}.Value"));
                var parentKeysFindQuery = string.Join(", ", entity.Keys.Select(k => $"key{k.Name}"));
                var ownedKeysFindQuery = string.Join(" && ", ownedEntity.Keys.Select(k => $"x.{k.Name} == owned{k.Name}"));

                new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"PartialUpdate{ownedEntity.Name}For{entity.Name}Command")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("relationship", ownedRelationship)
                .WithObject("entity", ownedEntity)
                .WithObject("parent", entity)
                .WithObject("isSingleRelationship", ownedRelationship.WithSingleEntity)
                .WithObject("primaryKeysReturnQuery", primaryKeysReturnQuery)
                .WithObject("parentKeysFindQuery", parentKeysFindQuery)
                .WithObject("ownedKeysFindQuery", ownedKeysFindQuery)
                .GenerateSourceCodeFromResource(templateName);
            }
        }
    }
}