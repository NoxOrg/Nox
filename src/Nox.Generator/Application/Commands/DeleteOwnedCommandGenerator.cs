using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class DeleteOwnedCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.DeleteOwnedCommand";
        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            foreach (var ownedRelationship in entity.OwnedRelationships)
            {
                var ownedEntity = entities.Single(entity => entity.Name == ownedRelationship.Entity);
                var relationshipName = entity.GetNavigationPropertyName(ownedRelationship);

                var ownedKeysFindQuery = string.Join(" && ", ownedEntity.Keys.Select(k => $"x.{k.Name} == owned{k.Name}"));

                new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"Delete{relationshipName}For{entity.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("relationship", ownedRelationship)
                    .WithObject("entity", ownedEntity)
                    .WithObject("parent", entity)
                    .WithObject("isSingleRelationship", ownedRelationship.WithSingleEntity)                    
                    .WithObject("ownedKeysFindQuery", ownedKeysFindQuery)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }
    }
}