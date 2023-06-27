using Microsoft.CodeAnalysis;

namespace Nox.Generator;

internal class EntityBaseGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        var code = new CodeBuilder($"EntityBase.g.cs", context);

        code.AppendLine($"using System;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The base class for all domain entities.");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public partial class EntityBase");

        code.StartBlock();

        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The state of the entity as at this date.");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public DateTime AsAt {{get; set;}}");

        code.EndBlock();

        code.GenerateSourceCode();

    }
}
