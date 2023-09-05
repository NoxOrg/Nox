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

    public SampleWebApp.Domain.Country ToEntity()
    {
        var entity = new SampleWebApp.Domain.Country();
        entity.Id = Country.CreateId(Id);
        entity.Name = SampleWebApp.Domain.Country.CreateName(Name);
        entity.FormalName = SampleWebApp.Domain.Country.CreateFormalName(FormalName);
        entity.AlphaCode3 = SampleWebApp.Domain.Country.CreateAlphaCode3(AlphaCode3);
        entity.AlphaCode2 = SampleWebApp.Domain.Country.CreateAlphaCode2(AlphaCode2);
        entity.NumericCode = SampleWebApp.Domain.Country.CreateNumericCode(NumericCode);
        if (DialingCodes is not null)entity.DialingCodes = SampleWebApp.Domain.Country.CreateDialingCodes(DialingCodes.NonNullValue<System.String>());
        if (Capital is not null)entity.Capital = SampleWebApp.Domain.Country.CreateCapital(Capital.NonNullValue<System.String>());
        if (Demonym is not null)entity.Demonym = SampleWebApp.Domain.Country.CreateDemonym(Demonym.NonNullValue<System.String>());
        entity.AreaInSquareKilometres = SampleWebApp.Domain.Country.CreateAreaInSquareKilometres(AreaInSquareKilometres);
        if (GeoCoord is not null)entity.GeoCoord = SampleWebApp.Domain.Country.CreateGeoCoord(GeoCoord.NonNullValue<LatLongDto>());
        entity.GeoRegion = SampleWebApp.Domain.Country.CreateGeoRegion(GeoRegion);
        entity.GeoSubRegion = SampleWebApp.Domain.Country.CreateGeoSubRegion(GeoSubRegion);
        entity.GeoWorldRegion = SampleWebApp.Domain.Country.CreateGeoWorldRegion(GeoWorldRegion);
        if (Population is not null)entity.Population = SampleWebApp.Domain.Country.CreatePopulation(Population.NonNullValue<System.Int32>());
        if (TopLevelDomains is not null)entity.TopLevelDomains = SampleWebApp.Domain.Country.CreateTopLevelDomains(TopLevelDomains.NonNullValue<System.String>());
        return entity;
    }
}