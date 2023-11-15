// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record VendingMachineKeyDto(System.Guid keyId);

/// <summary>
/// Update VendingMachine
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineDto : VendingMachineDtoBase
{

}

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public abstract class VendingMachineDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.VendingMachine>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.MacAddress is not null)
            ExecuteActionAndCollectValidationExceptions("MacAddress", () => DomainNamespace.VendingMachineMetadata.CreateMacAddress(this.MacAddress.NonNullValue<System.String>()), result);
        else
            result.Add("MacAddress", new [] { "MacAddress is Required." });
    
        if (this.PublicIp is not null)
            ExecuteActionAndCollectValidationExceptions("PublicIp", () => DomainNamespace.VendingMachineMetadata.CreatePublicIp(this.PublicIp.NonNullValue<System.String>()), result);
        else
            result.Add("PublicIp", new [] { "PublicIp is Required." });
    
        if (this.GeoLocation is not null)
            ExecuteActionAndCollectValidationExceptions("GeoLocation", () => DomainNamespace.VendingMachineMetadata.CreateGeoLocation(this.GeoLocation.NonNullValue<LatLongDto>()), result);
        else
            result.Add("GeoLocation", new [] { "GeoLocation is Required." });
    
        if (this.StreetAddress is not null)
            ExecuteActionAndCollectValidationExceptions("StreetAddress", () => DomainNamespace.VendingMachineMetadata.CreateStreetAddress(this.StreetAddress.NonNullValue<StreetAddressDto>()), result);
        else
            result.Add("StreetAddress", new [] { "StreetAddress is Required." });
    
        if (this.SerialNumber is not null)
            ExecuteActionAndCollectValidationExceptions("SerialNumber", () => DomainNamespace.VendingMachineMetadata.CreateSerialNumber(this.SerialNumber.NonNullValue<System.String>()), result);
        else
            result.Add("SerialNumber", new [] { "SerialNumber is Required." });
    
        if (this.InstallationFootPrint is not null)
            ExecuteActionAndCollectValidationExceptions("InstallationFootPrint", () => DomainNamespace.VendingMachineMetadata.CreateInstallationFootPrint(this.InstallationFootPrint.NonNullValue<System.Decimal>()), result);
        if (this.RentPerSquareMetre is not null)
            ExecuteActionAndCollectValidationExceptions("RentPerSquareMetre", () => DomainNamespace.VendingMachineMetadata.CreateRentPerSquareMetre(this.RentPerSquareMetre.NonNullValue<MoneyDto>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Vending machine unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Vending machine mac address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String MacAddress { get; set; } = default!;

    /// <summary>
    /// Vending machine public ip 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String PublicIp { get; set; } = default!;

    /// <summary>
    /// Vending machine geo location 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public LatLongDto GeoLocation { get; set; } = default!;

    /// <summary>
    /// Vending machine street address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public StreetAddressDto StreetAddress { get; set; } = default!;

    /// <summary>
    /// Vending machine serial number 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String SerialNumber { get; set; } = default!;

    /// <summary>
    /// Vending machine installation area 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Decimal? InstallationFootPrint { get; set; }

    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public MoneyDto? RentPerSquareMetre { get; set; }

    /// <summary>
    /// VendingMachine installed in ExactlyOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? CountryId { get; set; } = default!;
    public virtual CountryDto? Country { get; set; } = null!;

    /// <summary>
    /// VendingMachine contracted area leased by ExactlyOne LandLords
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? LandLordId { get; set; } = default!;
    public virtual LandLordDto? LandLord { get; set; } = null!;

    /// <summary>
    /// VendingMachine related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> Bookings { get; set; } = new();

    /// <summary>
    /// VendingMachine related to ZeroOrMany CashStockOrders
    /// </summary>
    public virtual List<CashStockOrderDto> CashStockOrders { get; set; } = new();

    /// <summary>
    /// VendingMachine required ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> MinimumCashStocks { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}