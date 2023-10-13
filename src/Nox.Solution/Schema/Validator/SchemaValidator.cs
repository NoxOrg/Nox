using Nox.Solution.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

            var fileInfo = ToFileInfoString(lineInfo);

            _errors.Add($"Missing property [\"{required}\"] is required. {fileInfo}");
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

                var fileInfo = ToFileInfoString(prop.Value.LineInfo);

                _errors.Add($"Disallowed property [\"{prop.Key}\"]. {fileInfo}");
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

            // Check values to allowed schema types

            // compiler check - can't be null for required fields at this point and all other fields will allow null
            if (obj.Value is null || property.Type is null)
            {
                continue;
            }

            var objType = obj.Value.GetType();
            var fileInfo = ToFileInfoString(obj.LineInfo);

            if (objType.IsIntegerType())
            {
                if (!property.Type.Contains("integer") && !property.Type.Contains("number"))
                    _errors.Add($"Invalid integer value [\"{obj.Value}\"] for property [{property.Name}] is not of type [{property.Type}]. {fileInfo}");
            }

            else if (objType.IsNumericType()) 
            {
                if (!property.Type.Contains("number"))
                    _errors.Add($"Invalid number value [\"{obj.Value}\"] for property [{property.Name}] is not of type [{property.Type}]. {fileInfo}");
            }

            else if (obj.Value is string)
            {
                if (!property.Type.Contains("string"))
                    _errors.Add($"Invalid string value [\"{obj.Value}\"] for property [{property.Name}] is not of type [{property.Type}]. {fileInfo}");
            }

            else if (obj.Value is bool)
            {
                if (!property.Type.Contains("boolean"))
                    _errors.Add($"Invalid bool value [\"{obj.Value}\"] for property [{property.Name}] is not of type [{property.Type}]. {fileInfo}");
            }

            else if (objType.IsArray)
            {
                if (!property.Type.Contains("array"))
                    _errors.Add($"Invalid array value [\"{obj.Value}\"] for property [{property.Name}] is not of type [{property.Type}]. {fileInfo}");
            }

            else if (objType.IsDictionary())
            {
                if (!property.Type.Contains("object"))
                    _errors.Add($"Invalid object value [\"{obj.Value}\"] for property [{property.Name}] is not of type [{property.Type}]. {fileInfo}");
            }


            // end type checks

            if (property.Type == "object")
            {
                var obj2 = (Dictionary<string, (object? Value, YamlLineInfo LineInfo)>)obj.Value;
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
                if (obj.Value is string strVal)
                {
                    if (!property.Enum.Contains(strVal))
                    {
                        _errors.Add($"Invalid value [\"{strVal}\"] for property [{property.Name}]. {fileInfo}");
                    }
                }
            }

        }
    }

    private static string ToFileInfoString(YamlLineInfo? lineInfo)
    {
        return lineInfo == null ? string.Empty : $"(at line {lineInfo.Line} in {lineInfo.FileName})";
    }
}
