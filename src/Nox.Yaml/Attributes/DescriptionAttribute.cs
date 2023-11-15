namespace Nox.Yaml.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
   AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface,
   AllowMultiple = false)]
public class DescriptionAttribute : Attribute
{
    public string Description { get; private set; }

    public DescriptionAttribute(string description)
    {
        Description = description;
    }
}
