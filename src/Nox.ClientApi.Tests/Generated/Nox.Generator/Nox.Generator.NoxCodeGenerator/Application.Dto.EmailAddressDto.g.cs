// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record EmailAddressKeyDto(System.Int64 keyId);

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Email (Optional).
    /// </summary>
    public System.String? Email { get; set; }

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public System.Boolean? IsVerified { get; set; }    
}