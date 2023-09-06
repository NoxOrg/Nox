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
public partial class EmailAddressCreateDto 
{    
    /// <summary>
    /// Email (Optional).
    /// </summary>
    public System.String? Email { get; set; }    
    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public System.Boolean? IsVerified { get; set; }

    public ClientApi.Domain.EmailAddress ToEntity()
    {
        var entity = new ClientApi.Domain.EmailAddress();
        if (Email is not null)entity.Email = ClientApi.Domain.EmailAddress.CreateEmail(Email.NonNullValue<System.String>());
        if (IsVerified is not null)entity.IsVerified = ClientApi.Domain.EmailAddress.CreateIsVerified(IsVerified.NonNullValue<System.Boolean>());
        return entity;
    }
}