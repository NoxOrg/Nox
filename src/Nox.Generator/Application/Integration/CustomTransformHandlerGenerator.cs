using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Integration;

internal class CustomTransformHandlerGenerator: INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;
    
    public void Generate(
        SourceProductionContext context, 
        NoxCodeGenConventions codeGeneratorState, 
        GeneratorConfig config, 
        Action<string> log, 
        string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Application?.Integrations is null)
        {
            if(config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
            {
                log("Skipping generator because no integrations defined");
            }
            return;
        }

        foreach (var customTransformIntegration in codeGeneratorState.Solution.Application.Integrations.Where(i => i.TransformationType == IntegrationTransformType.CustomTransform))
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{customTransformIntegration.Name}CustomTransformHandlerBase")
                .WithFileNamePrefix("Application.Integration.CustomTransformHandlers")
                .WithObject("integration", customTransformIntegration)
                .GenerateSourceCodeFromResource("Application.Integration.CustomTransformHandler");
        }
    }
}