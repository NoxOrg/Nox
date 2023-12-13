namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class IgnoreAttribute : Attribute
{
    public IgnoreAttribute()
    {
    }
}
