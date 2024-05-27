using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Cron;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Integration;

internal class IntegrationJobGenerator: INoxCodeGenerator
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

        foreach (var scheduledIntegration in codeGenConventions.Solution.Application.Integrations.Where(i => i.Schedule != null))
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{scheduledIntegration.Name}Job")
                .WithFileNamePrefix("Application.Integration.Jobs")
                .WithObject("integrationName", scheduledIntegration.Name)
                .WithObject("cronExpression", scheduledIntegration.Schedule!.Start.ToCronExpression().ToString())
                .GenerateSourceCodeFromResource("Application.Integration.IntegrationJob");
        }
    }
}