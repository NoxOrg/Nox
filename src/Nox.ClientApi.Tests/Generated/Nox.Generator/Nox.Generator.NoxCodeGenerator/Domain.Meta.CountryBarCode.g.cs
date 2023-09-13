﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the CountryBarCode class.
/// </summary>
public partial class CountryBarCode
{
    /// <summary>
    /// Type options and factory for property 'BarCodeName'
    /// </summary>
    public static Nox.Types.TextTypeOptions BarCodeNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 1,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateBarCodeName(System.String value)
        => Nox.Types.Text.From(value, BarCodeNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'BarCodeNumber'
    /// </summary>
    public static Nox.Types.Number CreateBarCodeNumber(System.Int32 value)
        => Nox.Types.Number.From(value);
    

}