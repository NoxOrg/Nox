using System;

namespace Nox.Types;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class SimpleTypeAttribute : Attribute
{
    public INoxTypeComponentsDiscover ComponentDiscover { get; }

    public SimpleTypeAttribute(Type underlyingType)
    {
        if (typeof(INoxTypeComponentsDiscover).IsAssignableFrom(underlyingType))
        {
            ComponentDiscover = (INoxTypeComponentsDiscover)Activator.CreateInstance(underlyingType);
        }
        else
        {
            ComponentDiscover = new NoxTypeComponentsDiscover(underlyingType);
        }
    }
}