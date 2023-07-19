using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Solution.Schema;

internal class SchemaValidator
{

    private readonly List<string> _errors = new();
    internal IReadOnlyList<string> Errors => _errors;

    internal void Validate(IDictionary<string, object> objectInstance, SchemaProperty schemaProperty)
    {
        if (objectInstance is null || schemaProperty is null)
        {
            return;
        }

        var requiredProperties = schemaProperty.Required ?? Enumerable.Empty<string>();

        // Check all required properties exist
        foreach (var required in requiredProperties)
        {
            if (objectInstance.TryGetValue(required, out var val) && val is not null)
                continue;

            var instance = ToShortString(objectInstance);

            _errors.Add($"Missing property [\"{required}\"] on instance [{instance}] of type [{schemaProperty.ActualType}] is required.");
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

                _errors.Add($"Disallowed property [\"{prop.Key}\"] on instance [{instance}] of type [{schemaProperty.ActualType}].");
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
                var obj2 = ((IDictionary<object, object>)obj).ToDictionary(o => o.Key.ToString()!, o => o.Value);

                Validate(obj2, property);
            }
            else if (property.Type == "array"
                && property.UnderlyingType.IsGenericType
                && property.Items is not null
                && property.Items.Type == "object")
            {
                foreach (var item in (IList)obj)
                {
                    var obj2 = ((IDictionary<object, object>)item).ToDictionary(o => o.Key.ToString()!, o => o.Value);

                    Validate(obj2, property.Items);
                }
            }

            // Check for valid enumerators
            else if (property.Enum is not null && property.Name is not null)
            {
                if (objectInstance.TryGetValue(property.Name, out var val) && val is string strVal)
                {
                    if (!property.Enum.Contains(strVal))
                    {
                        var instance = ToShortString(objectInstance);

                        _errors.Add($"Invalid value [\"{strVal}\"] for property [{property.Name}] on instance [{instance}] of type [{schemaProperty.ActualType}].");
                    }
                }
            }

        }
    }

    private static string ToShortString(IDictionary<string, object> instance)
    {
        var instanceValues = instance.Where(kv => kv.Value is not null)
            .Where(kv => kv.Value is string)
            .Select(kv => $"{kv.Key}: {kv.Value}")
            .ToArray();

        var asString = string.Join(",", instanceValues);

        return asString.Length < 51 ? asString : asString.Substring(0, 50) + "...";
    }
}
