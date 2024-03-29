﻿using System;

namespace Nox.Types;

public interface INoxTypeOptions { }

/// <summary>
/// Defines that the type options defines the underlying type where the typeoptions dictate the type
/// </summary>
public interface INoxTypeOptionsWithDynamicType : INoxTypeOptions
{
    public Type GetUnderlyingType();
}