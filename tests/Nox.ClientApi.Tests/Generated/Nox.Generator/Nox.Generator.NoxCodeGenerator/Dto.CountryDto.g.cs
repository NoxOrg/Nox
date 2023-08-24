// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using ClientApi.Application.DataTransferObjects;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryKeyDto(System.Int64 keyId);

/// <summary>
/// Country Entity.
/// </summary>
public partial class CountryDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Population (Optional).
    /// </summary>
    public System.Int32? Population { get; set; }

    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public MoneyDto? AmmountMoney { get; set; }

    /// <summary>
    /// Country is also know as ZeroOrMany OwnedEntities
    /// </summary>
    public virtual List<OwnedEntityDto> OwnedEntities { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}