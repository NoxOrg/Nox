using System;

namespace Nox.Types;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class CompoundComponent : Attribute
{
    public string Name { get; }
    public Type UnderlyingType { get; }
    public CompoundComponent(string name, Type type)
    {
        Name = name;
        UnderlyingType = type;
    }

}