// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Static methods for the CurrencyBankNotes class.
/// </summary>
public partial class CurrencyBankNotes
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'BankNote'
    /// </summary>
    public static Nox.Types.TextTypeOptions BankNoteTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateBankNote(System.String value)
        => Nox.Types.Text.From(value, BankNoteTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'IsRare'
    /// </summary>
    public static Nox.Types.Boolean CreateIsRare(System.Boolean value)
        => Nox.Types.Boolean.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyId'
    /// </summary>
    public static Nox.Types.CurrencyCode3 CreateCurrencyId(System.String value)
        => Nox.Types.CurrencyCode3.From(value);
    

}