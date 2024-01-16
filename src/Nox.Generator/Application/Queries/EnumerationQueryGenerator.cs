using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;

namespace Nox.Generator.Application.Queries;

internal class EnumerationQueryGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Queries.EnumerationQuery";

        foreach (var entity in entities)
        {
            if (entity.IsOwnedEntity)
                continue;

            context.CancellationToken.ThrowIfCancellationRequested();

            var enumerationAttributes =
                entity
                .Attributes
                .Where(attribute => attribute.Type == NoxType.Enumeration)
                .Select(attribute => new {
                    Attribute = attribute,
                    EntityNameForEnumeration = codeGenConventions.GetEntityDtoNameForEnumeration(entity.Name, attribute.Name),
                    EntityNameForLocalizedEnumeration = codeGenConventions.GetEntityDtoNameForEnumerationLocalized(entity.Name, attribute.Name)
                });

            if (!enumerationAttributes.Any())
            {
                continue;
            }

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"Get{entity.PluralName}EnumerationsQuery")
                .WithFileNamePrefix($"Application.Queries")
                .WithObject("entity", entity)
                .WithObject("enumerationAttributes", enumerationAttributes)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}