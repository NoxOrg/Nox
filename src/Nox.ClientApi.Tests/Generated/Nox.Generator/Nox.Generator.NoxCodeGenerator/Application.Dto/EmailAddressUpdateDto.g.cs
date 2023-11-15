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
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.String? Email { get; set; }
    /// <summary>
    /// Verified 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.Boolean? IsVerified { get; set; }
}