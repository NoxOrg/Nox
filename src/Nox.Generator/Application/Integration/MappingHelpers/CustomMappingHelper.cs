using System;
using System.Collections.Generic;
using System.Linq;
using Nox.Solution;

namespace Nox.Generator.Application.Integration.MappingHelpers;

internal static class CustomMappingHelper
{
    internal static void ApplyCustomMapping(List<TransformMappingBase>? mappingList, IReadOnlyList<IntegrationMapping> customMap)
    {
        mappingList ??= new List<TransformMappingBase>();
        foreach (var map in customMap)
        {
            TransformMappingBase? mapListItem = null;
            var isNullable = !map.IsRequired;

            if (map.Target != null)
            {
                mapListItem = mappingList.FirstOrDefault(m => m.Target?.Name!.Equals(map.Target.Name, StringComparison.OrdinalIgnoreCase) == true);
            }

            if (mapListItem == null && map.Source != null)
            {
                mapListItem = mappingList.FirstOrDefault(m => m.Source?.Name!.Equals(map.Source.Name, StringComparison.OrdinalIgnoreCase) == true);
            }

            if (mapListItem == null)
            {
                mapListItem = new TransformMappingBase
                {
                    IsNullable = isNullable,
                };
                if (map.Source != null)
                {
                    var sourceType = map.Source.Type!.Value.ToTransformDataType(isNullable);
                    mapListItem.Source = new TransformMappingField
                    {
                        Name = map.Source.Name,
                        DataType = sourceType.type,
                        DataTypeName = sourceType.typeName,
                        Default = sourceType.defaultValue
                    };
                }

                if (map.Target != null)
                {
                    mapListItem.Target = new TransformMappingField
                    {
                        Name = map.Target.Name
                    };
                    if (map.Target.Type == null) continue;
                    var targetType = map.Target.Type!.Value.ToTransformDataType(isNullable);
                    mapListItem.Target.DataType = targetType.type;
                    mapListItem.Target.DataTypeName = targetType.typeName;
                    mapListItem.Target.Default = targetType.@defaultValue;
                }
                mappingList.Add(mapListItem);
            }
            else
            {
                if (map.Target != null)
                {
                    if (mapListItem.Target == null)
                    {
                        if (map.Target.Type == null) throw new Exception($"Target attribute '{map.Target.Name}' does not have a type specified");
                        var targetType = map.Target.Type!.Value.ToTransformDataType(isNullable);
                        mapListItem.Target = new TransformMappingField
                        {
                            Name = map.Target.Name,
                            DataType = targetType.type,
                            DataTypeName = targetType.typeName,
                            Default = targetType.@defaultValue
                        };
                    }
                    else
                    {
                        mapListItem.Target.Name = map.Target.Name;
                        if (map.Target.Type != null)
                        {
                            var targetType = map.Target.Type!.Value.ToTransformDataType(isNullable);
                            mapListItem.Target.DataType = targetType.type;
                            mapListItem.Target.DataTypeName = targetType.typeName;
                            mapListItem.Target.Default = targetType.@defaultValue;
                        }
                        
                    }
                }
                
                //Scale the source to the target if available
                if (map.Source != null)
                {
                    var sourceType = map.Source.Type!.Value.ToTransformDataType(isNullable);
                    if (mapListItem.Source == null)
                    {
                        mapListItem.Source = new TransformMappingField
                        {
                            Name = map.Source.Name,
                            DataType = sourceType.type,
                            DataTypeName = sourceType.typeName,
                            Default = sourceType.@defaultValue
                        };
                    }
                    else
                    {
                        mapListItem.Source.Name = map.Source.Name;
                        mapListItem.Source.DataType = sourceType.type;
                        mapListItem.Source.DataTypeName = sourceType.typeName;
                        mapListItem.Source.Default = sourceType.@defaultValue;
                    }
                }

                
            }
        }
    }

    internal static List<string> GetAutoMapperMethods(List<TransformMappingBase>? mappingList)
    {
        var result = new List<string>();
        if (mappingList == null) return result;
        foreach (var mapping in mappingList)
        {
            if (mapping.Source != null && mapping.Target != null)
            {
                if (string.IsNullOrWhiteSpace(mapping.Source.DataTypeName) && string.IsNullOrWhiteSpace(mapping.Target.DataTypeName)) continue;
                var sourceType = mapping.Source.DataType;
                var targetType = mapping.Target.DataType;
                if (sourceType == null) sourceType = targetType;
                if (targetType == null) targetType = sourceType;

                var srcMethod = "";
                switch (sourceType)
                {
                    case MappingDataType.DateOnly:
                        switch (targetType)
                        {
                            case MappingDataType.DateTime:
                                srcMethod = mapping.IsNullable ? $"src == null ? (DateTime?)null : src.{mapping.Source.Name}.ToDateTime(new TimeOnly(0,0))" : $"src.{mapping.Source.Name}.ToDateTime(new TimeOnly(0,0))";
                                break;
                            default:
                                srcMethod = $"src.{mapping.Source.Name}";
                                break;
                        }
                        break;
                    case MappingDataType.DateTime:
                        switch (targetType)
                        {
                            case MappingDataType.DateOnly:
                                srcMethod = mapping.IsNullable ? $"src == null ? (DateOnly?)null : DateOnly.FromDateTime(src.{mapping.Source.Name})" : $"DateOnly.FromDateTime(src.{mapping.Source.Name})";
                                break;
                            case MappingDataType.TimeOnly:
                                srcMethod = mapping.IsNullable ? $"src == null ? (TimeOnly?)null : TimeOnly.FromDateTime(src.{mapping.Source.Name})" : $"TimeOnly.FromDateTime(src.{mapping.Source.Name})";
                                break;
                            default:
                                srcMethod = $"src.{mapping.Source.Name}";
                                break;
                        }
                        break;
                    case MappingDataType.String:
                        switch (targetType)
                        {
                            case MappingDataType.Int16:
                            case MappingDataType.Int32:
                            case MappingDataType.Int64:
                            case MappingDataType.UIn16:
                            case MappingDataType.UInt32:
                            case MappingDataType.UInt64:
                                srcMethod = mapping.IsNullable ? $"string.IsNullOrWhiteSpace(src.{mapping.Source.Name}) ? (int?)null : int.Parse(src.{mapping.Source.Name})" : $"int.Parse(src.{mapping.Source.Name})";
                                break;
                            case MappingDataType.Decimal:
                            case MappingDataType.Double:
                                srcMethod = mapping.IsNullable ? $"string.IsNullOrWhiteSpace(src.{mapping.Source.Name}) ? (double?)null : double.Parse(src.{mapping.Source.Name})" : $"double.Parse(src.{mapping.Source.Name})";
                                break;
                            case MappingDataType.Boolean:
                                srcMethod = mapping.IsNullable ? $"string.IsNullOrWhiteSpace(src.{mapping.Source.Name}) ? (bool?)null : bool.Parse(src.{mapping.Source.Name})" : $"bool.Parse(src.{mapping.Source.Name})";
                                break;
                            case MappingDataType.String:
                                srcMethod = mapping.IsNullable ? $"string.IsNullOrWhiteSpace(src.{mapping.Source.Name}) ? (string?)null : src.{mapping.Source.Name}" : $"src.{mapping.Source.Name}";
                                break;
                            case MappingDataType.DateOnly:
                                srcMethod = mapping.IsNullable ? $"string.IsNullOrWhiteSpace(src.{mapping.Source.Name}) ? (DateOnly?)null : DateOnly.Parse(src.{mapping.Source.Name})" : $"DateOnly.Parse(src.{mapping.Source.Name})";
                                break;
                            case MappingDataType.TimeOnly:
                                srcMethod = mapping.IsNullable ? $"string.IsNullOrWhiteSpace(src.{mapping.Source.Name}) ? (TimeOnly?)null : TimeOnly.Parse(src.{mapping.Source.Name})" : $"TimeOnly.Parse(src.{mapping.Source.Name})";
                                break;
                            case MappingDataType.DateTime:
                                srcMethod = mapping.IsNullable ? $"string.IsNullOrWhiteSpace(src.{mapping.Source.Name}) ? (DateTime?)null : DateTime.Parse(src.{mapping.Source.Name})" : $"DateTime.Parse(src.{mapping.Source.Name})";
                                break;
                            case MappingDataType.Guid:
                                srcMethod = mapping.IsNullable ? $"string.IsNullOrWhiteSpace(src.{mapping.Source.Name}) ? (Guid?)null : Guid.Parse(src.{mapping.Source.Name})" : $"Guid.Parse(src.{mapping.Source.Name})";
                                break;
                            default:
                                srcMethod = $"src.{mapping.Source.Name}";
                                break;
                        }
                        break;
                    default:
                        srcMethod = $"src.{mapping.Source.Name}";
                        break;
                }
                
                var memberMethod = $".ForMember(dest => dest.{mapping.Target.Name}, opt => opt.MapFrom(src => {srcMethod}))";
            
                result.Add(memberMethod);    
            }
        }
        return result;
    }
}