// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerPartialUpdateDto : CustomerPartialUpdateDtoBase
{

}

/// <summary>
/// Customer definition and related data
/// </summary>
public partial class CustomerPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Customer's first name
    /// </summary>
    public virtual System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Customer's last name
    /// </summary>
    public virtual System.String LastName { get; set; } = default!;
    /// <summary>
    /// Customer's email address
    /// </summary>
    public virtual System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Customer's street address
    /// </summary>
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Customer's mobile number
    /// </summary>
    public virtual System.String? MobileNumber { get; set; }
}