using System;

namespace Nox.Types.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class AllowVariableAttribute: Attribute
{
    public AllowVariableAttribute()
    {
        
    }
}