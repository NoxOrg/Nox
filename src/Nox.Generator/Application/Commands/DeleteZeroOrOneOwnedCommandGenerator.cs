using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class DeleteZeroOrOneOwnedCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.DeleteZeroOrOneOwnedCommand";
        var entityList = entities.ToList();
        foreach (var entity in entityList)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            foreach (var ownedRelationship in entity.OwnedRelationships.Where(r => r.Relationship == EntityRelationshipType.ZeroOrOne))
            {
                var ownedEntity = entityList.Single(e => e.Name == ownedRelationship.Entity);
                var relationshipName = entity.GetNavigationPropertyName(ownedRelationship);


                new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"DeleteAll{relationshipName}For{entity.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("relationship", ownedRelationship)
                    .WithObject("entity", ownedEntity)
                    .WithObject("parent", entity)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }
    }
}