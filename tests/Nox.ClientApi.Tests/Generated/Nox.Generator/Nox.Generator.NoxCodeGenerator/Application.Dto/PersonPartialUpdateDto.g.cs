// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;



/// <summary>
/// Person.
/// </summary>
public partial class PersonPartialUpdateDto : PersonPartialUpdateDtoBase
{

}

/// <summary>
/// Person
/// </summary>
public partial class PersonPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// The user's first name
    /// </summary>
    public virtual System.String FirstName { get; set; } = default!;
    /// <summary>
    /// The customer's last name
    /// </summary>
    public virtual System.String LastName { get; set; } = default!;
    /// <summary>
    /// Tenant user bellongs to
    /// </summary>
    public virtual System.Guid TenantId { get; set; } = default!;
    /// <summary>
    /// The user's primary email for MFA
    /// </summary>
    public virtual System.String PrimaryEmailAddress { get; set; } = default!;
}