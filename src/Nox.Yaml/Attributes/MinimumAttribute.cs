namespace Nox.Yaml.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class MinimumAttribute : Attribute
{
    public double Value { get; private set; }

    public MinimumAttribute(double minimumValue)
    {
        Value = minimumValue;
    }

    internal bool IsValid(double value)
    {
        return value >= Value;
    }
}

