using System;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Presentation.Api.OData;

internal class NoxIntegrationControllerGenerator: INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;
    
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

        context.CancellationToken.ThrowIfCancellationRequested();
        new TemplateCodeBuilder(context, codeGenConventions)
            .WithClassName("NoxIntegrationController")
            .WithFileNamePrefix("Presentation.Api.OData")
            .WithObject("integrations", codeGenConventions.Solution.Application.Integrations)
            .GenerateSourceCodeFromResource("Presentation.Api.OData.NoxIntegrationController");
    }
}