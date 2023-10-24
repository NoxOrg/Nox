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
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }
        
        var templateName = @"Infrastructure.Persistence.DbContext";
        var enumerationAttributes = codeGeneratorState.Solution.Domain.Entities
            .Select(entity => new { Entity = entity, Attributes = entity.Attributes.Where(attribute => attribute.Type == NoxType.Enumeration).ToArray() })
            .Where(entity => entity.Attributes.Any());

        var entitiesToLocalize = codeGeneratorState.Solution.Domain.Entities
            .Where(entity => entity.ShouldBeLocalized);

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName("AppDbContext")
            .WithFileNamePrefix("Infrastructure.Persistence")
            .WithObject("enumerationAttributes", enumerationAttributes)
            .WithObject("entitiesToLocalize", entitiesToLocalize)
            .GenerateSourceCodeFromResource(templateName);
    }
}