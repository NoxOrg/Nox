using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Linq;

namespace Nox.Generator.Application.Dto;

internal class NoxTypeDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Dto.NoxTypeDto";

        var compoundTypes = Enum.GetValues(typeof(NoxType))
           .Cast<NoxType>()
           .Where( x => x.IsCompoundType() )
           .Select(x =>
           {
               var components = x.GetCompoundComponents().Select(c => c.Value + " " + c.Key);
               return new { NoxType = x, Components = components };
           })
           .ToArray();

        context.CancellationToken.ThrowIfCancellationRequested();

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName($"CompoundNoxTypes")
            .WithFileNamePrefix("Application.Dto")
            .WithObject("compoundTypes", compoundTypes)
            .GenerateSourceCodeFromResource(templateName);
    }
}