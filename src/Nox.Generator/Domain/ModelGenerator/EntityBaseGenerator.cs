using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace Nox.Generator;

internal class EntityBaseGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace)
    {
        var code = new CodeBuilder();

        code.AppendLine($"// Generated");
        code.AppendLine();
        code.AppendLine($"using System;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The base class for all domain entities.");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public partial class EntityBase");
        code.AppendLine($"{{");

        code.Indent();

        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The state of the entity as at this date.");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public DateTime AsAt {{get; set;}}");

        code.UnIndent();

        code.AppendLine($"}}");

        context.AddSource($"EntityBase.cs", SourceText.From(code.ToString(), Encoding.UTF8));
    }
}
