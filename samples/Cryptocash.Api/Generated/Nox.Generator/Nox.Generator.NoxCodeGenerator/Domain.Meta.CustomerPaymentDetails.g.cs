﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the CustomerPaymentDetails class.
/// </summary>
public partial class CustomerPaymentDetails
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'PaymentAccountName'
    /// </summary>
    public static Nox.Types.TextTypeOptions PaymentAccountNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreatePaymentAccountName(System.String value)
        => Nox.Types.Text.From(value, PaymentAccountNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'PaymentAccountNumber'
    /// </summary>
    public static Nox.Types.TextTypeOptions PaymentAccountNumberTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreatePaymentAccountNumber(System.String value)
        => Nox.Types.Text.From(value, PaymentAccountNumberTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'PaymentAccountSortCode'
    /// </summary>
    public static Nox.Types.TextTypeOptions PaymentAccountSortCodeTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreatePaymentAccountSortCode(System.String value)
        => Nox.Types.Text.From(value, PaymentAccountSortCodeTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'CustomerId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateCustomerId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'PaymentProviderId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreatePaymentProviderId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

}