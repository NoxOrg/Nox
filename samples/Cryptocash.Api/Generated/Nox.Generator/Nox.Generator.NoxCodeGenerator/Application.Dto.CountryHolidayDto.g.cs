// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CountryHolidayKeyDto(System.Int64 keyId);

/// <summary>
/// Holidays related to country.
/// </summary>
public partial class CountryHolidayDto
{

    /// <summary>
    /// Country's holiday unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Country holiday name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country holiday type (Required).
    /// </summary>
    public System.String Type { get; set; } = default!;

    /// <summary>
    /// Country holiday date (Required).
    /// </summary>
    public System.DateTime Date { get; set; } = default!;

    /// <summary>
    /// CountryHoliday Country's holidays ExactlyOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String CountryId { get; set; } = default!;
    public virtual CountryDto Country { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public CountryHoliday ToEntity()
    {
        var entity = new CountryHoliday();
        entity.Id = CountryHoliday.CreateId(Id);
        entity.Name = CountryHoliday.CreateName(Name);
        entity.Type = CountryHoliday.CreateType(Type);
        entity.Date = CountryHoliday.CreateDate(Date);
        entity.Country = Country.ToEntity();
        return entity;
    }

}