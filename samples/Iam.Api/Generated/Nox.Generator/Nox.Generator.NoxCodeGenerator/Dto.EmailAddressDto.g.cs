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

public record EmailAddressKeyDto(System.String keyEmail);

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressDto
{

    /// <summary>
    /// Email (Required).
    /// </summary>
    public System.String Email { get; set; } = default!;

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public System.Boolean? IsVerified { get; set; }

    /// <summary>
    /// EmailAddress belongs to a User ExactlyOne UserIams
    /// </summary>
    public virtual UserIamDto UserIam { get; set; } = null!;
}