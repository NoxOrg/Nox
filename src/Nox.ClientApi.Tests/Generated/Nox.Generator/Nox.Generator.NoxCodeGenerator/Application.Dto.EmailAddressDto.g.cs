// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using ClientApi.Application.DataTransferObjects;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record EmailAddressKeyDto();

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressDto
{

    /// <summary>
    /// Email (Optional).
    /// </summary>
    public System.String? Email { get; set; }

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public System.Boolean? IsVerified { get; set; }
}