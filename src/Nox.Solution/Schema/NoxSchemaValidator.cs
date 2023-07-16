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
    /// Deserialize a yaml string to a type and validates it against its annotated schema.
    /// </summary>
    /// <typeparam name="T">Any type corresponds to yaml content.</typeparam>
    /// <param name="yaml">Yaml file string content.</param>
    /// <returns>Deserialized instance of type T.</returns>
    /// <exception cref="NoxSolutionConfigurationException">Errors containing all validation deserialization errors.</exception>
    public static T Deserialize<T>(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver())
            .Build();

        T yamlTypedObjectInstance;

        try
        {
            // Validate the schema first
            using var sr = new StringReader(yaml);
            var yamlObjectInstance = deserializer.Deserialize<IDictionary<string,object>>(sr);

            // Read type's schema info
            var rootSchemaProperty = new SchemaGenerator().GetSchemaInfo(typeof(T));

            // Validate object instance to schema
            var validator = new SchemaValidator();
            validator.Validate(yamlObjectInstance, rootSchemaProperty);

            // Then if schema is valid it's neccessary to check whether we can deserialize
            if (validator.Errors.Any())
            {
                var message = string.Join("\n", validator.Errors.Distinct());
                throw new NoxSolutionConfigurationException(message);
            }

            yamlTypedObjectInstance = deserializer.Deserialize<T>(yaml);

        }
        catch (YamlException ex)
        {
            var errors = GetExceptionMessages(ex);
            var message = string.Join("\n", errors.Distinct());
            throw new NoxSolutionConfigurationException(message, ex);
        }

        return yamlTypedObjectInstance;
    }


    private static IReadOnlyList<string> GetExceptionMessages(Exception exception, List<string>? errors = null)
    {
        if (errors is null)
        {
            errors = new List<string>();
        }

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
            GetExceptionMessages(exception.InnerException, errors);
        }

        return errors;
    }
}