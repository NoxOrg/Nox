// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record CurrencyCashBalanceKeyDto(System.String keyStoreId, System.UInt32 keyCurrencyId);

/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalanceDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String StoreId { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.UInt32 CurrencyId { get; set; } = default!;

    /// <summary>
    /// The amount (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// The Operation Limit (Optional).
    /// </summary>
    public System.Decimal? OperationLimit { get; set; }
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }
}