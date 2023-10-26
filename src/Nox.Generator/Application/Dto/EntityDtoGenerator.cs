using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityDtoGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        NoxSolution solution = codeGeneratorState.Solution;
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null)
        {
            return;
        }

        foreach (var entity in codeGeneratorState.Solution.Domain!.Entities)
        {
            var primaryKeys = string.Join(", ", entity.Keys.Select(k => $"{codeGeneratorState.Solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));

            var enumerationAttributes = entity.Attributes.Where(attribute => attribute.Type == NoxType.Enumeration);

            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.Name}Dto")
                .WithFileNamePrefix("Application.Dto")
                .WithObject("entity", entity)
                .WithObject("primaryKeys", primaryKeys)    
                .WithObject("enumerationAttributes", enumerationAttributes)
                .GenerateSourceCodeFromResource("Application.Dto.EntityDto");         
        }        
    }
}