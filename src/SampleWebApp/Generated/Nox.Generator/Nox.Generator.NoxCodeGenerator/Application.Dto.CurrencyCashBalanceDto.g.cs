// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
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

    public CurrencyCashBalance ToEntity()
    {
        var entity = new CurrencyCashBalance();
        entity.StoreId = CurrencyCashBalance.CreateStoreId(StoreId);
        entity.CurrencyId = CurrencyCashBalance.CreateCurrencyId(CurrencyId);
        entity.Amount = CurrencyCashBalance.CreateAmount(Amount);
        if (OperationLimit is not null)entity.OperationLimit = CurrencyCashBalance.CreateOperationLimit(OperationLimit.NonNullValue<System.Decimal>());
        return entity;
    }

}