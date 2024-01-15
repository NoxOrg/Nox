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
        
        const string templateName = @"Infrastructure.Persistence.DbContext";

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
                       EntityNameForEnumeration = codeGenConventions.GetEntityNameForEnumeration(entity.Name, attribute.Name),
                       EntityNameForLocalizedEnumeration = codeGenConventions.GetEntityNameForEnumerationLocalized(entity.Name, attribute.Name),
                       DbSetNameForEnumeration = $"{entity.Name.Pluralize()}{attribute.Name.Pluralize()}",
                       DbSetNameForLocalizedEnumeration = $"{entity.Name.Pluralize()}{attribute.Name.Pluralize()}Localized"
                   })
           })
           .Where(entity => entity.Attributes.Any());

        new TemplateCodeBuilder(context, codeGenConventions)
            .WithClassName("AppDbContext")
            .WithFileNamePrefix("Infrastructure.Persistence")
            .WithObject("enumerationAttributes", enumerationAttributes)
            .WithObject("entitiesToLocalize", entitiesToLocalize)
            .GenerateSourceCodeFromResource(templateName);
    }
}