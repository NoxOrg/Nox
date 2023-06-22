using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using System.Linq;
using System.Text;

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
        code.AppendLine($"using Microsoft.OData.ModelBuilder;");
        code.AppendLine($"using Microsoft.OData.Edm;");
        code.AppendLine($"using Microsoft.AspNetCore.Http;");
        code.AppendLine($"using SampleService.Domain;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
        code.AppendLine();

        code.AppendLine($"public partial class ODataConfiguration");

        // Class
        code.StartBlock();
            // Method
            code.AppendLine($"public static void Register(HttpConfiguration config)");
        
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
                code.AppendLine($"config.MapODataServiceRoute(");
                code.Indent();
                    code.AppendLine($"routeName: \"api\",");
                    code.AppendLine($"routePrefix: null,");
                    code.AppendLine($"model: builder.GetEdmModel());");
                    code.UnIndent();
            // End method
            code.EndBlock();
        // End class
        code.EndBlock();

        code.GenerateSourceCode();

    }
}
