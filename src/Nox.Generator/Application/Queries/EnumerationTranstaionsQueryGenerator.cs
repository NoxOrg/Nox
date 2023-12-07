using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;

namespace Nox.Generator.Application.Queries;

internal class EnumerationTranslationsQueryGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions noxCodeGenCodeConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Queries.EnumerationTranslationsQuery";

        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var enumerationAttributes =
                entity
                .Attributes
                .Where(attribute => attribute.Type == NoxType.Enumeration && attribute.EnumerationTypeOptions!.IsLocalized)
                .Select(attribute => new {
                    Attribute = attribute,
                    EntityNameForLocalizedEnumeration = noxCodeGenCodeConventions.GetEntityDtoNameForEnumerationLocalized(entity.Name, attribute.Name)
                });

            if (!enumerationAttributes.Any())
            {
                continue;
            }

            new TemplateCodeBuilder(context, noxCodeGenCodeConventions)
                .WithClassName($"Get{entity.PluralName}EnumerationTranslationsQuery")
                .WithFileNamePrefix($"Application.Queries")
                .WithObject("entity", entity)
                .WithObject("enumerationAttributes", enumerationAttributes)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}