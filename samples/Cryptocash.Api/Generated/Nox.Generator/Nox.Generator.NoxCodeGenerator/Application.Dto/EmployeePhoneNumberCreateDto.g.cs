// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class EmployeePhoneNumberCreateDto : EmployeePhoneNumberCreateDtoBase
{

}

/// <summary>
/// Employee phone number and related data.
/// </summary>
public abstract class EmployeePhoneNumberCreateDtoBase : IEntityDto<DomainNamespace.EmployeePhoneNumber>
{
    /// <summary>
    /// Employee's phone number type 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PhoneNumberType is required")]
    
    public virtual System.String PhoneNumberType { get; set; } = default!;
    /// <summary>
    /// Employee's phone number 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PhoneNumber is required")]
    
    public virtual System.String PhoneNumber { get; set; } = default!;
}