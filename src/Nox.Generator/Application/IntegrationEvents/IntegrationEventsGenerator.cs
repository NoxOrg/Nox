using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application;

internal class IntegrationEventsGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Application?.IntegrationEvents is null) 
            return;

        foreach (var integrationEvent in codeGeneratorState.Solution.Application.IntegrationEvents)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(integrationEvent.Name)
                .WithFileNamePrefix($"Application.IntegrationEvent")
                .WithObject("integrationEvent", integrationEvent)
                .GenerateSourceCodeFromResource("Application.IntegrationEvents.IntegrationEvent");
        }
    }
}
