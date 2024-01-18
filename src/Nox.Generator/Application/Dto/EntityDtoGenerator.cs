using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.ApplicationDto;

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

        if (solution.Domain is null)
        {
            return;
        }

        foreach (var entity in codeGenConventions.Solution.Domain!.Entities)
        {
            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGenConventions.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.Name}Dto")
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)    
                .GenerateSourceCodeFromResource("Application.Dto.EntityDto");         
        }        
    }
}