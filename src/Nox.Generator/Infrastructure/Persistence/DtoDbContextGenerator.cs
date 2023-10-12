using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Infrastructure.Persistence;

internal class DtoDbContextGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Infrastructure;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        NoxSolution solution = codeGeneratorState.Solution;

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }

        const string className = $"DtoDbContext";
        const string templateName = @"Infrastructure.Persistence.DtoDbContext";
        var entities = solution.Domain.Entities.Where(e => !e.IsOwnedEntity).ToList();
        
        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName(className)
            .WithFileNamePrefix($"Infrastructure.Persistence")
            .WithObject("entities", entities)
            .GenerateSourceCodeFromResource(templateName);
    }
}
