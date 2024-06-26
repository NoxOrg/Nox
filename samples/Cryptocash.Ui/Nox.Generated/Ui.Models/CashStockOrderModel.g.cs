﻿// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;
using System.Text.Json.Serialization;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderModel : CashStockOrderModelBase
{

}

/// <summary>
/// Vending machine cash stock order and related data
/// </summary>
public abstract class CashStockOrderModelBase: IEntityModel
{

    /// <summary>
    /// Vending machine's order unique identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Order amount     
    /// </summary>
    public virtual MoneyModel? Amount { get; set; }

    /// <summary>
    /// Order requested delivery date     
    /// </summary>
    public virtual System.DateTime? RequestedDeliveryDate { get; set; }

    /// <summary>
    /// Order delivery date     
    /// </summary>
    public virtual System.DateTimeOffset? DeliveryDateTime { get; set; }

    /// <summary>
    /// Order status     
    /// </summary>
    public virtual System.String? Status { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }

}