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

public record CurrencyBankNotesKeyDto(System.Int64 keyId);

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class CurrencyBankNotesDto
{

    /// <summary>
    /// Currency bank note unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Currency's bank note identifier (Required).
    /// </summary>
    public System.String BankNote { get; set; } = default!;

    /// <summary>
    /// Is bank note rare or frequent (Required).
    /// </summary>
    public System.Boolean IsRare { get; set; } = default!;

    /// <summary>
    /// CurrencyBankNotes Currency's bank notes ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string CurrencyId { get; set; } = null!;
    public virtual CurrencyDto Currency { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}