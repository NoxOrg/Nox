using System;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Types;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class CompoundTypeAttribute : Attribute, IDtoGenerateControl
{
    public virtual bool Read { get; set; }
    public virtual bool Update { get; set; }

    public CompoundTypeAttribute(bool read = true, bool update = true)
    {
        Read = read;
        Update = update;
    }
}
