// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public class CurrencyCashBalanceKeyDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    [Key]
    public System.String StoreId { get; set; } = default!;

    /// <summary>
    ///  (Required).
    /// </summary>
    [Key]
    public System.UInt32 CurrencyId { get; set; } = default!;
}

/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalanceDto : CurrencyCashBalanceKeyDto
{

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