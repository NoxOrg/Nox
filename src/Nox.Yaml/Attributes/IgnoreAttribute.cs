namespace Nox.Yaml.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class IgnoreAttribute : Attribute
{
    public IgnoreAttribute()
    {
    }
}
