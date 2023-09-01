// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record CurrencyCashBalanceKeyDto(System.String keyStoreId, System.Int64 keyCurrencyId);

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
    public System.Int64 CurrencyId { get; set; } = default!;

    /// <summary>
    /// The amount (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// The Operation Limit (Optional).
    /// </summary>
    public System.Decimal? OperationLimit { get; set; }

    public System.DateTime? DeletedAtUtc { get; set; }
}