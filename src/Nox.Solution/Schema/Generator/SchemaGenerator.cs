using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using Nox.Solution.Extensions;
using Nox.Solution.Schema.Serialization;

namespace Nox.Solution.Schema;

internal class SchemaGenerator
{ 

    private readonly HashSet<Type> _generatedSchemas = new();

    private readonly Dictionary<Type, SchemaProperty> _schemaPropertyCache = new();

    internal void Generate(Type type, string schemaPath)
    {
        var schemaRoot = GetSchemaInfo(type);

        WriteSchema(schemaRoot, schemaPath);

    }

    /// <summary>
    /// Reads a type, its collections, dictionaries and properties and inspects its schema attributes. 
    /// </summary>
    /// <param name="inputType">The type to generate a root <see cref="SchemaProperty"/> for.</param>
    /// <returns>Returns a recursively built <see cref="SchemaProperty"/> object tree that matches JSON schema structure.</returns>
    internal SchemaProperty GetSchemaInfo(Type inputType)
    {
        var type = Nullable.GetUnderlyingType(inputType) ?? inputType;

        if (_schemaPropertyCache.TryGetValue(type, out var schemaInfo))
        {
            return schemaInfo;
        }
        
        schemaInfo = new SchemaProperty(type);
        _schemaPropertyCache.Add(type, schemaInfo);

        if (schemaInfo.SuppressProperties)
        {
            return schemaInfo;
        }
        
        if (type.IsSimpleType())
        {
            return schemaInfo;
        }

        var properties = type.GetProperties(BindingFlags.FlattenHierarchy
                | BindingFlags.Public
                | BindingFlags.Instance);

        foreach (var property in properties)
        {
            var sp = new SchemaProperty(property, property.PropertyType);

            if (sp.Ignore)
            {
                continue;
            }

            if (sp.Type == "object")
            {
                // Recurse
                var childProperty = GetSchemaInfo(property.PropertyType);
                sp.OverridePropertiesWith(childProperty);
            }
            else if (sp.Type == "array" && property.PropertyType.GenericTypeArguments.Length == 0)
            {
                var itemInfo = GetSchemaInfo(property.PropertyType.GetElementType()!);
                sp.SetItems(itemInfo);
            }
            else if (sp.Type == "array")
            {
                var itemInfo = GetSchemaInfo(property.PropertyType.GenericTypeArguments[0]);
                sp.SetItems(itemInfo);
            }

            schemaInfo.AddProperty(sp);
        }

        schemaInfo.CreateAnyOfFromConditionals();

        return schemaInfo;
    }

    /// <summary>
    /// Writes a schema and its subschema's to files. This is a recursive operation.
    /// </summary>
    /// <param name="schemaProperty">The property to generate a Json schema for.</param>
    /// <param name="schemaPath">The path to write JSON schema files to.</param>
    /// <returns>A schema snippet that is added to the parent schema.</returns>
    private string WriteSchema(SchemaProperty schemaProperty, string schemaPath)
    {

        if (schemaProperty.GenerateSchema)
        {
            if (_generatedSchemas.Contains(schemaProperty.UnderlyingType))
            {
                var file = $"{schemaProperty.SchemaName}.json";
                return AnyOfWithSchemaAndReferenceSupport(file);
            }
            _generatedSchemas.Add(schemaProperty.UnderlyingType);
        }

        var jb = new JsonBuilder();

        jb.StartBlock();

        if(schemaProperty.GenerateSchema) 
            jb.AppendProperty("$schema", "http://json-schema.org/draft-07/schema#");

        if (schemaProperty.Title is not null)
            jb.AppendProperty("title", schemaProperty.Title);

        if (schemaProperty.Description is not null)
            jb.AppendProperty("description", schemaProperty.Description);

        if (schemaProperty.Type is not null)
        {
            if (schemaProperty.IsNullable || !schemaProperty.IsRequired || schemaProperty.IsVariableAllowed)
            {
                jb.AppendLine("\"oneOf\": [");
                jb.Indent();
                jb.AppendLine("{");
                jb.Indent();
                AppendType(jb, schemaProperty.Type);
                if (schemaProperty.Format is not null)
                    jb.AppendProperty("format", schemaProperty.Format);
        
                if (schemaProperty.Pattern is not null && (schemaProperty.Items is null || schemaProperty.Items.Ignore) )
                    jb.AppendProperty("pattern", schemaProperty.Pattern);

                if (schemaProperty.Enum is not null)
                    jb.AppendProperty("enum", schemaProperty.Enum);
                jb.RemoveTrailingCommas();
                jb.UnIndent();
                jb.AppendLine("},");

                if (schemaProperty.IsVariableAllowed)
                {
                    jb.AppendLine("{");
                    jb.Indent();
                    jb.AppendProperty("type", "string");
                    jb.AppendProperty("pattern", "^(\\$\\{\\{\\s*(.*)\\s*\\}\\})");
                    jb.RemoveTrailingCommas();
                    jb.UnIndent();
                    jb.AppendLine("},");
                }

                if (schemaProperty.IsNullable || !schemaProperty.IsRequired)
                {
                    jb.AppendLine("{");
                    jb.Indent();
                    jb.AppendProperty("type", "null");
                    jb.RemoveTrailingCommas();
                    jb.UnIndent();
                    jb.AppendLine("}");
                }
                
                jb.RemoveTrailingCommas();
                jb.UnIndent();
                jb.AppendLine("],");
            }
            else
            {
                AppendType(jb, schemaProperty.Type);

                if (schemaProperty.Format is not null)
                    jb.AppendProperty("format", schemaProperty.Format);
        
                if (schemaProperty.Pattern is not null && (schemaProperty.Items is null || schemaProperty.Items.Ignore) )
                    jb.AppendProperty("pattern", schemaProperty.Pattern);

                if (schemaProperty.Enum is not null)
                    jb.AppendProperty("enum", schemaProperty.Enum);
            }
        }

        if (schemaProperty.TypeConst is not null)
            jb.Append($"  \"const\": \"{schemaProperty.TypeConst}\"\n");

        if (schemaProperty.Required is not null)
            jb.AppendProperty("required", schemaProperty.Required);

        if (schemaProperty.Properties is not null)
        {
            jb.AppendLine("\"properties\": {");
            jb.Indent();

            foreach (var property in schemaProperty.Properties)
            {
                if (property.Value.Ignore) continue;

                jb.AppendIndented($"\"{property.Key}\": ");
                jb.AppendLines(WriteSchema(property.Value, schemaPath).TrimEnd()+",", true);
            }

            jb.RemoveTrailingCommas();
            jb.UnIndent();
            jb.AppendLine("},");

        }

        if (schemaProperty.Items is not null && !schemaProperty.Items.Ignore)
        {
            schemaProperty.Items.SetPatternIfNull(schemaProperty.Pattern);
            jb.AppendIndented("\"items\": ");
            jb.AppendLines(WriteSchema(schemaProperty.Items, schemaPath).TrimEnd()+",", false);
        }

        if (schemaProperty.AnyOf is not null)
        {
            jb.AppendLine("\"anyOf\": [");
            jb.Indent();

            foreach (var property in schemaProperty.AnyOf)
            {
                if (property.Ignore) continue;

                jb.AppendLines(WriteSchema(property, schemaPath).TrimEnd()+",", false);
            }

            jb.RemoveTrailingCommas();
            jb.UnIndent();
            jb.AppendLine("],");
        }

        if (schemaProperty.AdditionalPropertiesObject is not null)
            jb.AppendProperty("additionalProperties", schemaProperty.AdditionalPropertiesObject);

        else if (schemaProperty.AdditionalProperties == false) 
            jb.AppendProperty("additionalProperties", (bool)schemaProperty.AdditionalProperties);

        jb.EndBlock();


        if (schemaProperty.GenerateSchema)
        {
            var file = $"{schemaProperty.SchemaName}.json";
            File.WriteAllText(Path.Combine(schemaPath,file), jb.ToString());
            return AnyOfWithSchemaAndReferenceSupport(file);
        }
        else
        {
            return jb.Build();
        }

    }

    private static void AppendType(JsonBuilder jb, string type)
    {
        if (type.Contains(","))
        {
            jb.AppendProperty("type", type.Split(','));
        }
        else
        {
            jb.AppendProperty("type", type);
        }
    }

    /// <summary>
    /// Generates an "anyOf" JSON schema structure for sub-schemas to support "$ref" keys in Nox YAML files.
    /// </summary>
    /// <param name="schemaFile">The file containing the JSON schema to include in the "anyOf" structure.</param>
    /// <returns></returns>
    private static string AnyOfWithSchemaAndReferenceSupport(string schemaFile)
    {
        return $$"""
          {
            "anyOf": [
              { "$ref": "{{schemaFile}}" },
              {
                "additionalProperties": false, 
                "properties": {
                  "$ref": {
                    "type": "string",
                    "format": "uri",
                    "pattern": "^[^\\s]*$"
                  }
                }
              }
            ]
          }
          """;
    }
}
