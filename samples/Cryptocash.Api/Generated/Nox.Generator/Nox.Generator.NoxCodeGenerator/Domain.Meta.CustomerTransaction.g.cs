// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Static methods for the CustomerTransaction class.
/// </summary>
public partial class CustomerTransaction
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'TransactionType'
    /// </summary>
    public static Nox.Types.TextTypeOptions TransactionTypeTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateTransactionType(System.String value)
        => Nox.Types.Text.From(value, TransactionTypeTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'ProcessedOnDateTime'
    /// </summary>
    public static Nox.Types.DateTime CreateProcessedOnDateTime(System.DateTimeOffset value)
        => Nox.Types.DateTime.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Amount'
    /// </summary>
    public static Nox.Types.Money CreateAmount(IMoney value)
        => Nox.Types.Money.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Reference'
    /// </summary>
    public static Nox.Types.TextTypeOptions ReferenceTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateReference(System.String value)
        => Nox.Types.Text.From(value, ReferenceTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'CustomerId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateCustomerId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'BookingId'
    /// </summary>
    public static Nox.Types.DatabaseGuid CreateBookingId(System.Guid value)
        => Nox.Types.DatabaseGuid.From(value);
    

}