using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nox.Generator.Application.Extensions;

internal class NoxTypeDtoExtensionsGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;
    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var compoundTypes = Enum.GetValues(typeof(NoxType))
           .Cast<NoxType>()
           .Where(noxType => noxType.IsCompoundType())
           .Select(noxType =>
           {
               var noxTypeComponents = GetNoxTypeCompoundComponents(noxType);
               return new { NoxType = noxType, Components = noxTypeComponents };
           })
           .ToArray();

        context.CancellationToken.ThrowIfCancellationRequested();

        new TemplateCodeBuilder(context, codeGeneratorState)
            .WithClassName("CompoundNoxTypesExtensions")
            .WithFileNamePrefix("Application.Extensions")
            .WithObject("compoundTypes", compoundTypes)
            .GenerateSourceCodeFromResource("Application.Extensions.NoxTypeDtoExtensions");
    }

    private static IEnumerable<string> GetNoxTypeCompoundComponents(NoxType noxType)
    {
        return noxType
            .ToMemberInfo()
            .GetCustomAttributes<CompoundComponent>()
            .Select(c => $"{noxType}.{c.Name}!");
    }
}