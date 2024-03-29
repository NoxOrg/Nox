﻿using Nox.Yaml.Exceptions;
using Nox.Yaml.Parser;
using Nox.Yaml.Schema.Generator;
using Nox.Yaml.Schema.Validator;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
    /// <param name="fileName">File name of the yaml content.</param>
    /// <param name="yamlTypeConverters">Optional list of yaml type converters.</param>
    /// <returns>Deserialized instance of type T.</returns>
    /// <exception cref="NoxYamlException">Errors containing all validation deserialization errors.</exception>
    public static T Deserialize<T>(string yaml, string? fileName = null, IEnumerable<IYamlTypeConverter>? yamlTypeConverters = null)
    {
        fileName ??= "YAML";

        var yamlContentProvider = new Dictionary<string, Func<TextReader>>
        {
            { fileName, () => new StringReader(yaml) }
        };

        var yamlRefResolver = new YamlReferenceResolver(yamlContentProvider, fileName, yamlTypeConverters);

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
        var builder = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithNodeTypeResolver(new ReadOnlyCollectionNodeTypeResolver());

        foreach (var typeConverter in yamlRefResolver.YamlTypeConverters)
        {
            builder = builder.WithTypeConverter(typeConverter);
        }
       
        
        var deserializer = builder.Build();

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
                throw new NoxYamlValidationException(validator.Errors);
            }

            yamlTypedObjectInstance = deserializer.Deserialize<T>(yaml);

        }
        catch (YamlException ex)
        {
            var errors = GetExceptionMessages(ex);
            var message = string.Join("\n", errors.Distinct());
            throw new NoxYamlException(message, ex, errors);
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