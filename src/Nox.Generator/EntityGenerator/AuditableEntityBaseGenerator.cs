﻿using Humanizer;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using Nox.Types;
using System;
using System.Data.SqlTypes;
using System.Text;
using System.Threading;

namespace Nox.Generator;

internal class AuditableEntityBaseGenerator
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
        code.AppendLine($"public partial class AuditableEntityBase");
        code.AppendLine($"{{");

        code.Indent();

        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The date and time when this entity was first created (in Coordinated Universal Time).");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public DateTime CreatedAtUtc {{get; set;}}");

        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The user that created the entity.");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public string? CreatedBy {{get; set;}}");

        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The date and time when this entity was last updated (in Coordinated Universal Time).");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public DateTime? UpdatedAtUtc {{get; set;}}");

        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The user that last updated the entity.");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public string? UpdatedBy {{get; set;}}");

        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The date and time when this entity was deleted (in Coordinated Universal Time).");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public DateTime? DeletedAtUtc {{get; set;}}");

        code.AppendLine();
        code.AppendLine($"/// <summary>");
        code.AppendLine($"/// The user that deleted the entity.");
        code.AppendLine($"/// </summary>");
        code.AppendLine($"public string? DeletedBy {{get; set;}}");

        code.UnIndent();

        code.AppendLine($"}}");

        context.AddSource($"AuditableEntityBase.cs", SourceText.From(code.ToString(), Encoding.UTF8));
    }
}
