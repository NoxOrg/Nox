// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Static methods for the CurrencyCashBalance class.
/// </summary>
public partial class CurrencyCashBalance
{
    /// <summary>
    /// Type options and factory for property 'StoreId'
    /// </summary>
    public static Nox.Types.Text CreateStoreId(System.String value)
        => Nox.Types.Text.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyId'
    /// </summary>
    public static Nox.Types.Nuid CreateCurrencyId(System.UInt32 value)
        => Nox.Types.Nuid.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Amount'
    /// </summary>
    public static Nox.Types.MoneyTypeOptions AmountTypeOptions {get; private set;} = new ()
    {
        DecimalDigits = 5,
        IntegerDigits = 10,
        MinValue = -999999999.9999m,
        MaxValue = 999999999.9999m,
        DefaultCurrency = Nox.Types.CurrencyCode.GBP,
    };
    
    public static Money CreateAmount(IMoney value)
        => Nox.Types.Money.From(value, AmountTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'OperationLimit'
    /// </summary>
    public static Nox.Types.NumberTypeOptions OperationLimitTypeOptions {get; private set;} = new ()
    {
        MinValue = 0m,
        MaxValue = 999999999m,
        DecimalDigits = 4,
    };
    
    public static Number CreateOperationLimit(System.Decimal value)
        => Nox.Types.Number.From(value, OperationLimitTypeOptions);
    

}