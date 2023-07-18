using System;

namespace Nox.Types;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class CompoundTypeAttribute : Attribute
{
    public CompoundTypeAttribute() 
    { 
    }
}
