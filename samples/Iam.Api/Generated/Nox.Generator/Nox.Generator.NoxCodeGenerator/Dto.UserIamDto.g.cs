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

public record UserIamKeyDto(System.Int64 keyId);

/// <summary>
/// User.
/// </summary>
public partial class UserIamDto
{

    /// <summary>
    /// The Customer unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The customer's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// The customer's email (Required).
    /// </summary>
    public System.String Email { get; set; } = default!;

    public System.DateTime? DeletedAtUtc { get; set; }
}