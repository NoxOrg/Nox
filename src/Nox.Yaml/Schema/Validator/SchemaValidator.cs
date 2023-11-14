using Nox.Yaml.Parser;
using Nox.Yaml.Extensions;
using Nox.Yaml.Schema.Generator;
using System.Collections;
using System.IO;

namespace Nox.Yaml.Schema.Validator;

internal class SchemaValidator
{

    private readonly List<string> _errors = new();

    private readonly Dictionary<string, (object? Value, YamlLineInfo LineInfo)> _topObject;

    private readonly Stack<(string Parent, string Property, HashSet<string> Values)> _globallyUniqueKeys = new();

    internal IReadOnlyList<string> Errors => _errors;

    public SchemaValidator(Dictionary<string, (object? Value, YamlLineInfo LineInfo)> topObject)
    {
        _topObject = topObject;
    }

    internal void ValidateSchema(Dictionary<string, (object? Value, YamlLineInfo LineInfo)> objectInstance, SchemaProperty schemaProperty)
    {
        Validate(objectInstance, schemaProperty);
    }

    private void Validate(Dictionary<string, (object? Value, YamlLineInfo LineInfo)> objectInstance, SchemaProperty schemaProperty)
    {
        if (objectInstance is null || schemaProperty is null)
        {
            return;
        }

        // Extract global unique property keys for later validation
        if (schemaProperty.UniqueChildProperty is not null && schemaProperty.Name is not null)
        {
            _globallyUniqueKeys.Push(new (schemaProperty.Name, schemaProperty.UniqueChildProperty.PropertyKey, new HashSet<string>()));
        }
        var globalUniqueProperties = _globallyUniqueKeys.Select(e => e.Property).ToArray();

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

            List<Dictionary<string, (object? Value, YamlLineInfo LineInfo)>> arrayItems = new();

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
                    arrayItems.Add(obj2);
                }
            }

            // Check for valid enumerators
            else if (property.Enum is not null && property.Name is not null)
            {
                if (obj.Value is string strEnum)
                {
                    if (!property.Enum.Contains(strEnum))
                    {
                        _errors.Add($"Invalid value [\"{strEnum}\"] for property [{property.Name}]. {fileInfo}");
                    }
                }
            }

            // Check MustExistIn (does value exist in another list by key)
            if (property.ExistsInCollection is not null && obj.Value is string strExistsIn)
            {
                if (!property.ExistsInCollection.IsValid(strExistsIn, _topObject))
                {
                    _errors.Add($"No entry exists for property [{property.Name}] with value [\"{strExistsIn}\"] in [{property.ExistsInCollection.Path}]. {fileInfo}");
                }
            }

            // Check MustBeUniqueOn (are values unique in a list)
            if (property.UniqueItemProperties is not null)
            {
                if (!property.UniqueItemProperties.IsValid(arrayItems))
                {
                    _errors.Add($"The collection [{property.Name}] contains duplicate for values [{property.UniqueItemProperties.Duplicates}] based on property [{property.UniqueItemProperties.Keys}]. {fileInfo}");
                }
            }

            // Check Global Uniquenes if property matches
            if (property.Name is not null &&  globalUniqueProperties.Contains(property.Name))
            {
                foreach(var (Parent, _, Values) in _globallyUniqueKeys.Where(e => e.Property.Equals(property.Name))) 
                {
                    var strValue = obj.Value.ToString();
                    if (Values.Contains(strValue))
                    {
                        _errors.Add($"The key [{property.Name}] contains a global duplicate [\"{strValue}\"] in the [{Parent}] heirachy. {fileInfo}");
                    }
                    else
                    {
                        Values.Add(strValue);
                    }
                }
            }

        }

        // Extract global unique property keys for later validation
        if (schemaProperty.UniqueChildProperty is not null)
        {
            _globallyUniqueKeys.Pop();
        }

    }

    private static string ToFileInfoString(YamlLineInfo? lineInfo)
    {
        return lineInfo == null ? string.Empty : $"(at line {lineInfo.Line} in {lineInfo.FileName})";
    }
}
