using Nox.Yaml.Extensions;

namespace Nox.Yaml.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class UniqueChildPropertyAttribute : Attribute
{

    public string PropertyKey { get; private set; }

    public UniqueChildPropertyAttribute(string propertyKey)
    {
        PropertyKey = propertyKey.ToCamelCase();
    }
}