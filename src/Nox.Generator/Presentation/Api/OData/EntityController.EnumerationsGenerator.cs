using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
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

        foreach (var entity in codeGenConventions.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (entity.IsOwnedEntity)
            {
                continue;
            }
            var enumerationAttributes =
                entity
                .Attributes
                .Where(attribute => attribute.Type == NoxType.Enumeration)
                .Select(attribute => new {
                    Attribute = attribute,
                    EntityNameForEnumeration = codeGenConventions.GetEntityNameForEnumeration(entity.Name, attribute.Name) + "Dto",
                    EntityNameForLocalizedEnumeration = codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name) + "Dto",
                    EntityDtoNameForLocalizedEnumeration = codeGenConventions.GetEntityDtoNameForEnumerationLocalized(entity.Name, attribute.Name),
                });

            if (!enumerationAttributes.Any())
            {
                continue;
            }

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.PluralName}Controller")
                .WithFileNamePrefix("Presentation.Api.OData")
                .WithFileNameSuffix("Enumerations")
                .WithObject("entity", entity)
                .WithObject("enumerationAttributes", enumerationAttributes)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}
