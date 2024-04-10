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

        foreach (var customTransformIntegration in codeGenConventions.Solution.Application.Integrations.Where(i => i.Transformation.Type == IntegrationTransformType.Mapping))
        {
            //Create the source Dto
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{customTransformIntegration.Name}SourceDto")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("transformation", customTransformIntegration.Transformation)
                .GenerateSourceCodeFromResource("Application.Integration.MappedTransformSourceDto");
            
            //Create the target dto
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{customTransformIntegration.Name}TargetDto")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("transformation", customTransformIntegration.Transformation)
                .GenerateSourceCodeFromResource("Application.Integration.MappedTransformTargetDto");
            
            //create the transformation class
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{customTransformIntegration.Name}TransformBase")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("integration", customTransformIntegration)
                .WithObject("sourceDtoName", $"{customTransformIntegration.Name}SourceDto")
                .WithObject("targetDtoName", $"{customTransformIntegration.Name}TargetDto")
                .GenerateSourceCodeFromResource("Application.Integration.MappedTransformBase");
        }
    }
}