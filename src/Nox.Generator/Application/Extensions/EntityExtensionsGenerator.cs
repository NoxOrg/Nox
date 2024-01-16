using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Extensions;

internal class EntityExtensionsGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        NoxSolution solution = codeGenConventions.Solution;
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain?.Entities.Any() != true)
            return;

        foreach (var entity in codeGenConventions.Solution.Domain!.Entities)
        {
            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGenConventions.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.Name}Extensions")
                .WithFileNamePrefix("Application.Extensions")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)
                .GenerateSourceCodeFromResource("Application.Extensions.EntityExtensions");
        }
    }
}