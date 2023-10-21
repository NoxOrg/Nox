using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using System.Linq;

namespace Nox.Generator.Domain;

internal class EntitiesLocalizedGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
     SourceProductionContext context,
     NoxCodeGenConventions codeGeneratorState,
     GeneratorConfig config,
     System.Action<string> log,
     string? projectRootPath
     )
    { 
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null) return;

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            // Currently skip owned and composite key entities
            if (!entity.ShouldBeLocalized)
            {
                continue;
            }

            var entityAttributesToLocalize = entity
                .GetAttributesToLocalize();

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(entity.LocalizedName)
                .WithFileNamePrefix($"Domain")
                .WithObject("entity", entity)
                .WithObject("entityAttributesToLocalize", entityAttributesToLocalize)
                .GenerateSourceCodeFromResource("Domain.EntityLocalized");
        }
    }
}