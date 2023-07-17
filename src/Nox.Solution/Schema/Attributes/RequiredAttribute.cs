using System;

namespace Nox.Solution.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class RequiredAttribute : Attribute
{
    public RequiredAttribute()
    {
    }
}
