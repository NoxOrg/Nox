using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;

namespace Nox.Generator.Application.Integration;

internal class EtlEventGenerator: INoxCodeGenerator
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
            context.CancellationToken.ThrowIfCancellationRequested();
            //Find the entity this integration targets if any
            var targetDefinition = integration.Target;
            if (targetDefinition.TableOptions == null) continue;
            var domainDefinition = codeGenConventions.Solution.Domain;
            if (domainDefinition == null) continue;
        
            var tableName = targetDefinition.TableOptions.TableName;
        
            //Find the entity from the table name
            if (!domainDefinition.HasEntity(tableName)) continue;
            var entity = domainDefinition.GetEntityByTableName(tableName);
            
            //Created Event Payload
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{integration.Name}RecordCreatedDto")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("entity", entity!)
                .GenerateSourceCodeFromResource("Application.Integration.EtlCreatedEventDto");
            
            //Created Event
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{integration.Name}RecordCreatedEvent")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("integration", integration)
                .GenerateSourceCodeFromResource("Application.Integration.EtlCreatedEvent");
            
            //Updated Event Payload
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{integration.Name}RecordUpdatedDto")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("entity", entity!)
                .GenerateSourceCodeFromResource("Application.Integration.EtlUpdatedEventDto");
            
            //Updated event
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{integration.Name}RecordUpdatedEvent")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("integration", integration)
                .GenerateSourceCodeFromResource("Application.Integration.EtlUpdatedEvent");
            
            
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{integration.Name}ExecuteCompletedEvent")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("integration", integration)
                .GenerateSourceCodeFromResource("Application.Integration.EtlCompletedEvent");
        }
    }
}