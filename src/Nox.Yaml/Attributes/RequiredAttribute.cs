namespace Nox.Yaml.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class RequiredAttribute : Attribute
{
    public RequiredAttribute()
    {
    }
}
