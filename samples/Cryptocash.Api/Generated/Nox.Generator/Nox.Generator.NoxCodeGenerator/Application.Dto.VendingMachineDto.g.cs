﻿// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record VendingMachineKeyDto(System.Guid keyId);

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineDto
{

    /// <summary>
    /// The vending machine unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// The mac address of the vending machine (Required).
    /// </summary>
    public System.String MacAddress { get; set; } = default!;

    /// <summary>
    /// The public ip of the vending machine (Required).
    /// </summary>
    public System.String PublicIp { get; set; } = default!;

    /// <summary>
    /// The public ip of the vending machine (Required).
    /// </summary>
    public LatLongDto GeoLocation { get; set; } = default!;

    /// <summary>
    /// The address of the vending machine (Required).
    /// </summary>
    public StreetAddressDto StreetAddress { get; set; } = default!;

    /// <summary>
    /// The serial number of the vending machine (Required).
    /// </summary>
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
    //EF maps ForeignKey Automatically...
    public virtual string CountryId { get; set; } = null!;
    public virtual CountryDto Country { get; set; } = null!;

    /// <summary>
    /// VendingMachine The Land Lord related to the area of the vending machine installation ExactlyOne LandLords
    /// </summary>
    //EF maps ForeignKey Automatically...
    public virtual string LandLordId { get; set; } = null!;
    public virtual LandLordDto LandLord { get; set; } = null!;

    /// <summary>
    /// VendingMachine The booking's related vending machine ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> Bookings { get; set; } = new();

    /// <summary>
    /// VendingMachine The order's related vending machine ZeroOrMany VendingMachineOrders
    /// </summary>
    public virtual List<VendingMachineOrderDto> VendingMachineOrders { get; set; } = new();

    /// <summary>
    /// VendingMachine The related vending machine ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> MinimumCashStocks { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    public VendingMachine ToEntity()
    {
        var entity = new VendingMachine();
        entity.Id = VendingMachine.CreateId(Id);
        entity.MacAddress = VendingMachine.CreateMacAddress(MacAddress);
        entity.PublicIp = VendingMachine.CreatePublicIp(PublicIp);
        entity.GeoLocation = VendingMachine.CreateGeoLocation(GeoLocation);
        entity.StreetAddress = VendingMachine.CreateStreetAddress(StreetAddress);
        entity.SerialNumber = VendingMachine.CreateSerialNumber(SerialNumber);
        if (InstallationFootPrint is not null)entity.InstallationFootPrint = VendingMachine.CreateInstallationFootPrint(InstallationFootPrint.NonNullValue<System.Decimal>());
        if (RentPerSquareMetre is not null)entity.RentPerSquareMetre = VendingMachine.CreateRentPerSquareMetre(RentPerSquareMetre.NonNullValue<MoneyDto>());
        entity.Country = Country.ToEntity();
        entity.LandLord = LandLord.ToEntity();
        entity.Bookings = Bookings.Select(dto => dto.ToEntity()).ToList();
        entity.VendingMachineOrders = VendingMachineOrders.Select(dto => dto.ToEntity()).ToList();
        entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}