using System;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Types;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class CompoundComponent : Attribute
{
    public string Name { get; }
    public Type UnderlyingType { get; }
    public bool IsRequired { get; set; }

    public CompoundComponent(string name, Type type, bool isRequired = true)
    {
        Name = name;
        UnderlyingType = type;
        IsRequired = isRequired;
    }
}