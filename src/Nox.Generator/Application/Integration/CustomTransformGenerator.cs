using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Integration;

internal class CustomTransformGenerator: INoxCodeGenerator
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

        foreach (var customTransformIntegration in codeGenConventions.Solution.Application.Integrations.Where(i => i.Transformation.Type == IntegrationTransformType.Custom))
        {
            //create the transformation class
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{customTransformIntegration.Name}TransformBase")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("integration", customTransformIntegration)
                .GenerateSourceCodeFromResource("Application.Integration.CustomTransformBase");
        }
        
        foreach (var customTransformIntegration in codeGenConventions.Solution.Application.Integrations.Where(i => i.Transformation.Type == IntegrationTransformType.CustomMap))
        {
            //Create the source Dto
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{customTransformIntegration.Name}SourceDto")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("transformation", customTransformIntegration.Transformation)
                .GenerateSourceCodeFromResource("Application.Integration.CustomMapTransformSourceDto");
            
            //Create the target dto
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{customTransformIntegration.Name}TargetDto")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("transformation", customTransformIntegration.Transformation)
                .GenerateSourceCodeFromResource("Application.Integration.CustomMapTransformTargetDto");
            
            //create the transformation class
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{customTransformIntegration.Name}TransformBase")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("integration", customTransformIntegration)
                .GenerateSourceCodeFromResource("Application.Integration.CustomMapTransformBase");
        }
    }
}