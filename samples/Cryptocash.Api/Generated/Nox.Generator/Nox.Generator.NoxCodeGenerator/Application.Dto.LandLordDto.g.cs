// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record LandLordKeyDto(System.Int64 keyId);

/// <summary>
/// Landlord related data.
/// </summary>
public partial class LandLordDto
{

    /// <summary>
    /// Landlord unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Landlord name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Landlord's street address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// LandLord leases an area to house ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> VendingMachine { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }    
}