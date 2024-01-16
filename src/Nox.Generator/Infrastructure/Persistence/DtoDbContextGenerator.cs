using System.Linq;
using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;

namespace Nox.Generator.Infrastructure.Persistence;

internal class DtoDbContextGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Infrastructure;

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

        const string templateName = @"Infrastructure.Persistence.DtoDbContext";
        
        var entities = codeGenConventions.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity).ToList();

        var entitiesToLocalize = codeGenConventions.Solution.Domain.Entities
            .Where(entity => entity.IsLocalized);

        var enumerationAttributes = codeGenConventions.Solution.Domain.Entities
            .Select(entity =>
            new {
                Entity = entity,
                Attributes =
                    entity.Attributes.Where(attribute => attribute.Type == NoxType.Enumeration).Select(attribute =>
                    new { 
                        Attribute = attribute,
                        EntityNameForEnumeration = codeGenConventions.GetEntityDtoNameForEnumeration(entity.Name, attribute.Name),
                        EntityNameForLocalizedEnumeration = codeGenConventions.GetEntityDtoNameForEnumerationLocalized(entity.Name, attribute.Name),
                        DbSetNameForEnumeration = $"{entity.Name.Pluralize()}{attribute.Name.Pluralize()}",
                        DbSetNameForLocalizedEnumeration = $"{entity.Name.Pluralize()}{attribute.Name.Pluralize()}Localized"
                    })               
             })
            .Where(entity => entity.Attributes.Any());


        new TemplateCodeBuilder(context, codeGenConventions)
            .WithClassName("DtoDbContext")
            .WithFileNamePrefix($"Infrastructure.Persistence")
            .WithObject("entities", entities)
            .WithObject("entitiesToLocalize", entitiesToLocalize)
            .WithObject("enumerationAttributes", enumerationAttributes)
            .GenerateSourceCodeFromResource(templateName);
    }
}
