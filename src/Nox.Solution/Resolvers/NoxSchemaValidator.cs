using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using System.Text.Json;
using Nox.Solution.Exceptions;
using YamlDotNet.Core;
using System.Linq;
using System;

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

        using var sr = new StringReader(yaml);
        var yamlContent = sr.ReadToEnd();

        var errors = new List<string>();

        T yamlTypedObjectInstance;
        try
        {
            // Then when all required fields are validate it's neccessary to check whether all properties match T object properties.
            // In case some field is missed it will throw an exception regarding to deserializtion error.
            yamlTypedObjectInstance = deserializer.Deserialize<T>(yamlContent);
        }
        catch (YamlException ex)
        {
            HandleYamlExceptionMessage(ex, errors);
            var message = string.Join("\n", errors.Distinct());

            throw new NoxSolutionConfigurationException(message, ex);
        }

        if (errors.Count > 0)
        {
            var message = string.Join("\n", errors.Distinct());
            throw new NoxSolutionConfigurationException(message);
        }

        return yamlTypedObjectInstance;
    }

    private static void HandleYamlExceptionMessage(Exception? exception, List<string> errors)
    {
        if (exception is null)
        {
            return;
        }

        string message;
        if (exception is YamlException yamlException)
        {
            message = $"{yamlException.Message}. Line {yamlException.End.Line}, column {yamlException.End.Column}.";
        }
        else
        {
            message = exception.Message;
        }

        errors.Add(message);
        HandleYamlExceptionMessage(exception.InnerException, errors);
    }
}