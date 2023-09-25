// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record MinimumCashStockKeyDto(System.Int64 keyId);

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockDto
{

    /// <summary>
    /// Vending machine cash stock unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// MinimumCashStock required by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> MinimumCashStocksRequiredByVendingMachines { get; set; } = new();

    /// <summary>
    /// MinimumCashStock related to ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? MinimumCashStockRelatedCurrencyId { get; set; } = default!;
    public virtual CurrencyDto? MinimumCashStockRelatedCurrency { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}