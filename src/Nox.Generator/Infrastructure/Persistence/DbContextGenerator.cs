using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Linq;

namespace Nox.Generator.Infrastructure.Persistence;

internal class DbContextGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Infrastructure;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions noxCodeGenCodeConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (noxCodeGenCodeConventions.Solution.Domain is null)
        {
            return;
        }
        
        const string templateName = @"Infrastructure.Persistence.DbContext";

        var entitiesToLocalize = noxCodeGenCodeConventions.Solution.Domain.Entities
            .Where(entity => entity.ShouldBeLocalized);

        var enumerationAttributes = noxCodeGenCodeConventions.Solution.Domain.Entities
           .Select(entity =>
           new {
               Entity = entity,
               Attributes =
                   entity.Attributes.Where(attribute => attribute.Type == NoxType.Enumeration).Select(attribute =>
                   new {
                       Attribute = attribute,
                       EntityNameForEnumeration = noxCodeGenCodeConventions.GetEntityNameForEnumeration(entity.Name, attribute.Name),
                       EntityNameForLocalizedEnumeration = noxCodeGenCodeConventions.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name),
                       DbSetNameForEnumeration = $"{entity.Name.Pluralize()}{attribute.Name.Pluralize()}",
                       DbSetNameForLocalizedEnumeration = $"{entity.Name.Pluralize()}{attribute.Name.Pluralize()}Localized"
                   })
           })
           .Where(entity => entity.Attributes.Any());

        new TemplateCodeBuilder(context, noxCodeGenCodeConventions)
            .WithClassName("AppDbContext")
            .WithFileNamePrefix("Infrastructure.Persistence")
            .WithObject("enumerationAttributes", enumerationAttributes)
            .WithObject("entitiesToLocalize", entitiesToLocalize)
            .GenerateSourceCodeFromResource(templateName);
    }
}