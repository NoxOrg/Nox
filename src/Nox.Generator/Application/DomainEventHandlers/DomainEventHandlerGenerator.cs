using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Application;

internal class DomainEventHandlerGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain?.Entities is null)
            return;

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(e => e.HasIntegrationEvents))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(entity.Name)
                .WithFileNamePrefix($"Application.DomainEventHandlers")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource("Application.DomainEventHandlers.DomainEventHandler");
        }
    }
}
