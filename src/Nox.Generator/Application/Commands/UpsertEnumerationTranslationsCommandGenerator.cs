using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;
using Nox.Types;

namespace Nox.Generator.Application.Commands;

internal class UpsertEnumerationTranslationsCommandGenerator : ApplicationEntityDependentGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities)
    {
        var templateName = @"Application.Commands.UpsertEnumerationTranslationsCommand";
        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var enumerationAttributes =
                entity
                    .Attributes
                    .Where(attribute => attribute.Type == NoxType.Enumeration && attribute.EnumerationTypeOptions!.IsLocalized)
                    .Select(attribute => new {
                        Attribute = attribute,
                        EntityNameForLocalizedEnumeration = codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name),
                        EntityDtoNameForLocalizedEnumeration = codeGenConventions.GetEntityDtoNameForEnumerationLocalized(entity.Name, attribute.Name),
                        EntityNameForEnumeration = codeGenConventions.GetEntityNameForEnumeration(entity.Name, attribute.Name),
                        
                    });

            if (!enumerationAttributes.Any())
            {
                continue;
            }
            
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"Upsert{entity.Name}EnumerationsTranslationsCommand")
                .WithFileNamePrefix($"Application.Commands")
                .WithObject("entity", entity)
                .WithObject("enumerationAttributes", enumerationAttributes)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}