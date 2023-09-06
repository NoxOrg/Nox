// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineCreateDto 
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

    public Cryptocash.Domain.VendingMachine ToEntity()
    {
        var entity = new Cryptocash.Domain.VendingMachine();
        entity.MacAddress = Cryptocash.Domain.VendingMachine.CreateMacAddress(MacAddress);
        entity.PublicIp = Cryptocash.Domain.VendingMachine.CreatePublicIp(PublicIp);
        entity.GeoLocation = Cryptocash.Domain.VendingMachine.CreateGeoLocation(GeoLocation);
        entity.StreetAddress = Cryptocash.Domain.VendingMachine.CreateStreetAddress(StreetAddress);
        entity.SerialNumber = Cryptocash.Domain.VendingMachine.CreateSerialNumber(SerialNumber);
        if (InstallationFootPrint is not null)entity.InstallationFootPrint = Cryptocash.Domain.VendingMachine.CreateInstallationFootPrint(InstallationFootPrint.NonNullValue<System.Decimal>());
        if (RentPerSquareMetre is not null)entity.RentPerSquareMetre = Cryptocash.Domain.VendingMachine.CreateRentPerSquareMetre(RentPerSquareMetre.NonNullValue<MoneyDto>());
        //entity.Country = Country.ToEntity();
        //entity.LandLord = LandLord.ToEntity();
        //entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        //entity.CashStockOrders = CashStockOrders.Select(dto => dto.ToEntity()).ToList();
        //entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}