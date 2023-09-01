// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Static methods for the Store class.
/// </summary>
public partial class Store
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.TextTypeOptions IdTypeOptions {get; private set;} = new ()
    {
        MinLength = 3,
        MaxLength = 3,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateId(System.String value)
        => Nox.Types.Text.From(value, IdTypeOptions);
    

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
    /// Type options and factory for property 'PhysicalMoney'
    /// </summary>
    public static Nox.Types.MoneyTypeOptions PhysicalMoneyTypeOptions {get; private set;} = new ()
    {
        DecimalDigits = 5,
        IntegerDigits = 10,
        MinValue = -999999999.9999m,
        MaxValue = 999999999.9999m,
        DefaultCurrency = Nox.Types.CurrencyCode.GBP,
    };
    
    public static Money CreatePhysicalMoney(IMoney value)
        => Nox.Types.Money.From(value, PhysicalMoneyTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'StoreSecurityPasswordsId'
    /// </summary>
    public static Nox.Types.TextTypeOptions StoreSecurityPasswordsIdTypeOptions {get; private set;} = new ()
    {
        MinLength = 3,
        MaxLength = 3,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateStoreSecurityPasswordsId(System.String value)
        => Nox.Types.Text.From(value, StoreSecurityPasswordsIdTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'StoreOwnerId'
    /// </summary>
    public static Nox.Types.TextTypeOptions StoreOwnerIdTypeOptions {get; private set;} = new ()
    {
        MinLength = 3,
        MaxLength = 3,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateStoreOwnerId(System.String value)
        => Nox.Types.Text.From(value, StoreOwnerIdTypeOptions);
    

}