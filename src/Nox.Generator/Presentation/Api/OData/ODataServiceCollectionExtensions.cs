using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Presentation.Api.OData;

internal class ODataServiceCollectionExtensions : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
        {
            return;
        }

        var enumerationAttributes = new List<EntityEnumerations>();
        foreach (var entity in codeGenConventions.Solution.Domain.Entities)
        {
            var enumerations = entity
              .Attributes
              .Where(attribute => attribute.Type == NoxType.Enumeration)
              .Select(attribute => new EntityEnumerations(
                  entity,
                  attribute,
                  codeGenConventions.GetEntityNameForEnumeration(entity.Name, attribute.Name) + "Dto",
                  codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name) + "Dto",
                  codeGenConventions.GetEntityDtoNameForEnumerationLocalized(entity.Name, attribute.Name)
              )).ToArray();

            if (enumerations.Any())
                enumerationAttributes.AddRange(enumerations);
        }


        var templateName = @"Presentation.Api.OData.ODataServiceCollectionExtensions";

        new TemplateCodeBuilder(context, codeGenConventions)
            .WithObject("enumerationAttributes", enumerationAttributes)
            .WithFileNamePrefix($"Presentation.Api.OData")
            .GenerateSourceCodeFromResource(templateName);

    }
    internal sealed record class EntityEnumerations(Entity Entity, NoxSimpleTypeDefinition Attribute, string EntityNameForEnumeration, string EntityNameForLocalizedEnumeration, string EntityDtoNameForLocalizedEnumeration);

}