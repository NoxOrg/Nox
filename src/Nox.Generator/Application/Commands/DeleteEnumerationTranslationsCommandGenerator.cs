using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;
using Nox.Types;

namespace Nox.Generator.Application.Commands;

internal class DeleteEnumerationTranslationsCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.DeleteEnumerationTranslationsCommand";
        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var enumerationAttributes =
                entity
                    .Attributes
                    .Where(attribute => attribute.Type == NoxType.Enumeration && attribute.EnumerationTypeOptions!.IsLocalized)
                    .Select(attribute => new {
                        Attribute = attribute,
                        EntityNameForLocalizedEnumeration = codeGeneratorState.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name)
                    });

            if (!enumerationAttributes.Any())
            {
                continue;
            }
            
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Delete{entity.Name}EnumerationsTranslationsCommand")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("enumerationAttributes", enumerationAttributes)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}