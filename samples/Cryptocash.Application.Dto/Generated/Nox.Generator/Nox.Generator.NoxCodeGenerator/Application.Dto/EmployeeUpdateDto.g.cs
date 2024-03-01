// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeUpdateDto : EmployeeUpdateDtoBase
{

}

/// <summary>
/// Employee definition and related data
/// </summary>
public partial class EmployeeUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Employee's first name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String? FirstName { get; set; }
    /// <summary>
    /// Employee's last name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String? LastName { get; set; }
    /// <summary>
    /// Employee's email address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public virtual System.String? EmailAddress { get; set; }
    /// <summary>
    /// Employee's street address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto? Address { get; set; }
    /// <summary>
    /// Employee's first working day     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "FirstWorkingDay is required")]
    
    public virtual System.DateTime? FirstWorkingDay { get; set; }
    /// <summary>
    /// Employee's last working day     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.DateTime? LastWorkingDay { get; set; }
    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberUpsertDto>? EmployeePhoneNumbers { get; set; }
}