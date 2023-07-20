using System;

namespace Nox.Types.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class IgnoreAttribute : Attribute
{
    public IgnoreAttribute()
    {
    }
}
