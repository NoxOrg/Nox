using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;

namespace Nox.Generator.Application.Factories;

internal class EntityLocalizedFactoryGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
            return;

        foreach (var entity in codeGenConventions.Solution.Domain.GetLocalizedEntities())
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithFileNamePrefix("Application.Factories")
                .WithClassName($"{entity.Name}LocalizedFactory")
                .WithObject("entity", entity)
                .WithObject("entityKeys", entity.GetKeys())
                .WithObject("localizedEntityName", $"{entity.Name}Localized")
                .WithObject("entityLocalizedAttributes", entity.GetLocalizedAttributes())
                .GenerateSourceCodeFromResource("Application.Factories.EntityLocalizedFactory");
        }
    }
}