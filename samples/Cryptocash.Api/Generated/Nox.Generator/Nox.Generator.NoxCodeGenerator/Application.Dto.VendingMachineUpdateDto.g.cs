// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The mac address of the vending machine (Required).
    /// </summary>
    [Required(ErrorMessage = "MacAddress is required")]
    
    public System.String MacAddress { get; set; } = default!;
    /// <summary>
    /// The public ip of the vending machine (Required).
    /// </summary>
    [Required(ErrorMessage = "PublicIp is required")]
    
    public System.String PublicIp { get; set; } = default!;
    /// <summary>
    /// The public ip of the vending machine (Required).
    /// </summary>
    [Required(ErrorMessage = "GeoLocation is required")]
    
    public LatLongDto GeoLocation { get; set; } = default!;
    /// <summary>
    /// The address of the vending machine (Required).
    /// </summary>
    [Required(ErrorMessage = "StreetAddress is required")]
    
    public StreetAddressDto StreetAddress { get; set; } = default!;
    /// <summary>
    /// The serial number of the vending machine (Required).
    /// </summary>
    [Required(ErrorMessage = "SerialNumber is required")]
    
    public System.String SerialNumber { get; set; } = default!;
    /// <summary>
    /// The area of the vending machine installation (Optional).
    /// </summary>
    public System.Decimal? InstallationFootPrint { get; set; }
    /// <summary>
    /// The land lord rent amount related to the area of the vending machine installation (Optional).
    /// </summary>
    public MoneyDto? RentPerSquareMetre { get; set; }

    /// <summary>
    /// VendingMachine The country of the vending machine ExactlyOne Countries
    /// </summary>
    public string CountryId { get; set; } = null!;

    /// <summary>
    /// VendingMachine The Land Lord related to the area of the vending machine installation ExactlyOne LandLords
    /// </summary>
    public string LandLordId { get; set; } = null!;
}