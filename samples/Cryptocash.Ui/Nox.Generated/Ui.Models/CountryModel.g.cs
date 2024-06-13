// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryModel : CountryModelBase
{

}

/// <summary>
/// Country and related data
/// </summary>
public abstract class CountryModelBase: IEntityModel
{

    /// <summary>
    /// Country unique identifier
    /// </summary>
    public virtual System.String? Id { get; set; }

    /// <summary>
    /// Country's name     
    /// </summary>
    public virtual System.String? Name { get; set; }

    /// <summary>
    /// Country's official name     
    /// </summary>
    public virtual System.String? OfficialName { get; set; }

    /// <summary>
    /// Country's iso number id     
    /// </summary>
    public virtual System.UInt16? CountryIsoNumeric { get; set; }

    /// <summary>
    /// Country's iso alpha3 id     
    /// </summary>
    public virtual System.String? CountryIsoAlpha3 { get; set; }

    /// <summary>
    /// Country's geo coordinates     
    /// </summary>
    public virtual LatLongModel? GeoCoords { get; set; }

    /// <summary>
    /// Country's flag emoji     
    /// </summary>
    public virtual System.String? FlagEmoji { get; set; }

    /// <summary>
    /// Country's flag in svg format     
    /// </summary>
    public virtual ImageModel? FlagSvg { get; set; }

    /// <summary>
    /// Country's flag in png format     
    /// </summary>
    public virtual ImageModel? FlagPng { get; set; }

    /// <summary>
    /// Country's coat of arms in svg format     
    /// </summary>
    public virtual ImageModel? CoatOfArmsSvg { get; set; }

    /// <summary>
    /// Country's coat of arms in png format     
    /// </summary>
    public virtual ImageModel? CoatOfArmsPng { get; set; }

    /// <summary>
    /// Country's map via google maps     
    /// </summary>
    public virtual System.String? GoogleMapsUrl { get; set; }

    /// <summary>
    /// Country's map via open street maps     
    /// </summary>
    public virtual System.String? OpenStreetMapsUrl { get; set; }

    /// <summary>
    /// Country's start of week day     
    /// </summary>
    public virtual System.UInt16? StartOfWeek { get; set; }

    /// <summary>
    /// Country's population     
    /// </summary>
    public virtual System.Int32? Population { get; set; }
}