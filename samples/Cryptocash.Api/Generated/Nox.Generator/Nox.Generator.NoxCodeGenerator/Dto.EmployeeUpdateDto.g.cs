// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The employee's first name (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// The employee's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// The employee's email (Required).
    /// </summary>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// The employee's address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// The employee's first working day (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstWorkingDay is required")]
    
    public System.DateTime FirstWorkingDay { get; set; } = default!;
    /// <summary>
    /// The employee's last working day (Optional).
    /// </summary>
    public System.DateTime? LastWorkingDay { get; set; } 

    /// <summary>
    /// Employee The employee's phone numbers ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberDto> EmployeePhoneNumbers { get; set; } = new();
}