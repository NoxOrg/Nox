using System.Collections.Generic;
using Nox.Yaml.Attributes;
using Nox.Types;
using YamlDotNet.Serialization;
using Nox.Yaml;
using System;

namespace Nox.Solution;


[AdditionalProperties(false)]
[GenerateJsonSchema]
public class JsonTypeDefinition : YamlConfigNode<NoxSolution,ApiRouteMapping>
{
    [Required]
    public string Name { get; internal set; } = null!;
    
    public string? Description { get; internal set; }
    
    [Required]
    public JsonType Type {get; internal set;}

    public bool IsRequired {get; internal set;} = false;

    public object? Default {get; internal set; }

    [IfEquals(nameof(Type),JsonType.Array)]
    [Required]
    public JsonTypeDefinition Items {get; internal set;} = null!;
 
    [IfEquals(nameof(Type),JsonType.Object)]
    [Required]
    public IReadOnlyList<JsonTypeDefinition> Attributes {get; internal set;} = null!;

    [YamlIgnore]
    public string JsonTypeString { get; internal set; } = null!;

    public override void SetDefaults(NoxSolution topNode, ApiRouteMapping parentNode, string yamlPath)
    {
        JsonTypeString = ToJsonTypeString(Type);
    }

    private static string ToJsonTypeString(JsonType type) 
    {
        return type switch
        {
            JsonType.Number => "number",
            JsonType.String => "string",
            JsonType.DateString => "string",
            JsonType.Boolean => "boolean",
            JsonType.Array => "array",
            JsonType.Object => "object",
            JsonType.Null => "null",
            _ => throw new NotImplementedException()
        };
    }

}