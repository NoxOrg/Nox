using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nox.Generator.Application.Dto;

internal class NoxTypeDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.ApplicationDto;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Application.Dto.NoxTypeDto";

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

        new TemplateCodeBuilder(context, codeGenConventions)
            .WithClassName($"CompoundNoxTypes")
            .WithFileNamePrefix("Application.Dto")
            .WithObject("compoundTypes", compoundTypes)
            .GenerateSourceCodeFromResource(templateName);
    }
    private static IEnumerable<CompoundComponent> GetNoxTypeCompoundComponents(NoxType noxType)
    {
        return noxType
            .ToMemberInfo()
            .GetCustomAttributes<CompoundComponent>();
    }
}