// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The list of countries.
/// </summary>
public partial class CountryCreateDto : CountryUpdateDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;

    public Country ToEntity()
    {
        var entity = new Country();
        entity.Id = Country.CreateId(Id);
        entity.Name = Country.CreateName(Name);
        entity.FormalName = Country.CreateFormalName(FormalName);
        entity.AlphaCode3 = Country.CreateAlphaCode3(AlphaCode3);
        entity.AlphaCode2 = Country.CreateAlphaCode2(AlphaCode2);
        entity.NumericCode = Country.CreateNumericCode(NumericCode);
        if (DialingCodes is not null)entity.DialingCodes = Country.CreateDialingCodes(DialingCodes.NonNullValue<System.String>());
        if (Capital is not null)entity.Capital = Country.CreateCapital(Capital.NonNullValue<System.String>());
        if (Demonym is not null)entity.Demonym = Country.CreateDemonym(Demonym.NonNullValue<System.String>());
        entity.AreaInSquareKilometres = Country.CreateAreaInSquareKilometres(AreaInSquareKilometres);
        if (GeoCoord is not null)entity.GeoCoord = Country.CreateGeoCoord(GeoCoord.NonNullValue<LatLongDto>());
        entity.GeoRegion = Country.CreateGeoRegion(GeoRegion);
        entity.GeoSubRegion = Country.CreateGeoSubRegion(GeoSubRegion);
        entity.GeoWorldRegion = Country.CreateGeoWorldRegion(GeoWorldRegion);
        if (Population is not null)entity.Population = Country.CreatePopulation(Population.NonNullValue<System.Int32>());
        if (TopLevelDomains is not null)entity.TopLevelDomains = Country.CreateTopLevelDomains(TopLevelDomains.NonNullValue<System.String>());
        return entity;
    }
}