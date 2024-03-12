using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;

using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application.Commands;

internal class DeleteOwnedEntityTranslationsCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.DeleteOwnedEntityTranslationsCommand";
        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var parentPrimaryKeys = GetPrimaryKeys(codeGenConventions, entity, keyPrefix: "key");

            foreach (var ownedRelationship in entity.OwnedRelationships.Where(x => x.Related.Entity.IsOwnedEntity && x.Related.Entity.GetLocalizedAttributes().Any()))
            {
                var ownedEntity = ownedRelationship.Related.Entity;
                var ownedPrimaryKeys = GetPrimaryKeys(codeGenConventions, ownedEntity, keyPrefix: "relatedKey");

                new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"Delete{entity.GetNavigationPropertyName(ownedRelationship)}TranslationsFor{entity.Name}Command")
                    .WithFileNamePrefix($"Application.Commands")
                    .WithObject("relationship", ownedRelationship)
                    .WithObject("entity", ownedEntity)
                    .WithObject("parent", entity)
                    .WithObject("parentPrimaryKeys", parentPrimaryKeys)
                    .WithObject("ownedPrimaryKeys", ownedPrimaryKeys)
                    .GenerateSourceCodeFromResource(templateName);
            }
        }
    }

    private string GetPrimaryKeys(NoxCodeGenConventions codeGenConventions, Entity entity, string keyPrefix)
        => string.Join(", ", entity.Keys.Select(k => $"{codeGenConventions.Solution.GetSinglePrimitiveTypeForKey(k)} {keyPrefix}{k.Name}"));
}
