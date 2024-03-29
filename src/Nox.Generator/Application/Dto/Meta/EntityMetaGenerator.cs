using System;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types;
using Nox.Types.Extensions;
using System.Linq;
using System.Reflection;

namespace Nox.Generator.Application.Dto.Meta;

internal class EntityMetaGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.ApplicationDto;
    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null) return;

        foreach (var entity in codeGenConventions.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var entitiesMetaData = entity.GetAllMembers().GroupBy(m => m.Value.Name).Select(g => g.First())
                .Select(t => GenerateEntityMetaData(t.Value, codeGenConventions.Solution))
                .ToList();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{entity.Name}Metadata")
                .WithFileNamePrefix("Application.Dto.Meta")
                .WithObject("entity", entity)
                .WithObject("entitiesMetaData", entitiesMetaData)
                .GenerateSourceCodeFromResource("Application.Dto.Meta.EntityMeta");
        }
    }

    private static EntityMetaData GenerateEntityMetaData(NoxSimpleTypeDefinition typeDef, NoxSolution solution)
    {
        var type = typeDef.Type == NoxType.EntityId ? solution.GetSingleKeyTypeForEntity(typeDef.EntityIdTypeOptions!.Entity) : typeDef.Type;

        var typeOptions = $"{type}TypeOptions";

        var options = typeof(NoxSimpleTypeDefinition).GetProperty(typeOptions);

        var optionsProperties = Array.Empty<string>();
        var components = type.GetComponents(typeDef).ToArray();

        var inParams = components.Length == 1
            ? $"{components[0].Value.FullName} value"
            : $"I{type} value";


        if (options != null)
        {
            optionsProperties = GetTypeOptionProperties(typeDef, options);
        }

        return new EntityMetaData
        {
            Name = typeDef.Name,
            Type = type.ToString(),
            InParams = inParams,
            HasTypeOptions = optionsProperties.Any(),
            OptionsProperties = optionsProperties
        };
    }

    private static string[] GetTypeOptionProperties(
        NoxSimpleTypeDefinition typeDef,
        PropertyInfo options)
    {
        var optionsProperties = Array.Empty<string>();
        var optionsValue = options.GetValue(typeDef, null);

        if (optionsValue != null)
        {
            var output = optionsValue.ToSourceCode($"{typeDef.Name}TypeOptions {{get; private set;}}");
            var optionsOutputLines = output.Split('\n');
            optionsProperties = optionsOutputLines
                .SkipWhile(s => !s.StartsWith("{"))
                .Skip(1)
                .TakeWhile(s => !s.StartsWith("}"))
                .Select(s => s.TrimEnd())
                .ToArray();
        }

        return optionsProperties;
    }
}