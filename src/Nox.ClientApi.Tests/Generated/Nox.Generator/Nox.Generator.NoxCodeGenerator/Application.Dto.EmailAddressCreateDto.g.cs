// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressCreateDto : IEntityCreateDto<EmailAddress>
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