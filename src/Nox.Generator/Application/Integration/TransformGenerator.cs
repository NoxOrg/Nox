using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Integration.MappingHelpers;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Application.Integration;

internal class TransformGenerator: INoxCodeGenerator
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
        
        foreach (var integration in codeGenConventions.Solution.Application.Integrations)
        {
            List<TransformMappingBase>? mappingList = null;

            var hasSourceEntity = false;
            var hasTargetEntity = false;

            //Target
            var targetTableOptions = integration.Target.TableOptions;
            if (targetTableOptions != null)
            {
                var targetEntity = codeGenConventions.Solution.Domain?.GetEntityByTableName(integration.Target.TableOptions!.TableName);
                if (targetEntity != null)
                {
                    mappingList = NoxTableMappingHelper.MapToNoxTable(targetEntity);
                    hasTargetEntity = true;
                }
            }

            if (integration.Transformation?.Mapping != null && integration.Transformation.Mapping.Any())
            {
                ValidationHelper.ValidateMap(integration.Transformation!.Mapping!, mappingList);
                CustomMappingHelper.ApplyCustomMapping(mappingList, integration.Transformation!.Mapping!);
            }
            
            if (mappingList != null)
            {
                //Create the source Dto
                context.CancellationToken.ThrowIfCancellationRequested();
                new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"{integration.Name}SourceDto")
                    .WithFileNamePrefix("Application.Integration.Transform")
                    .WithObject("mappingList", mappingList.Where(w => w.Source != null).Select(s => s.Source).ToList())
                    .WithObject("hasEntity", hasSourceEntity)
                    .GenerateSourceCodeFromResource("Application.Integration.TransformSourceDto");


                //Create the target dto
                context.CancellationToken.ThrowIfCancellationRequested();
                new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"{integration.Name}TargetDto")
                    .WithFileNamePrefix("Application.Integration.Transform")
                    .WithObject("mappingList", mappingList.Where(w => w.Target != null).Select(s => s.Target).ToList())
                    .WithObject("hasEntity", hasTargetEntity)
                    .GenerateSourceCodeFromResource("Application.Integration.TransformTargetDto");

                //create the transformation class
                var mapperMethods = CustomMappingHelper.GetAutoMapperMethods(mappingList);
                context.CancellationToken.ThrowIfCancellationRequested();
                new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"{integration.Name}TransformBase")
                    .WithFileNamePrefix("Application.Integration.Transform")
                    .WithObject("integrationName", integration.Name)
                    .WithObject("mappings", CustomMappingHelper.GetAutoMapperMethods(mappingList))
                    .WithObject("sourceDtoName", $"{integration.Name}SourceDto")
                    .WithObject("targetDtoName", $"{integration.Name}TargetDto")
                    .GenerateSourceCodeFromResource("Application.Integration.TransformBase");
            }
        }
    }

    
}