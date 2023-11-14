namespace Nox.Yaml.Attributes;


[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class GenerateJsonSchema : Attribute
{
    public string? SchemaName { get; private set; }

    public GenerateJsonSchema(string? schemaName = null)
    {
        SchemaName = schemaName;
    }
}
