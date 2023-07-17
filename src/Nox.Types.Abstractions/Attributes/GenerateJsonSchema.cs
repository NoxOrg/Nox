using System;

namespace Nox.Types.Schema;

[AttributeUsage(AttributeTargets.Class)]
public class GenerateJsonSchema : Attribute
{
    public string? SchemaName { get; private set; }

    public GenerateJsonSchema(string? schemaName = null)
    {
        SchemaName = schemaName;
    }
}
