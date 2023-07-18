using System;

namespace Nox.Types;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class CompoundComponentAttribute : Attribute
{
    public string Name { get; }
    public Type UnderlyingType { get; }
    public CompoundComponentAttribute(string name, Type type)
    {
        Name = name;
        UnderlyingType = type;
    }

}