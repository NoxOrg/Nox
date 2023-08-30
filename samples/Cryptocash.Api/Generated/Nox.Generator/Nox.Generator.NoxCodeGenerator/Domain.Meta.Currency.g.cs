// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Static methods for the Currency class.
/// </summary>
public partial class Currency
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.CurrencyCode3 CreateId(System.String value)
        => Nox.Types.CurrencyCode3.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Name'
    /// </summary>
    public static Nox.Types.TextTypeOptions NameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateName(System.String value)
        => Nox.Types.Text.From(value, NameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyIsoNumeric'
    /// </summary>
    public static Nox.Types.CurrencyNumber CreateCurrencyIsoNumeric(System.Int16 value)
        => Nox.Types.CurrencyNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Symbol'
    /// </summary>
    public static Nox.Types.TextTypeOptions SymbolTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateSymbol(System.String value)
        => Nox.Types.Text.From(value, SymbolTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'ThousandsSeperator'
    /// </summary>
    public static Nox.Types.TextTypeOptions ThousandsSeperatorTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateThousandsSeperator(System.String value)
        => Nox.Types.Text.From(value, ThousandsSeperatorTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'DecimalSeparator'
    /// </summary>
    public static Nox.Types.TextTypeOptions DecimalSeparatorTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateDecimalSeparator(System.String value)
        => Nox.Types.Text.From(value, DecimalSeparatorTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'SpaceBetweenAmountAndSymbol'
    /// </summary>
    public static Nox.Types.Boolean CreateSpaceBetweenAmountAndSymbol(System.Boolean value)
        => Nox.Types.Boolean.From(value);
    

    /// <summary>
    /// Type options and factory for property 'DecimalDigits'
    /// </summary>
    public static Nox.Types.Number CreateDecimalDigits(System.Int32 value)
        => Nox.Types.Number.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyUnitsId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateCurrencyUnitsId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyBankNotesId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateCurrencyBankNotesId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryId'
    /// </summary>
    public static Nox.Types.CountryCode2 CreateCountryId(System.String value)
        => Nox.Types.CountryCode2.From(value);
    

    /// <summary>
    /// Type options and factory for property 'MinimumCashStockId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateMinimumCashStockId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'ExchangeRateId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateExchangeRateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

}