// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record MinimumCashStockKeyDto(System.Int64 keyId);

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockDto
{

    /// <summary>
    /// The vending machine cash stock unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The amount of the cash stock (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// MinimumCashStock The related vending machine ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string VendingMachineId { get; set; } = null!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;

    /// <summary>
    /// MinimumCashStock The currency of the cash stock ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string CurrencyId { get; set; } = null!;
    public virtual CurrencyDto Currency { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}