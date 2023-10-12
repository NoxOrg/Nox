using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Schema;

internal class SchemaValidator
{

    private readonly List<string> _errors = new();
    internal IReadOnlyList<string> Errors => _errors;

    internal void Validate(Dictionary<string, (object? Value, YamlLineInfo LineInfo)> objectInstance, SchemaProperty schemaProperty)
    {
        if (objectInstance is null || schemaProperty is null)
        {
            return;
        }

        var requiredProperties = schemaProperty.Required ?? Enumerable.Empty<string>();

        // Check all required properties exist
        foreach (var required in requiredProperties)
        {
            if (objectInstance.TryGetValue(required, out var val) && val.Value is not null)
                continue;

            var lineInfo = val.LineInfo ?? objectInstance.Values.FirstOrDefault().LineInfo;

            var instance = ToShortString(objectInstance);
            var fileInfo = ToFileInfoString(lineInfo);

            _errors.Add($"Missing property [\"{required}\"] on instance [{instance}] of type [{schemaProperty.ActualType}] is required. {fileInfo}");
        }

        // Check for disallowed additionalProperties
        if (schemaProperty.AdditionalProperties == false)
        {
            var allowedProperties = schemaProperty
                .GetChildSchemaProperties(objectInstance)
                .Select(p => p.Name)
                ?? Enumerable.Empty<string>();

            foreach (var prop in objectInstance)
            {
                if (allowedProperties.Contains(prop.Key))
                    continue;

                var instance = ToShortString(objectInstance);
                var fileInfo = ToFileInfoString(prop.Value.LineInfo);

                _errors.Add($"Disallowed property [\"{prop.Key}\"] on instance [{instance}] of type [{schemaProperty.ActualType}]. {fileInfo}");
            }
        }

        // Recurse
        foreach (var property in schemaProperty.GetChildSchemaProperties(objectInstance))
        {
            if (property.Ignore)
            {
                continue;
            }

            if (property.IsAnyOfSchema)
            {
                Validate(objectInstance, property);
            }

            if (!objectInstance.TryGetValue(property.Name!, out var obj))
            {
                continue;
            }

            if (property.Type == "object")
            {
                var obj2 = (Dictionary<string, (object? Value, YamlLineInfo LineInfo)>)obj.Value!;
                Validate(obj2, property);
            }
            else if (property.Type == "array"
                && property.UnderlyingType.IsGenericType
                && property.Items is not null
                && property.Items.Type == "object")
            {
                foreach (var item in (IList)obj.Value!)
                {
                    var obj2 = (Dictionary<string, (object? Value, YamlLineInfo LineInfo)>)item;
                    Validate(obj2, property.Items);
                }
            }

            // Check for valid enumerators
            else if (property.Enum is not null && property.Name is not null)
            {
                if (objectInstance.TryGetValue(property.Name, out var val) && val.Value is string strVal)
                {
                    if (!property.Enum.Contains(strVal))
                    {
                        var instance = ToShortString(objectInstance);
                        var fileInfo = ToFileInfoString(val.LineInfo);

                        _errors.Add($"Invalid value [\"{strVal}\"] for property [{property.Name}] on instance [{instance}] of type [{schemaProperty.ActualType}]. {fileInfo}");
                    }
                }
            }

        }
    }

    private static string ToShortString(Dictionary<string, (object? Value, YamlLineInfo LineInfo)> instance)
    {
        var instanceValues = instance.Where(kv => kv.Value.Value is not null)
            .Where(kv => kv.Value.Value is string)
            .Select(kv => $"{kv.Key}: {kv.Value.Value}")
            .ToArray();

        var asString = string.Join(",", instanceValues);

        return asString.Length < 51 ? asString : asString.Substring(0, 50) + "...";
    }

    private static string ToFileInfoString(YamlLineInfo? lineInfo)
    {
        return lineInfo == null ? string.Empty : $"(at line {lineInfo.Line} in {lineInfo.FileName})";
    }
}
