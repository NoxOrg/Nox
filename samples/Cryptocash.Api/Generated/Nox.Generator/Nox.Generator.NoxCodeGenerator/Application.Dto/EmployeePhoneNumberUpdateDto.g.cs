// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee phone number and related data
/// </summary>
public partial class EmployeePhoneNumberUpdateDto : IEntityDto<DomainNamespace.EmployeePhoneNumber>
{
    /// <summary>
    /// Employee's phone number type 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PhoneNumberType is required")]
    
    public System.String PhoneNumberType { get; set; } = default!;
    /// <summary>
    /// Employee's phone number 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PhoneNumber is required")]
    
    public System.String PhoneNumber { get; set; } = default!;
}