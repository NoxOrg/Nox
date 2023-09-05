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

    public ClientApi.Domain.Country ToEntity()
    {
        var entity = new ClientApi.Domain.Country();
        entity.Name = ClientApi.Domain.Country.CreateName(Name);
        if (Population is not null)entity.Population = ClientApi.Domain.Country.CreatePopulation(Population.NonNullValue<System.Int32>());
        if (CountryDebt is not null)entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(CountryDebt.NonNullValue<MoneyDto>());
        //entity.CountryLocalNames = CountryLocalNames.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}