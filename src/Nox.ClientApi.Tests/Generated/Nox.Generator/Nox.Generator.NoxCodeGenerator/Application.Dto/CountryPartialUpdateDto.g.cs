// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;



/// <summary>
/// Country Entity Country representation for the Client API tests.
/// </summary>
public partial class CountryPartialUpdateDto : CountryPartialUpdateDtoBase
{

}

/// <summary>
/// Country Entity Country representation for the Client API tests
/// </summary>
public partial class CountryPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Country>
{
    /// <summary>
    /// The Country Name     Set a unique name for the country Do not use abbreviations
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Population Number of People living in the country
    /// </summary>
    public virtual System.Int32? Population { get; set; }
    /// <summary>
    /// The Money
    /// </summary>
    public virtual MoneyDto? CountryDebt { get; set; }
    /// <summary>
    /// The capital location
    /// </summary>
    public virtual LatLongDto? CapitalCityLocation { get; set; }
    /// <summary>
    /// First Official Language
    /// </summary>
    public virtual System.String? FirstLanguageCode { get; set; }
    /// <summary>
    /// Country's iso number id
    /// </summary>
    public virtual System.UInt16? CountryIsoNumeric { get; set; }
    /// <summary>
    /// Country's iso alpha3 id
    /// </summary>
    public virtual System.String? CountryIsoAlpha3 { get; set; }
    /// <summary>
    /// Country's map via google maps
    /// </summary>
    public virtual System.String? GoogleMapsUrl { get; set; }
    /// <summary>
    /// Country's start of week day
    /// </summary>
    public virtual System.UInt16? StartOfWeek { get; set; }
    /// <summary>
    /// Country Continent
    /// </summary>
    public virtual System.Int32? Continent { get; set; }
}