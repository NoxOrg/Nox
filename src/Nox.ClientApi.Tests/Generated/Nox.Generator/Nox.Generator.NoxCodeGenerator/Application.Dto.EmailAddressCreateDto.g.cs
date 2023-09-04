// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressCreateDto : EmailAddressUpdateDto
{

    public EmailAddress ToEntity()
    {
        var entity = new EmailAddress();
        if (Email is not null)entity.Email = EmailAddress.CreateEmail(Email.NonNullValue<System.String>());
        if (IsVerified is not null)entity.IsVerified = EmailAddress.CreateIsVerified(IsVerified.NonNullValue<System.Boolean>());
        return entity;
    }
}