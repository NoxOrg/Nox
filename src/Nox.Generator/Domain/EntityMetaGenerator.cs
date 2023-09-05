using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types;
using Nox.Types.Extensions;
using System.Linq;

namespace Nox.Generator.Domain.ModelGenerator;

internal class EntityMetaGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null) return;

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var propertiesWithSource = entity.GetAllMembers()
                .Select( t => new { TypeDef = t.Value, Source = GenerateStaticTypeOptions(t.Value, codeGeneratorState.Solution) })
                .Where( t => t.Source != null)
                .ToList();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(entity.Name)
                .WithFileNamePrefix($"Domain.Meta")
                .WithObject("entity", entity)
                .WithObject("propertiesWithSource", propertiesWithSource)
                .GenerateSourceCodeFromResource("Domain.EntityMeta");
        }
    }

    private string? GenerateStaticTypeOptions(NoxSimpleTypeDefinition typeDef, NoxSolution solution)
    {

        var type = typeDef.Type == NoxType.EntityId ? solution.GetSingleKeyTypeForEntity(typeDef.EntityIdTypeOptions!.Entity) : typeDef.Type;

        var typeOptions = $"{type}TypeOptions";

        var options = typeof(NoxSimpleTypeDefinition).GetProperty(typeOptions);

        var optionsOutput = string.Empty;

        var components = type.GetComponents(typeDef).ToArray();

        var inParams = components.Length == 1 
            ? $"{components[0].Value.FullName} value" 
            : $"I{type} value" ;

        string? factoryOutput;

        if (options != null)
        {
            var optionsValue = options.GetValue(typeDef, null);

            if (optionsValue != null)
            {
                optionsOutput = "public static " +
                    optionsValue.ToSourceCode($"{typeDef.Name}TypeOptions {{get; private set;}}") + "\r\n";

                factoryOutput =
                    $"public static {type} Create{typeDef.Name}({inParams})\r\n" +
                    $"    => Nox.Types.{type}.From(value, {typeDef.Name}TypeOptions);" +
                    $"\r\n\r\n";

                return optionsOutput + factoryOutput;
            }
        }

        factoryOutput =
            $"public static Nox.Types.{type} Create{typeDef.Name}({inParams})\r\n" +
            $"    => Nox.Types.{type}.From(value);" +
            $"\r\n\r\n";

        return optionsOutput + factoryOutput;
    }
}