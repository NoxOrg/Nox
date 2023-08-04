using Microsoft.CodeAnalysis;
using Nox.Solution;
using Nox.Types;
using System.Collections.Generic;
using Nox.Generator.Common;

namespace Nox.Generator.Application.DtoGenerator;

internal static class DtoGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Application?.DataTransferObjects == null) return;

        foreach (var dto in codeGeneratorState.Solution.Application.DataTransferObjects)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateDto(context, codeGeneratorState, dto.Name, dto.Description, dto.Attributes);
        }
    }

    public static void GenerateDto(SourceProductionContext context,
        NoxSolutionCodeGeneratorState codeGeneratorState,
        string name,
        string? description,
        IReadOnlyList<NoxSimpleTypeDefinition> attributes)
    {
        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName(name)
            .WithObject("dto", new { Name = name, Description = description, Attributes = attributes })
            .GenerateSourceCodeFromResource("Application.Templates.DtoModel");
    }
}