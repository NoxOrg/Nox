namespace Nox.Yaml.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class AllowVariableAttribute : Attribute
{
    public AllowVariableAttribute()
    {
    }
}
