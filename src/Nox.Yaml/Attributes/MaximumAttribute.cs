namespace Nox.Yaml.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class MaximumAttribute : Attribute
{
    public double Value { get; private set; }

    public MaximumAttribute(double maximumValue)
    {
        Value = maximumValue;
    }

    internal bool IsValid(double value)
    {
        return value <= Value;
    }
}

