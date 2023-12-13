namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
   AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface,
   AllowMultiple = true)]
public class TitleAttribute : Attribute
{
    public string Title { get; private set; }

    public TitleAttribute(string title)
    {
        Title = title;
    }
}