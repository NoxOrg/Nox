using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator;

internal static class ODataConfigurationGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }

        var code = new CodeBuilder($"ODataConfiguration.g.cs", context);

        // Namespace
        code.AppendLine($"using Microsoft.AspNetCore.Http;");
        code.AppendLine($"using Microsoft.AspNetCore.OData;");
        code.AppendLine($"using Microsoft.OData.ModelBuilder;");

        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
        code.AppendLine();

        code.AppendLine($"public partial class ODataConfiguration");

        // Class
        code.StartBlock();
        // Method
        code.AppendLine($"public static void Register(IServiceCollection services)");

        // Method content
        code.StartBlock();
        code.AppendLine($"ODataModelBuilder builder = new ODataConventionModelBuilder();");
        code.AppendLine();

        foreach (var entity in solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            code.AppendLine($"builder.EntitySet<{entity.Name}>(\"{entity.PluralName}\");");
        }

        code.AppendLine();
        code.AppendLine($"services.AddControllers()");
        code.Indent();
        code.AppendLine($".AddOData(options => ");
        code.StartBlock();
        code.AppendLine($"options.Select()");
        code.AppendLine($".Filter()");
        code.AppendLine($".OrderBy()");
        code.AppendLine($".Count()");
        code.AppendLine($".Expand()");
        code.AppendLine($".SkipToken()");
        code.AppendLine($".SetMaxTop(100);");
        code.AppendLine($"var routeOptions = options.AddRouteComponents(\"api\", builder.GetEdmModel()).RouteOptions;");
        code.AppendLine($"routeOptions.EnableKeyInParenthesis = false;");
        code.AppendLine($"routeOptions.EnableDollarCountRouting = false;");
        code.EndBlock();
        code.AppendLine($");");
        code.UnIndent();
        // End method
        code.EndBlock();

        // End class
        code.EndBlock();

        ODataModelGenerator.Generate(context, solutionNameSpace, solution);

        ODataDbContextGenerator.Generate(context, solutionNameSpace, solution);

        code.GenerateSourceCode();
    }
}