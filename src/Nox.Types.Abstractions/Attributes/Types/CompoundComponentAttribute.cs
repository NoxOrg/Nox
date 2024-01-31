using System;

namespace Nox.Types;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class CompoundComponentAttribute : Attribute
{
    public string Name { get; }
    public Type UnderlyingType { get; }
    public bool IsRequired { get; set; }

    public CompoundComponentAttribute(string name, Type type, bool isRequired = true)
    {
        Name = name;
        UnderlyingType = type;
        IsRequired = isRequired;
    }
}