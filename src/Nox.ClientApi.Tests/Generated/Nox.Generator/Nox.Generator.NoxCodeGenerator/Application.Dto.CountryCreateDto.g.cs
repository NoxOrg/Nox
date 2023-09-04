// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Country Entity.
/// </summary>
public partial class CountryCreateDto : CountryUpdateDto
{

    public Country ToEntity()
    {
        var entity = new Country();
        entity.Name = Country.CreateName(Name);
        if (Population is not null)entity.Population = Country.CreatePopulation(Population.NonNullValue<System.Int32>());
        if (CountryDebt is not null)entity.CountryDebt = Country.CreateCountryDebt(CountryDebt.NonNullValue<MoneyDto>());
        //entity.CountryLocalNames = CountryLocalNames.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}