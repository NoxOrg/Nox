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

public record ApplicationIAMKeyDto(System.Int64 keyId);

/// <summary>
/// ApplicationIAM.
/// </summary>
public partial class ApplicationIAMDto
{

    /// <summary>
    /// Application Id (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The employee's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// The employee's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    public System.DateTime? DeletedAtUtc { get; set; }
}