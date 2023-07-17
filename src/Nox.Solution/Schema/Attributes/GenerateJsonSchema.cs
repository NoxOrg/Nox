using System;

namespace Nox.Solution.Schema;

[AttributeUsage(AttributeTargets.Class)]
public class GenerateJsonSchema : Attribute
{
    public string? SchemaName { get; private set; }

    public GenerateJsonSchema(string? schemaName = null)
    {
        SchemaName = schemaName;
    }
}
