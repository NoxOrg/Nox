// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the VendingMachineOrder class.
/// </summary>
public partial class VendingMachineOrder
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
    /// Type options and factory for property 'RequestedDeliveryDate'
    /// </summary>
    public static Nox.Types.Date CreateRequestedDeliveryDate(System.DateTime value)
        => Nox.Types.Date.From(value);
    

    /// <summary>
    /// Type options and factory for property 'DeliveryDateTime'
    /// </summary>
    public static Nox.Types.DateTime CreateDeliveryDateTime(System.DateTimeOffset value)
        => Nox.Types.DateTime.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Status'
    /// </summary>
    public static Nox.Types.FormulaTypeOptions StatusTypeOptions {get; private set;} = new ()
    {
        Expression = "DeliveryDateTime != null ? \"delivered\" : \"ordered\"",
        Returns = Nox.Types.FormulaReturnType.String,
    };
    
    public static Formula CreateStatus(System.String value)
        => Nox.Types.Formula.From(value, StatusTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'VendingMachineId'
    /// </summary>
    public static Nox.Types.DatabaseGuid CreateVendingMachineId(System.Guid value)
        => Nox.Types.DatabaseGuid.From(value);
    

}