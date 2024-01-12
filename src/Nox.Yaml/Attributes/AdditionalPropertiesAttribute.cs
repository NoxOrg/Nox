namespace Nox.Yaml.Attributes;

/// <summary>
/// Constrains the properties to be the ones defined in the object, not allowing any additional properties injected dynamilcally on the schema.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
   AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface,
   AllowMultiple = false)]
public class AdditionalPropertiesAttribute : Attribute
{
    public bool BoolValue { get; private set; }
    public AdditionalPropertiesAttribute(bool boolValue)
    {
        BoolValue = boolValue;
    }
}