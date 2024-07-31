// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;
using System.Text.Json.Serialization;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockModel : MinimumCashStockModelBase
{

}

/// <summary>
/// Minimum cash stock required for vending machine
/// </summary>
public abstract class MinimumCashStockModelBase: IEntityModel
{

    /// <summary>
    /// Vending machine cash stock unique identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Cash stock amount     
    /// </summary>
    public virtual MoneyModel? Amount { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }

}