namespace Nox.Yaml.Attributes;


[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class GenerateJsonSchemaAttribute : Attribute
{
    public string? SchemaName { get; private set; }

    public GenerateJsonSchemaAttribute(string? schemaName = null)
    {
        SchemaName = schemaName;
    }
}
