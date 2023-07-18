using System;

namespace Nox.Types;

/// <summary>
/// 
/// </summary>

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class SimpleTypeAttribute : Attribute
{

    public Type UnderlyingType { get; }

    public SimpleTypeAttribute(Type underlyingType)
    {
        UnderlyingType = underlyingType;
    }
}