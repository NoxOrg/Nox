namespace Nox.Yaml.Attributes;

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
