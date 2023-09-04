// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Holidays related to country.
/// </summary>
public partial class CountryHolidayCreateDto : CountryHolidayUpdateDto
{

    public CountryHoliday ToEntity()
    {
        var entity = new CountryHoliday();
        entity.Name = CountryHoliday.CreateName(Name);
        entity.Type = CountryHoliday.CreateType(Type);
        entity.Date = CountryHoliday.CreateDate(Date);
        //entity.Country = Country.ToEntity();
        return entity;
    }
}