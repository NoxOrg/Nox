using System;

namespace Nox.Types;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class CompoundComponent : Attribute
{
    public string Name { get; }
    public Type UnderlyingType { get; }
    public bool IsNullable { get; set; }

    public CompoundComponent(string name, Type type, bool isNullable = false)
    {
        Name = name;
        UnderlyingType = type;
        IsNullable = isNullable;
    }
}