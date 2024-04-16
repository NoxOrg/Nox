using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerEnumerationsGenerator : EntityControllerGeneratorBase
{
    public override void Generate(
        SourceProductionContext context,
        NoxCodeGenConventions codeGenConventions,
        GeneratorConfig config, System.Action<string> log,
        string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
        {
            return;
        }

        const string templateName = @"Presentation.Api.OData.EntityController.Enumerations";

        foreach (var entity in codeGenConventions.Solution.Domain.Entities.Where(e => !e.IsOwnedEntity))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var enumerations = CreateEnumerations(entity, codeGenConventions);

            foreach (var relationship in entity.OwnedRelationships)
            {
                var ownedEntityEnumerations = CreateEnumerations(relationship.Related.Entity, codeGenConventions, relationship.WithSingleEntity, relationship.WithMultiEntity);
                enumerations = enumerations.Concat(ownedEntityEnumerations);
            }

            if (!enumerations.Any())
            {
                continue;
            }

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.PluralName}Controller")
                .WithFileNamePrefix("Presentation.Api.OData")
                .WithFileNameSuffix("Enumerations")
                .WithObject("entity", entity)
                .WithObject("enumerationAttributes", enumerations)
                .GenerateSourceCodeFromResource(templateName);
        }
    }

    private IEnumerable<object> CreateEnumerations(
        Entity entity,
        NoxCodeGenConventions codeGenConventions,
        bool isSingleOwned = false,
        bool isMultiOwned = false)
    {
        return entity.Attributes
            .Where(IsEnumeration)
            .Select(attribute => new
            {
                EntityName = entity.Name,
                EntityPluralName = entity.PluralName,
                IsSingleOwnedEntity = isSingleOwned,
                IsMultiOwnedEntity = isMultiOwned,
                Attribute = attribute,
                EntityNameForEnumeration = codeGenConventions.GetEntityNameForEnumeration(entity.Name, attribute.Name) + "Dto",
                EntityNameForLocalizedEnumeration = codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name) + "Dto",
                EntityDtoNameForLocalizedEnumeration = codeGenConventions.GetEntityDtoNameForEnumerationLocalized(entity.Name, attribute.Name),
                EntityDtoNameForEnumeration = codeGenConventions.GetEntityDtoNameForEnumeration(entity.Name, attribute.Name),
                EntityDtoNameForUpsertLocalizedEnumeration = codeGenConventions.GetEntityDtoNameForUpsertLocalizedEnumeration(entity.Name, attribute.Name),
            });
    }

    private bool IsEnumeration(NoxSimpleTypeDefinition attribute)
        => attribute.Type == NoxType.Enumeration;
}
