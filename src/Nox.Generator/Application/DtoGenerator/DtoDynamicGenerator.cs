using Microsoft.CodeAnalysis;
using Nox.Solution;
using Nox.Types;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nox.Generator.Common;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Application.DtoGenerator;

// TODO Rethink custom commands and queries
internal class DtoDynamicGenerator// : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config, string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Application?.DataTransferObjects == null) return;

        foreach (var dto in codeGeneratorState.Solution.Application.DataTransferObjects)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            GenerateDto(context, codeGeneratorState, dto);
        }
    }

    public static void GenerateDto(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, string name, string? description, IReadOnlyList<NoxSimpleTypeDefinition> attributes)
    {
        var code = new CodeBuilder($"DtoDynamic.{name}.g.cs", context);

        code.AppendLine($"// Generated by {nameof(DtoDynamicGenerator)}::{MethodBase.GetCurrentMethod()!.Name}");
        code.AppendLine();
        //NOTE: this must point to the Nox abstractions
        code.AppendLine($"using Nox.Abstractions;");
        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.DataTransferObjectsNameSpace};");
        code.AppendLine();

        GenerateDocs(code, description);

        code.AppendLine($"public partial class {name} : IDynamicDto");
        code.StartBlock();

        GenerateProperties(context, code, attributes);

        code.EndBlock();

        code.GenerateSourceCode();
    }

    private static void GenerateDto(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, DataTransferObject dto)
    {
        var className = dto.Name.EnsureEndsWith("Dto");
        var code = new CodeBuilder($"DtoDynamic.{dto.Name}.g.cs", context);

        code.AppendLine($"// Generated by {nameof(DtoDynamicGenerator)}::{MethodBase.GetCurrentMethod()!.Name}");
        code.AppendLine();
        //NOTE: this must point to the Nox abstractions
        code.AppendLine($"using Nox.Abstractions;");
        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.DataTransferObjectsNameSpace};");

        GenerateDocs(code, dto.Description ?? "It's good practice to give a proper description of your dto's");

        code.AppendLine($"public partial class {className} : IDynamicDto");
        code.StartBlock();

        GenerateProperties(context, code, dto.Attributes);

        code.EndBlock();

        code.GenerateSourceCode();
    }

    private static void GenerateProperties(SourceProductionContext context, CodeBuilder code, IEnumerable<NoxSimpleTypeDefinition> attributes)
    {
        var attributesList = attributes.ToList();
        for (int i = 0; i < attributesList.Count; i++)
        {
            var attribute = attributesList[i];
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateDocs(code, attribute.Description);

            var propType = attribute.Type;
            var propName = attribute.Name;
            var nullable = attribute.IsRequired ? string.Empty : "?";

            code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");

            if (i != attributesList.Count - 1)
            {
                code.AppendLine();
            }
        }
    }
}