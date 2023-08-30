// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Static methods for the CurrencyUnits class.
/// </summary>
public partial class CurrencyUnits
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'MajorName'
    /// </summary>
    public static Nox.Types.TextTypeOptions MajorNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateMajorName(System.String value)
        => Nox.Types.Text.From(value, MajorNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'MajorSymbol'
    /// </summary>
    public static Nox.Types.TextTypeOptions MajorSymbolTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateMajorSymbol(System.String value)
        => Nox.Types.Text.From(value, MajorSymbolTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'MinorName'
    /// </summary>
    public static Nox.Types.TextTypeOptions MinorNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateMinorName(System.String value)
        => Nox.Types.Text.From(value, MinorNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'MinorSymbol'
    /// </summary>
    public static Nox.Types.TextTypeOptions MinorSymbolTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateMinorSymbol(System.String value)
        => Nox.Types.Text.From(value, MinorSymbolTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'MinorToMajorValue'
    /// </summary>
    public static Nox.Types.Money CreateMinorToMajorValue(IMoney value)
        => Nox.Types.Money.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyId'
    /// </summary>
    public static Nox.Types.CurrencyCode3 CreateCurrencyId(System.String value)
        => Nox.Types.CurrencyCode3.From(value);
    

}