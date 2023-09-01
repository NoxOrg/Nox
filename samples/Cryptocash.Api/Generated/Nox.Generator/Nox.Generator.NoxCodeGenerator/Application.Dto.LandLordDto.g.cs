// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
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
    /// LandLord Landlord's area of the vending machine installation ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> VendingMachines { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    public LandLord ToEntity()
    {
        var entity = new LandLord();
        entity.Id = LandLord.CreateId(Id);
        entity.Name = LandLord.CreateName(Name);
        entity.Address = LandLord.CreateAddress(Address);
        entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}