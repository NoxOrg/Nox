// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddressUpdateDto : EmailAddressUpdateDtoBase
{

}

/// <summary>
/// Verified Email Address
/// </summary>
public partial class EmailAddressUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.EmailAddress>
{
    /// <summary>
    /// Email     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Email { get; set; }
    /// <summary>
    /// Verified     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Boolean? IsVerified { get; set; }
}