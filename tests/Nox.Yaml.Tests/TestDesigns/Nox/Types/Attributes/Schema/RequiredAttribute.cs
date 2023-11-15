using System;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class RequiredAttribute : Attribute
{
    public RequiredAttribute()
    {
    }
}
