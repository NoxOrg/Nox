using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Linq;

namespace Nox.Generator.Application.Factories;

internal class EntityLocalizedFactoryGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(e => e.IsLocalized))
        {
            
            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{k.Type} {k.Name.ToLowerFirstChar()}"));
           
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithFileNamePrefix("Application.Factories")
                .WithClassName($"{entity.Name}LocalizedFactory")
                .WithObject("entity", entity)
                .WithObject("localizedEntityName", $"{entity.Name}Localized")
                .WithObject("localizedEntityAttributes", entity.GetAttributesToLocalize())
                .WithObject("primaryKeys", primaryKeys)
                .GenerateSourceCodeFromResource("Application.Factories.EntityLocalizedFactory");
        }
    }
    
    private static string GetPrimaryKeysRoute(Entity entity, NoxSolution solution, string keyPrefix = "key", string attributePrefix = "[FromRoute]")
    {
        if (entity?.Keys?.Count > 1)
        {
            return string.Join(", ", entity.Keys.Select(k => $"{attributePrefix} {solution.GetSinglePrimitiveTypeForKey(k)} {keyPrefix}{k.Name}"))
                .Trim();
        }
        else if (entity?.Keys is not null)
        {
            return $"{attributePrefix} {solution.GetSinglePrimitiveTypeForKey(entity.Keys[0])} {keyPrefix}"
                .Trim();
        }

        return string.Empty;
    }
}