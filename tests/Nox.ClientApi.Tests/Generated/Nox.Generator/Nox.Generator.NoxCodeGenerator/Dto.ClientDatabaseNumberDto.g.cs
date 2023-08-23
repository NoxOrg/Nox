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

public record ClientDatabaseNumberKeyDto(System.Int64 keyId);

/// <summary>
/// Client DatabaseNumber Key.
/// </summary>
public partial class ClientDatabaseNumberDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The Text (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The Number (Optional).
    /// </summary>
    public System.Int32? Number { get; set; }

    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public MoneyDto? AmmountMoney { get; set; }

    /// <summary>
    /// ClientDatabaseNumber is also know as ZeroOrMany OwnedEntities
    /// </summary>
    public virtual List<OwnedEntityDto> OwnedEntities { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}