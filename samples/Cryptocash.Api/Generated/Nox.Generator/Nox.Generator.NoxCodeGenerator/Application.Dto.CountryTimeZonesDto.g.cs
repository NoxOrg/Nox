// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CountryTimeZonesKeyDto(System.Int64 keyId);

/// <summary>
/// Time zones related to country.
/// </summary>
public partial class CountryTimeZonesDto
{

    /// <summary>
    /// The country's timezone unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The country's related timezone code (Required).
    /// </summary>
    public System.String TimeZoneCode { get; set; } = default!;

    /// <summary>
    /// CountryTimeZones The country's related timezones ZeroOrMany Countries
    /// </summary>
    public virtual List<CountryDto> Countries { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    public CountryTimeZones ToEntity()
    {
        var entity = new CountryTimeZones();
        entity.Id = CountryTimeZones.CreateId(Id);
        entity.TimeZoneCode = CountryTimeZones.CreateTimeZoneCode(TimeZoneCode);
        entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}