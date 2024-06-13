using System.Collections.Generic;
using System.Linq;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;

namespace Nox.Generator.Application.Integration.MappingHelpers;

internal static class NoxTableMappingHelper
{
    internal static List<TransformMappingBase> MapToNoxTable(Entity targetEntity)
    {
        var result = new List<TransformMappingBase>();
        foreach (var key in targetEntity.Keys)
        {
            result.AddRange(ExtractNoxTypeDefinition(key, true));
        }

        foreach (var attr in targetEntity.Attributes)
        {
            result.AddRange(ExtractNoxTypeDefinition(attr, attr.IsRequired));
        }

        return result;
    }

    private static List<TransformMappingBase> ExtractNoxTypeDefinition(NoxSimpleTypeDefinition noxType, bool isRequired)
    {
        var result = new List<TransformMappingBase>();
        if (noxType.Type.IsSimpleType())
        {
            var simpleComponent = noxType.Type.GetComponents(noxType);
            var isNullable = !isRequired;
            var transformType = simpleComponent.First().Value.ToTransformDataType(isNullable);
            result.Add(new TransformMappingBase
            {
                IsNullable = isNullable,
                Source = new TransformMappingField
                {
                    Name = noxType.Name,
                    DataType = transformType.type,
                    DataTypeName = transformType.typeName,
                    Default = transformType.defaultValue
                },
                Target = new TransformMappingField
                {
                    Name = noxType.Name,
                    DataType = transformType.type,
                    DataTypeName = transformType.typeName,
                    Default = transformType.defaultValue
                }
            });
            
        } else if (noxType.Type.IsCompoundType())
        {
            var compoundComponents = noxType.Type.GetCompoundComponents();
            foreach (var component in compoundComponents)
            {
                var isNullable = !isRequired;
                var transformType = component.Value.ToTransformDataType(isNullable);
                result.Add(new TransformMappingBase
                {
                    IsNullable = !isRequired,
                    Source = new TransformMappingField
                    {
                        Name = noxType.Name + '_' + component.Key,
                        DataType = transformType.type,
                        DataTypeName = transformType.typeName,
                        Default = transformType.defaultValue
                    },
                    Target = new TransformMappingField
                    {
                        Name = noxType.Name + '_' + component.Key,
                        DataType = transformType.type,
                        DataTypeName = transformType.typeName,
                        Default = transformType.defaultValue
                    }
                });
            }
        }

        return result;
    }
}