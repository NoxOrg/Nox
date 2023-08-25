// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CurrencyBankNotesKeyDto(System.Int64 keyId);

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class CurrencyBankNotesDto
{

    /// <summary>
    /// The currency bank note unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The currency's bank note identifier (Required).
    /// </summary>
    public System.String BankNote { get; set; } = default!;

    /// <summary>
    /// Is bank note rare or frequent (Required).
    /// </summary>
    public System.Boolean IsRare { get; set; } = default!;

    /// <summary>
    /// CurrencyBankNotes The currency's related bank notes OneOrMany Currencies
    /// </summary>
    public virtual List<CurrencyDto> Currencies { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}