// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the MinimumCashStock class.
/// </summary>
public partial class MinimumCashStock
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Amount'
    /// </summary>
    public static Nox.Types.Money CreateAmount(IMoney value)
        => Nox.Types.Money.From(value);
    

    /// <summary>
    /// Type options and factory for property 'VendingMachineId'
    /// </summary>
    public static Nox.Types.DatabaseGuid CreateVendingMachineId(System.Guid value)
        => Nox.Types.DatabaseGuid.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyId'
    /// </summary>
    public static Nox.Types.CurrencyCode3 CreateCurrencyId(System.String value)
        => Nox.Types.CurrencyCode3.From(value);
    

}