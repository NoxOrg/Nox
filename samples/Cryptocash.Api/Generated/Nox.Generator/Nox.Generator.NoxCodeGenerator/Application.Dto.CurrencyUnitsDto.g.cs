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

public record CurrencyUnitsKeyDto(System.Int64 keyId);

/// <summary>
/// Currencies related units major and minor.
/// </summary>
public partial class CurrencyUnitsDto
{

    /// <summary>
    /// Currency unit unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Currency's major name (Required).
    /// </summary>
    public System.String MajorName { get; set; } = default!;

    /// <summary>
    /// Currency's major display symbol (Required).
    /// </summary>
    public System.String MajorSymbol { get; set; } = default!;

    /// <summary>
    /// Currency's minor name (Required).
    /// </summary>
    public System.String MinorName { get; set; } = default!;

    /// <summary>
    /// Currency's minor display symbol (Required).
    /// </summary>
    public System.String MinorSymbol { get; set; } = default!;

    /// <summary>
    /// Currency's minor value when converted to major (Required).
    /// </summary>
    public MoneyDto MinorToMajorValue { get; set; } = default!;

    /// <summary>
    /// CurrencyUnits Currency's units ZeroOrMany Currencies
    /// </summary>
    public virtual List<CurrencyDto> Currencies { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}