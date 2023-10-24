using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Infrastructure.Persistence;

internal class DtoDbContextGenerator : INoxCodeGenerator
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

        const string templateName = @"Infrastructure.Persistence.DtoDbContext";
        var entities = codeGeneratorState.Solution.Domain.Entities.Where(e => !e.IsOwnedEntity).ToList();
     
        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName("DtoDbContext")
            .WithFileNamePrefix($"Infrastructure.Persistence")
            .WithObject("entities", entities)
            .GenerateSourceCodeFromResource(templateName);
    }
}
