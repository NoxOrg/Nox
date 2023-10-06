// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientApi.Domain;

using EmailAddressEntity = ClientApi.Domain.EmailAddress;
namespace ClientApi.Application.Dto;

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressUpdateDto : IEntityDto<EmailAddressEntity>
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