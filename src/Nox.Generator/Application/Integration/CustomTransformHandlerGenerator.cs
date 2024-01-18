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
        NoxCodeGenConventions codeGenConventions, 
        GeneratorConfig config, 
        Action<string> log, 
        string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Application?.Integrations is null)
        {
            if(config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
            {
                log("Skipping generator because no integrations defined");
            }
            return;
        }

        foreach (var customTransformIntegration in codeGenConventions.Solution.Application.Integrations.Where(i => i.TransformationType == IntegrationTransformType.CustomTransform))
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{customTransformIntegration.Name}TransformHandlerBase")
                .WithFileNamePrefix("Application.Integration.CustomTransformHandlers")
                .WithObject("integration", customTransformIntegration)
                .GenerateSourceCodeFromResource("Application.Integration.CustomTransformHandler");
        }
    }
}