using System;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Schema;

[AttributeUsage(AttributeTargets.Class)]
public class GenerateJsonSchema : Attribute
{
    public string? SchemaName { get; private set; }

    public GenerateJsonSchema(string? schemaName = null)
    {
        SchemaName = schemaName;
    }
}
