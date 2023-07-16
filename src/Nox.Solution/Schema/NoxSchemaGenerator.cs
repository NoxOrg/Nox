using System;

namespace Nox.Solution.Schema;

/// <summary>
/// Generates JSON schemas for type based on its class and property annotations.
/// </summary>
public static class NoxSchemaGenerator
{
    public static void GenerateJsonSchemas(Type type, string schemaPath)
    {
        var schemaGenerator = new SchemaGenerator();

        schemaGenerator.Generate(type, schemaPath);
    }
}
