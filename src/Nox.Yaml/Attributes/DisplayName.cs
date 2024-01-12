namespace Nox.Yaml.Attributes;

using System;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class DisplayNameAttribute : Attribute
{
    public string DisplayName { get; }

    public DisplayNameAttribute(string displayName)
    {
        DisplayName = displayName;
    }
}