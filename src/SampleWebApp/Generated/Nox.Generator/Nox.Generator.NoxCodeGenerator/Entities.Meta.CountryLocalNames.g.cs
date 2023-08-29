// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Static methods for the CountryLocalNames class.
/// </summary>
public partial class CountryLocalNames
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.TextTypeOptions IdTypeOptions {get; private set;} = new ()
    {
        MinLength = 2,
        MaxLength = 2,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateId(System.String value)
        => Nox.Types.Text.From(value, IdTypeOptions);
    

}