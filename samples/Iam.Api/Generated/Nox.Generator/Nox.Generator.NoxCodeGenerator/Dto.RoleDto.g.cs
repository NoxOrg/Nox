// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using IamApi.Application.DataTransferObjects;
using IamApi.Domain;

namespace IamApi.Application.Dto;

public record RoleKeyDto(System.String keyId);

/// <summary>
/// User Role.
/// </summary>
public partial class RoleDto
{

    /// <summary>
    /// Role identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Role Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Role Role belongs to many users ZeroOrMany UserIams
    /// </summary>
    public virtual List<UserIamDto> UserIams { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}