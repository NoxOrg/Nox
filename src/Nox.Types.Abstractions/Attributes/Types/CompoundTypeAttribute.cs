﻿using System;

namespace Nox.Types;

/// <summary>
/// 
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class CompoundTypeAttribute : Attribute, IDtoGenerateControl
{
    public virtual bool Read { get; set; }
    public virtual bool Update { get; set; }
    public virtual bool Create { get; set; }

    public CompoundTypeAttribute(bool read = true, bool update = true, bool create = true) 
    {
        Read = read;
        Update = update;
        Create = create;
    }
}
