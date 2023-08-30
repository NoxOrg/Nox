// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
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

    public EmailAddress ToEntity()
    {
        var entity = new EmailAddress();
        if (Email is not null)entity.Email = EmailAddress.CreateEmail(Email.NonNullValue<System.String>());
        if (IsVerified is not null)entity.IsVerified = EmailAddress.CreateIsVerified(IsVerified.NonNullValue<System.Boolean>());
        return entity;
    }

}