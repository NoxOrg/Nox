﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cryptocash.Domain;

using VendingMachineEntity = Cryptocash.Domain.VendingMachine;
namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineUpdateDto : IEntityDto<VendingMachineEntity>
{
    /// <summary>
    /// Vending machine mac address (Required).
    /// </summary>
    [Required(ErrorMessage = "MacAddress is required")]
    
    public System.String MacAddress { get; set; } = default!;
    /// <summary>
    /// Vending machine public ip (Required).
    /// </summary>
    [Required(ErrorMessage = "PublicIp is required")]
    
    public System.String PublicIp { get; set; } = default!;
    /// <summary>
    /// Vending machine geo location (Required).
    /// </summary>
    [Required(ErrorMessage = "GeoLocation is required")]
    
    public LatLongDto GeoLocation { get; set; } = default!;
    /// <summary>
    /// Vending machine street address (Required).
    /// </summary>
    [Required(ErrorMessage = "StreetAddress is required")]
    
    public StreetAddressDto StreetAddress { get; set; } = default!;
    /// <summary>
    /// Vending machine serial number (Required).
    /// </summary>
    [Required(ErrorMessage = "SerialNumber is required")]
    
    public System.String SerialNumber { get; set; } = default!;
    /// <summary>
    /// Vending machine installation area (Optional).
    /// </summary>
    public System.Decimal? InstallationFootPrint { get; set; }
    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation (Optional).
    /// </summary>
    public MoneyDto? RentPerSquareMetre { get; set; }

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    [Required(ErrorMessage = "VendingMachineInstallationCountry is required")]
    public System.String VendingMachineInstallationCountryId { get; set; } = default!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    [Required(ErrorMessage = "VendingMachineContractedAreaLandLord is required")]
    public System.Int64 VendingMachineContractedAreaLandLordId { get; set; } = default!;
}