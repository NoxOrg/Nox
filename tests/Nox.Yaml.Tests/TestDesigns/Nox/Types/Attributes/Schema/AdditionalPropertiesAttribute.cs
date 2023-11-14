using System;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
   AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface,
   AllowMultiple = true)]
public class AdditionalPropertiesAttribute : Attribute
{
    public bool BoolValue { get; private set; }
    public AdditionalPropertiesAttribute(bool boolValue)
    {
        BoolValue = boolValue;
    }
}
