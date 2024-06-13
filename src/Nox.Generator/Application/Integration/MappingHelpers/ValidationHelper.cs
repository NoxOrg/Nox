using System;
using System.Collections.Generic;
using System.Linq;
using Nox.Solution;

namespace Nox.Generator.Application.Integration.MappingHelpers;

internal static class ValidationHelper
{
    internal static void ValidateMap(IReadOnlyList<IntegrationMapping> mapping, List<TransformMappingBase>? mappingList)
    {
        if (mapping.Any(m => m.Target != null &&  m.Target.Name!.Equals("etag", StringComparison.OrdinalIgnoreCase)))
        {
            throw new Exception("Integrations that target a Nox entity table are not allowed to have a mapping for the Etag attribute!");
        }

        foreach (var map in mapping)
        {
            if (map.Source != null && map.Target != null)
            {
                var validMapping = MappingConstants.ValidMappings[map.Source.Type.ToString().ToLower()];
                if (map.Target.Type != null && !validMapping.Contains(map.Target.Type.ToString().ToLower()))
                {
                    throw new Exception($"Mapping from {map.Source.Type.ToString()} to {map.Target.Type.ToString()} is not allowed in a Nox integration mapping!");
                }    
            }
        }
        
        //If there is a mapping list then the custom mapping targets must exist
        if (mappingList != null && mapping.Any())
        {
            foreach (var map in mapping)
            {
                if (map.Target != null)
                {
                    if (mappingList.All(t => t.Target?.Name!.Equals(map.Target.Name, StringComparison.OrdinalIgnoreCase) != true))
                    {
                        throw new Exception($"Mapping to target field '{map.Target.Name}' is invalid. The field does not exist on the target!");
                    }
                }
            }
        }
    }
}