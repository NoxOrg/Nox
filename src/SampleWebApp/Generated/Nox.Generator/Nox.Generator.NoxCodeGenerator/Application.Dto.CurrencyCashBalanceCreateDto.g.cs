// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalanceCreateDto : CurrencyCashBalanceUpdateDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "StoreId is required")]
    public System.String StoreId { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "CurrencyId is required")]
    public System.UInt32 CurrencyId { get; set; } = default!;

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