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

public record StoreKeyDto(System.UInt32 keyId);

/// <summary>
/// Stores.
/// </summary>
public partial class StoreDto
{

    /// <summary>
    /// NuidField Type (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    public System.DateTime? DeletedAtUtc { get; set; }
}