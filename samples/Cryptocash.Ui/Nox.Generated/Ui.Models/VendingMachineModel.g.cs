// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;
using System.Text.Json.Serialization;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Vending machine definition and related data.
/// </summary>
public partial class VendingMachineModel : VendingMachineModelBase
{

}

/// <summary>
/// Vending machine definition and related data
/// </summary>
public abstract class VendingMachineModelBase: IEntityModel
{

    /// <summary>
    /// Vending machine unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Vending machine mac address     
    /// </summary>
    public virtual System.String? MacAddress { get; set; }

    /// <summary>
    /// Vending machine public ip     
    /// </summary>
    public virtual System.String? PublicIp { get; set; }

    /// <summary>
    /// Vending machine geo location     
    /// </summary>
    public virtual LatLongModel? GeoLocation { get; set; }

    /// <summary>
    /// Vending machine street address     
    /// </summary>
    public virtual StreetAddressModel? StreetAddress { get; set; }

    /// <summary>
    /// Vending machine serial number     
    /// </summary>
    public virtual System.String? SerialNumber { get; set; }

    /// <summary>
    /// Vending machine installation area     
    /// </summary>
    public virtual System.Decimal? InstallationFootPrint { get; set; }

    /// <summary>
    /// Landlord rent amount based on area of the vending machine installation     
    /// </summary>
    public virtual MoneyModel? RentPerSquareMetre { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }

}