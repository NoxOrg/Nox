﻿using System;

namespace Nox.Types.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
   AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface,
   AllowMultiple = true)]
public class PatternAttribute : Attribute
{
    public string Value { get; private set; }
    public PatternAttribute(string value)
    {
        Value = value;
    }
}

