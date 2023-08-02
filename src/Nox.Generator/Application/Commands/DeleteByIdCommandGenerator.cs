using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Commands;

internal static class DeleteByIdCommandGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Commands.DeleteByIdCommand";        
        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"Delete{entity.Name}ByIdCommand")
                .WithFileNamePrefix($"Commands")
                .WithObject("entity", entity)
                .WithObject("isVersioned", (entity.Persistence?.IsVersioned ?? true))
                .GenerateSourceCodeFromResource(templateName);

        }
    }
}