// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public partial class EmailAddressCreateDto : EmailAddressCreateDtoBase
{

}

/// <summary>
/// Verified Email Address.
/// </summary>
public abstract class EmailAddressCreateDtoBase : IEntityDto<DomainNamespace.EmailAddress>
{
    /// <summary>
    /// Email (Optional).
    /// </summary>
    public virtual System.String? Email { get; set; }
    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public virtual System.Boolean? IsVerified { get; set; }
}