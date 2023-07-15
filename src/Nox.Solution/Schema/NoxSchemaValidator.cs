using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Text.Json;
using Nox.Solution.Exceptions;
using YamlDotNet.Core;
using System.Linq;
using System;
using Nox.Solution.Extensions;
using System.Collections;
using YamlDotNet.Core.Tokens;

namespace Nox.Solution.Schema;

/// <summary>
/// Deserialize yaml configuration with validation.
/// </summary>
internal static class NoxSchemaValidator
{
    /// <summary>
    /// Deserialize yaml content to T object.
    /// It deserilizes data to string then serialize to json object to validate all properties against data annotation schema.
    /// It should validate twice: first time it considers yaml content as json object to find missed required fields.
    /// If object validation carries out then consider yaml content as certain T type to find corectness of properties, whether properties
    /// match json content.
    /// </summary>
    /// <typeparam name="T">Any type corresponds to yaml content.</typeparam>
    /// <param name="yaml">Yaml file string content.</param>
    /// <returns>Deserialized T instance.</returns>
    /// <exception cref="NoxSolutionConfigurationException">Exception bring error messages caught during validation.</exception>
    public static T Deserialize<T>(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver())
            .Build();

        var errors = new List<string>();

        T yamlTypedObjectInstance;

        try
        {
            // Validate the schema first
            using var sr = new StringReader(yaml);
            var yamlObjectInstance = deserializer.Deserialize<IDictionary<string,object>>(sr);
            var rootSchemaProperty = NoxSchemaGenerator.GetSchemaInfo(typeof(T));
            ValidateInstanceAgainstSchema(yamlObjectInstance, rootSchemaProperty, errors);

            // Then if schema is valid it's neccessary to check whether we can deserialize
            if (errors.Any())
            {
                var message = string.Join("\n", errors.Distinct());
                throw new NoxSolutionConfigurationException(message);
            }

            yamlTypedObjectInstance = deserializer.Deserialize<T>(yaml);

        }
        catch (YamlException ex)
        {
            AddExceptionMessagesToErrors(ex, errors);
            var message = string.Join("\n", errors.Distinct());
            throw new NoxSolutionConfigurationException(message, ex);
        }


        return yamlTypedObjectInstance;
    }

    private static void ValidateInstanceAgainstSchema(IDictionary<string,object> objectInstance, SchemaProperty schemaProperty, List<string> errors)
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

            var instance = DictionaryToString(objectInstance);

            errors.Add($"Missing property [\"{required}\"] on instance [{instance}] of type [{schemaProperty.ActualType}] is required.");
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

                var instance = DictionaryToString(objectInstance);

                errors.Add($"Disallowed property [\"{prop.Key}\"] on instance [{instance}] of type [{schemaProperty.ActualType}].");
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
                ValidateInstanceAgainstSchema(objectInstance, property, errors);
            }

            if (!objectInstance.TryGetValue(property.Name!, out var obj))
            {
                continue;
            }

            if (property.Type == "object")
            {
                var obj2 = ((IDictionary<object,object>)obj).ToDictionary(o => o.Key.ToString()!, o => o.Value);
                
                ValidateInstanceAgainstSchema(obj2, property, errors);
            }
            else if (property.Type == "array" 
                && property.UnderlyingType.IsGenericType 
                && property.Items is not null
                && property.Items.Type == "object")
            {
                foreach (var item in (IList)obj)
                {
                    var obj2 = ((IDictionary<object, object>)item).ToDictionary(o => o.Key.ToString()!, o => o.Value);

                    ValidateInstanceAgainstSchema(obj2, property.Items, errors);
                }
            }

            // Check for valid enumerators
            else if (property.Enum is not null && property.Name is not null)
            {
                if (objectInstance.TryGetValue(property.Name, out var val) && val is string strVal)
                {
                    if (!property.Enum.Contains(strVal))
                    {
                        var instance = DictionaryToString(objectInstance);

                        errors.Add($"Invalid value [\"{strVal}\"] for property [{property.Name}] on instance [{instance}] of type [{schemaProperty.ActualType}].");
                    }
                }
            }

        }
    }

    private static string DictionaryToString(IDictionary<string, object> instance)
    {
        var instanceValues = instance.Where(kv => kv.Value is not null)
            .Where(kv => kv.Value is string)
            .Select(kv => $"{kv.Key}: {kv.Value}")
            .ToArray();

        var asString = string.Join(",", instanceValues);

        return asString.Length < 51 ? asString : asString.Substring(0, 50) + "...";
    }

    private static void AddExceptionMessagesToErrors(Exception exception, List<string> errors)
    {
        if (exception is YamlException yamlException)
        {
            errors.Add($"[YamlException] {yamlException.Message}. Line {yamlException.End.Line}, column {yamlException.End.Column}.");
        }
        else
        {
            errors.Add(exception.Message);
        }
        if (exception.InnerException is not null)
        {
            AddExceptionMessagesToErrors(exception.InnerException, errors);
        }
    }
}