using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types;
using Nox.Types.Extensions;
using System.Linq;
using System.Reflection;

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
            
            var typeDef = entity.GetAllMembers()
                .Select( t =>  GenerateStaticTypeOptions(t.Value, codeGeneratorState.Solution) )
                .ToList();
            
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(entity.Name)
                .WithFileNamePrefix($"Domain.Meta")
                .WithObject("entity", entity)
                .WithObject("typeDef", typeDef)
                .GenerateSourceCodeFromResource("Domain.EntityMeta");
        }
    }

    private EntityMetaData GenerateStaticTypeOptions(NoxSimpleTypeDefinition typeDef, NoxSolution solution)
    {
        var type = typeDef.Type == NoxType.EntityId ? solution.GetSingleKeyTypeForEntity(typeDef.EntityIdTypeOptions!.Entity) : typeDef.Type;

        var typeOptions = $"{type}TypeOptions";

        var options = typeof(NoxSimpleTypeDefinition).GetProperty(typeOptions);

        var optionsOutput = string.Empty;
        
        var optionsProperties = Array.Empty<string>();

        var components = type.GetComponents(typeDef).ToArray();

        var inParams = components.Length == 1 
            ? $"{components[0].Value.FullName} value" 
            : $"I{type} value" ;

       
        if (options != null)
        {
            optionsProperties = GetOptionsOutputAndProperties(typeDef, options, optionsProperties, ref optionsOutput);
        }
        
        return new EntityMetaData
        {
            Name = typeDef.Name,
            Type = type.ToString(),
            InParams = inParams,
            OptionsOutput = optionsOutput,
            OptionsProperties = optionsProperties
        };
    }

    private static string[] GetOptionsOutputAndProperties(
        NoxSimpleTypeDefinition typeDef, 
        PropertyInfo options,
        string[] optionsProperties, 
        ref string optionsOutput)
    {
        var optionsValue = options.GetValue(typeDef, null);

        if (optionsValue != null)
        {
            var output = optionsValue.ToSourceCode($"{typeDef.Name}TypeOptions {{get; private set;}}");
            var optionsOutputLines = output.Split('\n');
            optionsProperties = optionsOutputLines
                .SkipWhile(s => !s.StartsWith("{"))
                .Skip(1)
                .TakeWhile(s => !s.StartsWith("}"))
                .Select(s => s.Trim()).ToArray();
            optionsOutput = optionsOutputLines[0];
        }

        return optionsProperties;
    }
}