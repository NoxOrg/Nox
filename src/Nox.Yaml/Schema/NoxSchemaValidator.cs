using System.Collections.Generic;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using Nox.Yaml.Exceptions;
using YamlDotNet.Core;
using System.Linq;
using System;
using System.IO;
using Nox.Yaml.Schema.Validator;
using Nox.Yaml.Schema.Generator;
using Nox.Yaml.Parser;

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
    /// <param name="yaml">Yaml string content.</param>
    /// <returns>Deserialized instance of type T.</returns>
    /// <exception cref="NoxYamlException">Errors containing all validation deserialization errors.</exception>
    public static T Deserialize<T>(string yaml, string? fileName = null)
    {
        fileName ??= "YAML";

        var yamlContentProvider = new Dictionary<string, Func<TextReader>>
        {
            { fileName, () => new StringReader(yaml) }
        };

        var yamlRefResolver = new YamlReferenceResolver(yamlContentProvider, fileName);

        return Deserialize<T>(yamlRefResolver);
    }

    /// <summary>
    /// Deserialize a yaml ref resolver to a type and validates it against its annotated schema.
    /// </summary>
    /// <typeparam name="T">Any type corresponds to yaml content.</typeparam>
    /// <param name="yamlRefResolver">A yaml reference resolver object.</param>
    /// <returns>Deserialized instance of type T.</returns>
    /// <exception cref="NoxYamlException">Errors containing all validation deserialization errors.</exception>
    public static T Deserialize<T>(YamlReferenceResolver yamlRefResolver)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver())
            .Build();

        T yamlTypedObjectInstance;

        try
        {
            var yaml = yamlRefResolver.ToYamlString();

            // Create object instance with line and file info
            var yamlObjectInstance = YamlWithLineInfoParser.Parse(yaml, yamlRefResolver);

            // Validate the schema first

            // Read type's schema info
            var rootSchemaProperty = new SchemaGenerator().GetSchemaInfo(typeof(T));

            // Validate object instance to schema
            var validator = new SchemaValidator(yamlObjectInstance);

            validator.ValidateSchema(yamlObjectInstance, rootSchemaProperty);

            // Then if schema is valid it's neccessary to check whether we can deserialize
            if (validator.Errors.Any())
            {
                var message = string.Join("\n", validator.Errors.Distinct());
                throw new NoxYamlException(message);
            }

            yamlTypedObjectInstance = deserializer.Deserialize<T>(yaml);

        }
        catch (YamlException ex)
        {
            var errors = GetExceptionMessages(ex);
            var message = string.Join("\n", errors.Distinct());
            throw new NoxYamlException(message, ex);
        }

        return yamlTypedObjectInstance;
    }


    private static IReadOnlyList<string> GetExceptionMessages(Exception exception, List<string>? errors = null)
    {
        errors ??= new List<string>();

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