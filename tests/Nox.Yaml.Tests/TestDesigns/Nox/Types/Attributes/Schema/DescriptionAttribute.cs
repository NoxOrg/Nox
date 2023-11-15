﻿using System;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Attributes.Schema;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
   AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface,
   AllowMultiple = true)]
public class DescriptionAttribute : Attribute
{
    public string Description { get; private set; }

    public DescriptionAttribute(string description)
    {
        Description = description;
    }
}
