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
public partial class CountryCreateDto 
{    
    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;    
    /// <summary>
    /// Population (Optional).
    /// </summary>
    public System.Int32? Population { get; set; }    
    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public MoneyDto? CountryDebt { get; set; }    
    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public System.String? ShortDescription { get; set; }

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameCreateDto> CountryLocalNames { get; set; } = new();

    public ClientApi.Domain.Country ToEntity()
    {
        var entity = new ClientApi.Domain.Country();
        entity.Name = ClientApi.Domain.Country.CreateName(Name);
        if (Population is not null)entity.Population = ClientApi.Domain.Country.CreatePopulation(Population.NonNullValue<System.Int32>());
        if (CountryDebt is not null)entity.CountryDebt = ClientApi.Domain.Country.CreateCountryDebt(CountryDebt.NonNullValue<MoneyDto>());
        entity.CountryLocalNames = CountryLocalNames.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}