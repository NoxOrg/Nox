using System;

namespace Nox.Types;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class SimpleTypeAttribute : Attribute, IDtoGenerateControl
{
    public INoxTypeComponentsDiscover ComponentDiscover { get; }

    public virtual bool Read { get; set; }
    public virtual bool Update { get; set; }
    public virtual bool Create { get; set; }

    public SimpleTypeAttribute(Type underlyingType, bool read = true, bool update = true, bool create = true)
    {
        if (typeof(INoxTypeComponentsDiscover).IsAssignableFrom(underlyingType))
        {
            ComponentDiscover = (INoxTypeComponentsDiscover)Activator.CreateInstance(underlyingType);
        }
        else
        {
            ComponentDiscover = new NoxTypeComponentsDiscover(underlyingType);
        }

        Read = read;
        Update = update;
        Create = create;
    }
}