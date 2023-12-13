using Nox.Yaml.Tests.TestDesigns.Nox.Types.ComponentsDiscover;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Types;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class SimpleTypeAttribute : Attribute, IDtoGenerateControl
{
    public INoxTypeComponentsDiscover ComponentDiscover { get; }

    public virtual bool Read { get; set; }
    public virtual bool Update { get; set; }

    public SimpleTypeAttribute(Type underlyingType, bool read = true, bool update = true)
    {
        if (typeof(INoxTypeComponentsDiscover).IsAssignableFrom(underlyingType))
        {
            var instance = Activator.CreateInstance(underlyingType);
            if (instance is not null)
            {
                ComponentDiscover = (INoxTypeComponentsDiscover)instance;
            }
        }
        ComponentDiscover ??= new NoxTypeComponentsDiscover(underlyingType);

        Read = read;
        Update = update;
    }
}