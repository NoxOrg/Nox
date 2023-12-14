using System.Reflection;
using Nox.Yaml.Extensions;
using Nox.Yaml.Serialization;

namespace Nox.Yaml.Schema.Generator;

internal class SchemaGenerator
{

    private static readonly string[] _anyTypeList = new[] { "string", "number", "boolean", "array", "object" };

    private readonly HashSet<Type> _generatedSchemas = new();

    private readonly Dictionary<Type, SchemaProperty> _schemaPropertyCache = new();

    internal void Generate(Type type, string schemaPath)
    {
        schemaPath = Path.GetFullPath(schemaPath);

        Directory.CreateDirectory(schemaPath);

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

        var js = new JsonSerializer();

        js.StartBlock();

        if(schemaProperty.GenerateSchema) 
            js.AppendProperty("$schema", "http://json-schema.org/draft-07/schema#");

        if (schemaProperty.Title is not null)
            js.AppendProperty("title", schemaProperty.Title);

        if (schemaProperty.Description is not null)
            js.AppendProperty("description", schemaProperty.Description);

        if (schemaProperty.Type is not null)
        {
            if (schemaProperty.IsNullable || !schemaProperty.IsRequired || schemaProperty.IsVariableAllowed)
            {
                js.AppendLine("\"oneOf\": [");
                js.Indent();
                js.AppendLine("{");
                js.Indent();

                WriteTypeInfo(schemaProperty, js);

                js.RemoveTrailingCommas();
                js.UnIndent();
                js.AppendLine("},");

                if (schemaProperty.IsVariableAllowed)
                {
                    js.AppendLine("{");
                    js.Indent();
                    js.AppendProperty("type", "string");
                    js.AppendProperty("pattern", Constants.YamlVariableRegex);
                    js.RemoveTrailingCommas();
                    js.UnIndent();
                    js.AppendLine("},");
                }

                if (schemaProperty.IsNullable || !schemaProperty.IsRequired)
                {
                    js.AppendLine("{");
                    js.Indent();
                    js.AppendProperty("type", "null");
                    js.RemoveTrailingCommas();
                    js.UnIndent();
                    js.AppendLine("}");
                }

                js.RemoveTrailingCommas();
                js.UnIndent();
                js.AppendLine("],");
            }
            else
            {
                WriteTypeInfo(schemaProperty, js);
            }
        }

        if (schemaProperty.TypeConst is not null)
            js.Append($"  \"const\": \"{schemaProperty.TypeConst}\"\n");

        if (schemaProperty.Required is not null && schemaProperty.AnyOf is null)
            js.AppendProperty("required", schemaProperty.Required);

        if (schemaProperty.Properties is not null)
        {
            js.AppendLine("\"properties\": {");
            js.Indent();

            foreach (var property in schemaProperty.Properties)
            {
                if (property.Value.Ignore) continue;

                js.AppendIndented($"\"{property.Key}\": ");
                js.AppendLines(WriteSchema(property.Value, schemaPath).TrimEnd()+",", true);
            }

            js.RemoveTrailingCommas();
            js.UnIndent();
            js.AppendLine("},");

        }

        if (schemaProperty.Items is not null && !schemaProperty.Items.Ignore)
        {
            schemaProperty.Items.SetPatternIfNull(schemaProperty.Pattern);
            js.AppendIndented("\"items\": ");
            js.AppendLines(WriteSchema(schemaProperty.Items, schemaPath).TrimEnd()+",", false);
        }

        if (schemaProperty.AnyOf is not null)
        {
            js.AppendLine("\"anyOf\": [");
            js.Indent();

            foreach (var property in schemaProperty.AnyOf)
            {
                if (property.Ignore) continue;

                js.AppendLines(WriteSchema(property, schemaPath).TrimEnd()+",", false);
            }

            js.RemoveTrailingCommas();
            js.UnIndent();
            js.AppendLine("],");
        }

        if (schemaProperty.AdditionalPropertiesObject is not null)
            js.AppendProperty("additionalProperties", schemaProperty.AdditionalPropertiesObject);

        else if (schemaProperty.AdditionalProperties == false) 
            js.AppendProperty("additionalProperties", (bool)schemaProperty.AdditionalProperties);

        js.EndBlock();


        if (schemaProperty.GenerateSchema)
        {
            var file = $"{schemaProperty.SchemaName}.json";
            File.WriteAllText(Path.Combine(schemaPath,file), js.ToString());
            return AnyOfWithSchemaAndReferenceSupport(file);
        }
        else
        {
            return js.Build();
        }

    }

    private static void WriteTypeInfo(SchemaProperty schemaProperty, JsonSerializer js)
    {

        if (schemaProperty.Type is null) return;

        if(schemaProperty.Type.Equals("any"))
        {
            js.AppendProperty("type", _anyTypeList);
        }
        else
        {
            js.AppendProperty("type", schemaProperty.Type);
        }

        if (schemaProperty.Format is not null)
            js.AppendProperty("format", schemaProperty.Format);

        if (schemaProperty.Pattern is not null && (schemaProperty.Items is null || schemaProperty.Items.Ignore))
            js.AppendProperty("pattern", schemaProperty.Pattern);

        if (schemaProperty.Enum is not null)
            js.AppendProperty("enum", schemaProperty.Enum);

        if (schemaProperty.Minimum.HasValue)
            js.AppendProperty("minimum", schemaProperty.Minimum.Value);

        if (schemaProperty.Maximum.HasValue)
            js.AppendProperty("maximum", schemaProperty.Maximum.Value);

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
                "required": ["$ref"],
                "type": "object",
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
