namespace Nox.Yaml.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class IfEqualsAttribute : Attribute
{
    public string Property { get; private set; }

    public object Value { get; private set; }

    public IfEqualsAttribute(string propertyName, object value)
    {
        Property = propertyName;
        Value = value;
    }

}

