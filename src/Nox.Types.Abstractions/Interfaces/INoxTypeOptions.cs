using Nox.Types.Extensions;
using System;
using System.Collections.Generic;

namespace Nox.Types;

public interface INoxTypeOptions { }

/// <summary>
/// Defines that the type options defines the underline type (dynamic not fix)
/// </summary>
public interface IHaveUnderLineTypeOptions : INoxTypeOptions
{
    public Type GetUnderlineType();
}