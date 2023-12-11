using System.Collections.Generic;
using Nox.Yaml.Attributes;
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

    public JsonFormat? Format { get; set; }

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

    [YamlIgnore]
    public string? JsonFormatString { get; internal set; } = null!;

    public override void SetDefaults(NoxSolution topNode, ApiRouteMapping parentNode, string yamlPath)
    {
        JsonTypeString = ToJsonTypeString(Type);

        if (Format.HasValue)
        {
            JsonFormatString = ToJsonFormatString(Format.Value);
        }
    }

    private static string ToJsonTypeString(JsonType type)
    {
        return type switch
        {
            JsonType.Number => "number",
            JsonType.Integer => "integer",
            JsonType.String => "string",
            JsonType.Boolean => "boolean",
            JsonType.Array => "array",
            JsonType.Object => "object",
            JsonType.Null => "null",
            _ => throw new NotImplementedException($"JsonType [{type}] has no mapping to a Json schema type defined.")
        };
    }
    private static string ToJsonFormatString(JsonFormat format)
    {
        return format switch
        {
            JsonFormat.Binary => "binary",
            JsonFormat.Byte => "byte",
            JsonFormat.Date => "date",
            JsonFormat.DateTime => "date-time",
            JsonFormat.Email => "email",
            JsonFormat.HostName => "hostname",
            JsonFormat.Ipv4 => "ipv4",
            JsonFormat.Ipv6 => "ipv6",
            JsonFormat.Password => "password",
            JsonFormat.Uri => "uri",
            JsonFormat.Uuid => "uuid",
            _ => throw new NotImplementedException($"JsonFormat [{format}] has no mapping to a Json schema format defined.")
        };
    }

}