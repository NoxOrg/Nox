using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;

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

        foreach (var integration in codeGenConventions.Solution.Application.Integrations.Where(i => i.Transformation?.Mapping != null))
        {
            //Create the source Dto
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{integration.Name}SourceDto")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("transformation", integration.Transformation!)
                .GenerateSourceCodeFromResource("Application.Integration.TransformSourceDto");
            
            ValidateMap(integration.Transformation!.Mapping!);

            var hasEntity = false;
            if (integration.Target.TableOptions != null)
            {
                hasEntity = codeGenConventions.Solution.Domain?.GetEntityByTableName(integration.Target.TableOptions!.TableName) != null;
            }
            
            //TODO: If we can get the source or target definitions, i.e. tables, we can get the table definition, then we can generate the dtos from this instead of the mapping. Mapping will override the definitions
            //Create the target dto
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{integration.Name}TargetDto")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("transformation", integration.Transformation)
                .WithObject("hasEntity", hasEntity)
                .GenerateSourceCodeFromResource("Application.Integration.TransformTargetDto");
            
            //create the transformation class
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{integration.Name}TransformBase")
                .WithFileNamePrefix("Application.Integration.CustomTransform")
                .WithObject("integration", integration)
                .WithObject("sourceDtoName", $"{integration.Name}SourceDto")
                .WithObject("targetDtoName", $"{integration.Name}TargetDto")
                .GenerateSourceCodeFromResource("Application.Integration.TransformBase");
        }
    }

    private void ValidateMap(IReadOnlyList<IntegrationMapping> mapping)
    {
        if (mapping.Any(m => m.Target.Name!.Equals("etag", StringComparison.OrdinalIgnoreCase)))
        {
            throw new Exception("Integrations that target a Nox entity table are not allowed to have a mapping for the Etag attribute!");
        }

        foreach (var map in mapping)
        {
            if (map.Source != null)
            {
                var validMapping = MappingConstants.ValidMappings[map.Source.Type.ToString().ToLower()];
                if (!validMapping.Contains(map.Target.Type.ToString().ToLower()))
                {
                    throw new Exception($"Mapping from {map.Source.Type.ToString()} to {map.Target.Type.ToString()} is not allowed in a Nox integration mapping!");
                }    
            }
        }
        
        
    }
}