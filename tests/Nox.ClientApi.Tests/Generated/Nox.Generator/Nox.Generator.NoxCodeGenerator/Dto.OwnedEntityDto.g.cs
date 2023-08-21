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

public record OwnedEntityKeyDto(System.Int64 keyId);

/// <summary>
/// OwnedEntity.
/// </summary>
public partial class OwnedEntityDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The Text (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    public bool? Deleted { get; set; }
}