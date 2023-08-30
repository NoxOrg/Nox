// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using Cryptocash.Application.DataTransferObjects;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record HolidaysKeyDto(System.Int64 keyId);

/// <summary>
/// Holiday related info for a country.
/// </summary>
public partial class HolidaysDto
{

    /// <summary>
    /// Holiday's unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Holiday's associated year (Required).
    /// </summary>
    public System.UInt16 Year { get; set; } = default!;

    /// <summary>
    /// Week day off associated with holiday's country (Required).
    /// </summary>
    public System.UInt16 DayOff { get; set; } = default!;

    /// <summary>
    /// Holidays Holiday's country ExactlyOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string CountryId { get; set; } = null!;
    public virtual CountryDto Country { get; set; } = null!;

    /// <summary>
    /// Holidays Country's holidays ZeroOrMany CountryHolidays
    /// </summary>
    public virtual List<CountryHolidayDto> CountryHolidays { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}