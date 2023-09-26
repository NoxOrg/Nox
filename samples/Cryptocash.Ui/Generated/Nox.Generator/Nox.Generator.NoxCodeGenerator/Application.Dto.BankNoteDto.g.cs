// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;

namespace Cryptocash.Ui.Application.Dto;

public record BankNoteKeyDto(System.Int64 keyId);

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNoteDto
{

    /// <summary>
    /// Currency bank note unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Currency's cash bank note identifier (Required).
    /// </summary>
    public System.String CashNote { get; set; } = default!;

    /// <summary>
    /// Bank note value (Required).
    /// </summary>
    public MoneyDto Value { get; set; } = default!;
}