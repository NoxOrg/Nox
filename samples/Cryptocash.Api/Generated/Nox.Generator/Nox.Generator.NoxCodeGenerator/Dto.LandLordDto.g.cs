// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record LandLordKeyDto(System.Int64 keyId);

/// <summary>
/// Land Lord related data.
/// </summary>
public partial class LandLordDto
{

    /// <summary>
    /// The Land Lord unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The Land Lord name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The Land Lord's address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// LandLord The Land Lord related to the area of the vending machine installation ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> VendingMachines { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}