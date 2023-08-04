using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Linq;

namespace Nox.Generator.Application.Dto;

internal static class NoxTypeDtoGenerator
{
    public static void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Dto.NoxTypeDto";

        var compoundTypes = Enum.GetValues(typeof(NoxType))
           .Cast<NoxType>()
           .Select(x =>
           {
               var components = x.GetCompoundComponents().Select(c => c.Value + " " + c.Key);
               return new { NoxType = x, Components = components };
           })
           .Where(x => x.Components.Count() > 1).ToArray();


        context.CancellationToken.ThrowIfCancellationRequested();

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName($"Dto")
            .WithFileNamePrefix($"NoxTypes")
            .WithObject("compoundTypes", compoundTypes)
            //.WithObject("components", compound.Components)
            .GenerateSourceCodeFromResource(templateName);
    }
}