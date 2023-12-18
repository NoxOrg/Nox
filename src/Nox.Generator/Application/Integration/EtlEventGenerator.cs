using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Integration;

internal class EtlEventGenerator: INoxCodeGenerator
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

        foreach (var integration in codeGeneratorState.Solution.Application.Integrations)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            //Find the entity this integration targets if any
            var targetDefinition = integration.Target;
            if (targetDefinition.TableOptions == null) continue;
            var domainDefinition = codeGeneratorState.Solution.Domain;
            if (domainDefinition == null) continue;
        
            var tableName = targetDefinition.TableOptions.TableName;
        
            //Find the entity from the table name
            var entity = domainDefinition.Entities.FirstOrDefault(e => e.Persistence.TableName!.Equals(tableName, StringComparison.OrdinalIgnoreCase));
            if (entity == null) continue;
            
            //Created Event Payload
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{integration.Name}RecordCreatedDto")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource("Application.Integration.EtlCreatedEventDto");
            
            //Created Event
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{integration.Name}RecordCreatedEvent")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("integration", integration)
                .GenerateSourceCodeFromResource("Application.Integration.EtlCreatedEvent");
            
            //Updated Event Payload
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{integration.Name}RecordUpdatedDto")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource("Application.Integration.EtlUpdatedEventDto");
            
            //Updated event
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{integration.Name}RecordUpdatedEvent")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("integration", integration)
                .GenerateSourceCodeFromResource("Application.Integration.EtlUpdatedEvent");
            
            
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{integration.Name}ExecuteCompletedEvent")
                .WithFileNamePrefix("Application.Integration.EtlEvents")
                .WithObject("integration", integration)
                .GenerateSourceCodeFromResource("Application.Integration.EtlCompletedEvent");
        }
    }
}