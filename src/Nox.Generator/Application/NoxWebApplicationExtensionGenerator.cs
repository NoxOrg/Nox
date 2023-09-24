using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application;

internal class NoxWebApplicationExtensionGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.None;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new CodeBuilder($"Application.NoxWebApplicationExtensions.g.cs", context);

        var usings = new List<string>();       

        var solution = codeGeneratorState.Solution;
        

        code.AppendLine("using Microsoft.EntityFrameworkCore;");               
        code.AppendLine("using System.Reflection;");
        code.AppendLine("using Microsoft.OData.ModelBuilder;");
        code.AppendLine("using Nox;");
        code.AppendLine("using Nox.Solution;");
        code.AppendLine("using Nox.Configuration;");        
        code.AppendLines(usings.ToArray());
        code.AppendLine("using Nox.Types.EntityFramework.Abstractions;");
        code.AppendLine($"using {solution.Name}.Infrastructure.Persistence;");
        if (config.Presentation)
            code.AppendLine($"using {solution.Name}.Presentation.Api.OData;");
        code.AppendLine();

        code.AppendLine("public static class NoxWebApplicationBuilderExtension");
        code.StartBlock();
        code.AppendLine(@"public static IServiceCollection AddNox(this IServiceCollection services)
                        {
                            return services.AddNox(null, null);
                        }
                        ");
        code.AppendLine("public static IServiceCollection AddNox(this IServiceCollection services, Action<INoxBuilderConfigurator>? configureNox, Action<ODataModelBuilder>? configureNoxOdata)");
        code.StartBlock();
        var dbContextName = $"{solution.Name}DbContext";

        code.AppendLine(@$"
        services.AddNoxLib(configurator => 
        {{
            configurator.WithDatabaseContexts<{dbContextName},DtoDbContext>();
            configurator.WithMessagingTransactionalOutbox<{dbContextName}>();
            configureNox?.Invoke(configurator);
        }});");                     
        code.AppendLine("services.AddNoxOdata(configureNoxOdata);");        
        code.AppendLine("return services;");
        code.EndBlock();
        code.AppendLine();

        code.EndBlock();

        code.GenerateSourceCode();
    }
}