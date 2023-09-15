// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

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
    /// Type options and factory for property 'ThousandsSeparator'
    /// </summary>
    public static Nox.Types.TextTypeOptions ThousandsSeparatorTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateThousandsSeparator(System.String value)
        => Nox.Types.Text.From(value, ThousandsSeparatorTypeOptions);
    

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
    /// Type options and factory for property 'BankNoteId'
    /// </summary>
    public static Nox.Types.AutoNumber CreateBankNoteId(System.Int64 value)
        => Nox.Types.AutoNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'ExchangeRateId'
    /// </summary>
    public static Nox.Types.AutoNumber CreateExchangeRateId(System.Int64 value)
        => Nox.Types.AutoNumber.From(value);
    

}