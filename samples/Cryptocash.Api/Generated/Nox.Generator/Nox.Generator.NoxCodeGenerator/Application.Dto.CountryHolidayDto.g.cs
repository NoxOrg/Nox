﻿// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CountryHolidayKeyDto(System.Int64 keyId);

/// <summary>
/// Holidays related to country.
/// </summary>
public partial class CountryHolidayDto
{

    /// <summary>
    /// The country's holiday unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The country holiday name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The country holiday type (Required).
    /// </summary>
    public System.String Type { get; set; } = default!;

    /// <summary>
    /// The country holiday date (Required).
    /// </summary>
    public System.DateTime Date { get; set; } = default!;

    /// <summary>
    /// CountryHoliday The related country holidays ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidaysDto> Holidays { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    public CountryHoliday ToEntity()
    {
        var entity = new CountryHoliday();
        entity.Id = CountryHoliday.CreateId(Id);
        entity.Name = CountryHoliday.CreateName(Name);
        entity.Type = CountryHoliday.CreateType(Type);
        entity.Date = CountryHoliday.CreateDate(Date);
        entity.Holidays = Holidays.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}