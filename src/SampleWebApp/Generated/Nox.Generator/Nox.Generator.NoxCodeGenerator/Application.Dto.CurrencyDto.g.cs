// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record CurrencyKeyDto(System.UInt32 keyId);

/// <summary>
/// The list of currencies.
/// </summary>
public partial class CurrencyDto
{

    /// <summary>
    /// The currency's primary key / identifier (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// The currency's name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Currency is legal tender for ZeroOrMany Countries
    /// </summary>
    public virtual List<CountryDto> Countries { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    public Currency ToEntity()
    {
        var entity = new Currency();
        entity.Id = Currency.CreateId(Id);
        entity.Name = Currency.CreateName(Name);
        entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}