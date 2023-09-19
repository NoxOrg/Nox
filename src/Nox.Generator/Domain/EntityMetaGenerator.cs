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
            
            var entitiesMetaData = entity.GetAllMembers().GroupBy(m=>m.Value.Name).Select(g=>g.First())
                .Select( t =>  GeneraEntityMetaData(t.Value, codeGeneratorState.Solution) )
                .ToList();
            
            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName(entity.Name)
                .WithFileNamePrefix($"Domain.Meta")
                .WithObject("entity", entity)
                .WithObject("entitiesMetaData", entitiesMetaData)
                .GenerateSourceCodeFromResource("Domain.EntityMeta");

        }
    }

    private static EntityMetaData GeneraEntityMetaData(NoxSimpleTypeDefinition typeDef, NoxSolution solution)
    {
        var type = typeDef.Type == NoxType.EntityId ? solution.GetSingleKeyTypeForEntity(typeDef.EntityIdTypeOptions!.Entity) : typeDef.Type;

        var typeOptions = $"{type}TypeOptions";

        var options = typeof(NoxSimpleTypeDefinition).GetProperty(typeOptions);

        var optionProperties = new List<OptionProperty>(1);
        var components = type.GetComponents(typeDef).ToArray();

        var inParams = components.Length == 1 
            ? $"{components[0].Value.FullName} value" 
            : $"I{type} value" ;

       
        if (options != null)
        {
            optionProperties = GetTypeOptionPropertyList(typeDef, options);
            
        }
        
        return new EntityMetaData
        {
            Name = typeDef.Name,
            Type = type.ToString(),
            InParams = inParams,
            HasTypeOptions = optionProperties.Any(),
            OptionProperties = optionProperties,
        };
    }

    
    
    private static List<OptionProperty> GetTypeOptionPropertyList(
        NoxSimpleTypeDefinition typeDef, 
        PropertyInfo options)
    {
        var optionsProperties = new List<OptionProperty>(1);
        var optionsValue = options.GetValue(typeDef, null);

        if (optionsValue != null)
        {
            optionsProperties =   optionsValue.ToOptionProperties();
        }

        return optionsProperties;
    }
}