// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the PaymentProvider class.
/// </summary>
public partial class PaymentProvider
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'PaymentProviderName'
    /// </summary>
    public static Nox.Types.TextTypeOptions PaymentProviderNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreatePaymentProviderName(System.String value)
        => Nox.Types.Text.From(value, PaymentProviderNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'PaymentProviderType'
    /// </summary>
    public static Nox.Types.TextTypeOptions PaymentProviderTypeTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreatePaymentProviderType(System.String value)
        => Nox.Types.Text.From(value, PaymentProviderTypeTypeOptions);
    

}